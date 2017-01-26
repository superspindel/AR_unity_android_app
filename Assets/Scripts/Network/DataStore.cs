using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public abstract class NetworkDataObject
{
    public bool Available { get; set; }
    public string Id { get; set; }
    public DateTime LastModified { get; private set; }

    public void Merge(object newData)
    {
        Available = true;
        LastModified = DateTime.UtcNow;
        foreach (var prop in this.GetType().GetProperties().Where(x => x.CanRead && x.CanWrite))
        {
            var value = prop.GetValue(newData, null);
            if(value != null)
                prop.SetValue(this, value, null);
        }
    }
    public override int GetHashCode()
    {
        return (this.GetType().Name + Id).GetHashCode();
    }
}

public class DataStore
{
    private static int GetHashCode(Type t, string id)
    {
        return (t.Name + id).GetHashCode();
    }
    private static readonly Dictionary<int, NetworkDataObject> _objectTracker 
        = new Dictionary<int, NetworkDataObject>();
    
    /// <summary>
    /// Retreives an object from a datasource, depending on the availability.
    /// </summary>
    /// <typeparam name="T">Type of object to retreive, must of type NetworkDataObject</typeparam>
    /// <param name="id">The Id for the object to retreive</param>
    /// <param name="callback">A callback to handle the retreived data. Can be null to just queue update from server or heat up data from disk cache.</param>
    public static void Get<T>(string id, Action<T> callback) where T : NetworkDataObject, new()
    {
        // we define event as "get Type", needs to be mapped on server as well
        string eventName = "get " + typeof(T).Name;
        // get unique-ish hash key for object
        int hash = GetHashCode(typeof(T), id);
        // if object was last modified less than a minute ago, return instantly and queue an update
        bool fast = false;
        if (_objectTracker.ContainsKey(hash) && _objectTracker[hash].LastModified > DateTime.UtcNow - TimeSpan.FromMinutes(1))
        {
            if (callback != null)
                callback(_objectTracker[hash] as T);
            fast = true;
        }
        if (CommunicationsApi.IsAvailable)
        {
            // Queue update from server
            CommunicationsApi.Socket.Emit(eventName, id, "/", o =>
            {
                // New object? create empty instance and merge data to it
                if (!_objectTracker.ContainsKey(hash))
                    _objectTracker[hash] = new T();
                _objectTracker[hash].Merge(o);
                // Update Offline Cache, is done async so it doesn't block
                OfflineCache.QueueStore(hash, _objectTracker[hash]);
                if (!fast && callback != null)
                    callback(_objectTracker[hash] as T);

            });
        }
        else
        {
            if (fast) // fast cache but API offline? not our problem for now
                return;
            // Got an object tracked but older than a minute? lets just use it
            if (_objectTracker.ContainsKey(hash))
            {
                if (callback != null)
                    callback(_objectTracker[hash] as T);
            }
            // Attempt to fetch sync from Offline Cache
            var cache = OfflineCache.Fetch(hash);
            if (cache != null)
            {
                _objectTracker[hash] = cache as NetworkDataObject;
                if (callback != null)
                    callback(cache as T);
            }
            else
            {
                if(callback != null)
                    callback(new T()); // returns empty object that is considered unavailable
            }
        }
    }

    public static void List<T>(Action<IEnumerable<T>> callback) where T: NetworkDataObject, new()
    {
        string eventName = "list " + typeof(T).Name;
        int hash = eventName.GetHashCode();
        if (CommunicationsApi.IsAvailable)
        {
            // fetch array with ids, then Get each object (allows us to fetch from local cache instead of sending buttloads of data over net by default)
            CommunicationsApi.Socket.Emit(eventName, null, "/", o =>
            {
                List<T> returns = new List<T>();
                var got = (o as string[]);
                int i = got.Length;
                foreach (var id in got)
                {
                    Get<T>(id, obj =>
                    {
                        returns.Add(obj);
                        i--;
                    });
                }
                while(i != 0)
                    Thread.Sleep(5);
                if (callback != null)
                    callback(returns);
            });
        }
        else
        {
            var cache = OfflineCache.Fetch(hash);
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
                    });
                }
                while (i != 0)
                    Thread.Sleep(5);
                if (callback != null)
                    callback(returns);
            }
            else
            {
                if (callback != null)
                    callback(new T[0]);
            }
        }
    }
}
