using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OfflineCache {

    private static readonly Dictionary<int, string> FakeOfflineCache = new Dictionary<int, string>();

    public static void QueueStore(int hash, object obj)
    {
        // TODO: actual offline storage
        FakeOfflineCache[hash] = SimpleJson.SimpleJson.SerializeObject(obj);
    }

    public static T Fetch<T>(int hash)
    {
        // TODO: actual offline storage
        try
        {
            return SimpleJson.SimpleJson.DeserializeObject<T>(FakeOfflineCache[hash]);
        }
        catch (Exception)
        {
            return default(T);
        }
    }

    public static void Purge(int hash)
    {
        FakeOfflineCache.Remove(hash);
    }
}
