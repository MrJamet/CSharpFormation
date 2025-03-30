public sealed class MemoryCache
{
    private Dictionary<string, object> _cachedObjects;
    private static Lazy<MemoryCache> _cache = new (() => new()); //le premier new pour le lazy, le second pour le memoryCache
    public static MemoryCache Instance => _cache.Value;
    private MemoryCache()
    {
        _cachedObjects = new();
    }

    public void Add(string key, object value) => _cachedObjects[key] = value;
    public object? Get(string key)
    {
        if(_cachedObjects.ContainsKey(key)) return _cachedObjects[key];        
        return null;
    }
}