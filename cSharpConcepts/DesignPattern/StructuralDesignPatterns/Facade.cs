using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern.StructuralDesignPatterns
{
    // Facade - Provides a simplified interface to complex classes, libraries
    public class MemoryCacheFacade
    {
        private MemoryCache _memoryCache;
        public MemoryCacheFacade(MemoryCacheOptions memoryCacheOptions)
        {
            _memoryCache = new MemoryCache(memoryCacheOptions);
        }
        public void Set<TItem>(object key, TItem value)
        {
            _memoryCache.Set(key, value);
        }
        public bool TryGetValue<TItem>(object key, out TItem result)
        {
            if (_memoryCache.TryGetValue(key, out result))
            {
                return true;
            }

            return false;
        }
        public ICacheEntry CreateEntry(object key)
        {
            return _memoryCache.CreateEntry(key);
        }
    }
}
