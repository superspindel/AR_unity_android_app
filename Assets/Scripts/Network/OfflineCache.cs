using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OfflineCache {

    private static readonly Dictionary<int, string> _fakeOfflineCache = new Dictionary<int, string>();

    public static void QueueStore(int hash, object obj)
    {
        // TODO: actual offline storage
        _fakeOfflineCache[hash] = SimpleJson.SimpleJson.SerializeObject(obj);
    }

    public static T Fetch<T>(int hash)
    {
        // TODO: actual offline storage
        return SimpleJson.SimpleJson.DeserializeObject<T>(_fakeOfflineCache[hash]);
    }

    public static void Purge(int hash)
    {
        _fakeOfflineCache.Remove(hash);
    }
}
