using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using SocketIOClient.Messages;
using UnityEngine;

public abstract class NetworkDataObject
{

    public event Action<NetworkDataObject> Updated;

    public bool Available { get; set; }
    public string Id { get; set; }
    public DateTime LastModified { get; private set; }

    public void Merge(object newData)
    {
        Debug.Log(newData);
        Available = true;
        LastModified = DateTime.UtcNow;
        foreach (var prop in this.GetType().GetProperties().Where(x => x.CanRead && x.CanWrite))
        {
            try
            {
                var value = prop.GetValue(newData, null);
                if (value != null)
                    prop.SetValue(this, value, null);
            }
            catch (Exception ex)
            {
                Debug.Log("Failed to merge " + prop.Name + ", due to: " + ex.Message);
            }
        }
        if (Updated != null)
            Updated(this);
    }
    public override int GetHashCode()
    {
        return (this.GetType().Name + Id).GetHashCode();
    }
}

enum QueuedRequestType
{
    None = 0,
    Create,
    Update,
    Delete
}
class QueuedRequest
{
    public QueuedRequest(QueuedRequestType type, Action<object> callback)
    {
        Type = type;
        Callback = callback;
    }
    public QueuedRequestType Type { get; set; }
    public Action<object> Callback { get; private set; }
}
public class DataStore
{
    private static int GetHashCode(Type t, string id)
    {
        return (t.Name + id).GetHashCode();
    }
    /// <summary>
    /// Internal tracking dictionary for storing objects
    /// </summary>
    private static readonly Dictionary<int, NetworkDataObject> ObjectTracker 
        = new Dictionary<int, NetworkDataObject>();
    
    private static readonly List<QueuedRequest> QueuedRequests
        = new List<QueuedRequest>();

    /// <summary>
    /// Retreives an object from a datasource, depending on the availability.
    /// </summary>
    /// <typeparam name="T">Type of object to retreive, must of type NetworkDataObject</typeparam>
    /// <param name="id">The Id for the object to retreive</param>
    /// <param name="callback">A callback to handle the retreived data. Can be null to just queue update from server or heat up data from disk cache.</param>
    public static void Get<T>(string id, Action<T> callback) where T : NetworkDataObject, new()
    {
        // we define event as "get Type", needs to be mapped on server as well
        string eventName = typeof(T).Name + ".get";
        // get unique-ish hash key for object
        int hash = GetHashCode(typeof(T), id);
        // if object was last modified less than a minute ago, return instantly and queue an update
        bool fast = false;
        if (ObjectTracker.ContainsKey(hash) && ObjectTracker[hash].LastModified > DateTime.UtcNow - TimeSpan.FromMinutes(1))
        {
            if (callback != null)
                callback(ObjectTracker[hash] as T);
            fast = true;
        }
        if (CommunicationsApi.IsAvailable)
        {
            // Queue update from server
            CommunicationsApi.Socket.Emit(eventName, id, "", o =>
            {
                // New object? create empty instance and merge data to it
                if (!ObjectTracker.ContainsKey(hash))
                    ObjectTracker[hash] = new T();
                ObjectTracker[hash].Merge((o as JsonEncodedEventMessage).GetFirstArgAs<T>());
                // Update Offline Cache, is done async so it doesn't block
                OfflineCache.QueueStore(hash, ObjectTracker[hash]);
                if (!fast && callback != null)
                    callback(ObjectTracker[hash] as T);

            });
        }
        else
        {
            if (fast) // fast cache but API offline? not our problem for now
                return;
            // Got an object tracked but older than a minute? lets just use it
            if (ObjectTracker.ContainsKey(hash))
            {
                if (callback != null)
                    callback(ObjectTracker[hash] as T);
            }
            // Attempt to fetch sync from Offline Cache
            var cache = OfflineCache.Fetch<T>(hash);
            if (cache != null)
            {
                ObjectTracker[hash] = cache;
                if (callback != null)
                    callback(cache);
            }
            else
            {
                if(callback != null)
                    callback(new T()); // returns empty object that is considered unavailable
            }
        }
    }

    /// <summary>
    /// Gets a list of objects corresponding to the relevancy of the request. Is async with callback in most cases.
    /// </summary>
    /// <typeparam name="T">The type of objects to list</typeparam>
    /// <param name="callback">A callback to handle the requested data. Can be null to just queue update from server or heat up data from disk cache.</param>
    public static void List<T>(Action<IEnumerable<T>> callback) where T: NetworkDataObject, new()
    {
        string eventName = typeof(T).Name + ".list";
        int hash = eventName.GetHashCode();
        if (CommunicationsApi.IsAvailable)
        {
            // fetch array with ids, then Get each object (allows us to fetch from local cache instead of sending buttloads of data over net by default)
            CommunicationsApi.Socket.Emit(eventName, null, "", o =>
            {
                List<T> returns = new List<T>();
                var got = (o as JsonEncodedEventMessage).GetFirstArgAs<string[]>();
                int i = got.Length;
                foreach (var id in got)
                {
                    Get<T>(id, obj =>
                    {
                        returns.Add(obj);
                        i--;
                        if (i == 0)
                        {
                            if (callback != null)
                                callback(returns);
                        }
                    });
                }
            });
        }
        else
        {
            var cache = OfflineCache.Fetch<T>(hash);
            if (cache != null)
            {
                List<T> returns = new List<T>();
                var got = (cache as string[]);
                int i = got.Length;
                foreach (var id in got)
                {
                    Get<T>(id, obj =>
                    {
                        returns.Add(obj);
                        i--;
                        if (i == 0)
                        {
                            if (callback != null)
                                callback(returns);
                        }
                    });
                }
            }
            else
            {
                if (callback != null)
                    callback(new T[0]);
            }
        }
    }

    /// <summary>
    /// Registers an NetworkDataObject type for AutoUpdates.
    /// </summary>
    /// <typeparam name="T">The type of object to register.</typeparam>
    public static void RegisterAutoUpdate<T>() where T : NetworkDataObject, new()
    {
        var eventName = typeof(T).Name + ".update";
        CommunicationsApi.Socket.On(eventName, message =>
        {
            var obj = message.Json.GetFirstArgAs<T>();
            int hash = GetHashCode(typeof(T), obj.Id);
            if (!ObjectTracker.ContainsKey(hash))
                ObjectTracker[hash] = new T();
            ObjectTracker[hash].Merge(obj);
            // Update Offline Cache, is done async so it doesn't block
            OfflineCache.QueueStore(hash, ObjectTracker[hash]);
        });   
    }
    public static void Update<T>(T obj, Action<bool> callback) where T : NetworkDataObject, new()
    {
        string eventName = typeof(T).Name + ".update";
        int hash = GetHashCode(typeof(T), obj.Id);
        Action<object> emitCallback = o =>
        {
        };
        if (CommunicationsApi.IsAvailable)
        {
            CommunicationsApi.Socket.Emit(eventName, obj, "", emitCallback);
        }
        else
        {
            // queue for update
            QueuedRequests.Add(new QueuedRequest(QueuedRequestType.Update, emitCallback));
        }
    }

    public static void Create<T>(T obj, Action<T> callback) where T : NetworkDataObject, new()
    {
        Action<object> emitCallback = o =>
        {
            var created = (o as JsonEncodedEventMessage).GetFirstArgAs<T>();
            int hash = GetHashCode(typeof(T), created.Id);
            if (!ObjectTracker.ContainsKey(hash))
                ObjectTracker[hash] = new T();
            ObjectTracker[hash].Merge(created);
            OfflineCache.QueueStore(hash, ObjectTracker[hash]);
            if (callback != null)
                callback(ObjectTracker[hash] as T);
        };
        string eventName = typeof(T).Name + ".create";
        if (CommunicationsApi.IsAvailable)
        {
            CommunicationsApi.Socket.Emit(eventName, obj, "", emitCallback);
        }
        else
        {
            // queue for update
            QueuedRequests.Add(new QueuedRequest(QueuedRequestType.Create, emitCallback));
        }
    }

    public static void Delete<T>(T obj, Action<bool> callback) where T : NetworkDataObject, new()
    {
        int hash = GetHashCode(typeof(T), obj.Id);
        Action<object> emitCallback = o =>
        {
            ObjectTracker.Remove(hash);
            OfflineCache.Purge(hash);
            if (callback != null)
                callback(true);
        };
        string eventName = typeof(T).Name + ".delete";
        if (CommunicationsApi.IsAvailable)
        {
            CommunicationsApi.Socket.Emit(eventName, obj.Id, "", emitCallback);
        }
        else
        {
            QueuedRequests.Add(new QueuedRequest(QueuedRequestType.Delete, emitCallback));
        }
    }
}
