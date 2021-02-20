using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HyperCache.CacheProviders;

namespace HyperCache
{
    public class CacheManager
    {
        protected ICache cache;
        protected WorkQueue queue;

        public CacheManager(ICache cache, int maxConcurrent = 10)
        {
            if (cache != null)
                this.cache = cache;
            else
                cache = new ObjectCacheProvider();
            queue = new WorkQueue(cache, maxConcurrent);
        }

        public TResult Process<TResult>(string id, Func<TResult> func, DateTimeOffset absoluteExpiration)
        {
            if (cache[id] != null)
                return (TResult)cache[id];
            else
            {
                queue.Enqueue<TResult>(id, func, absoluteExpiration);
                return default(TResult);
            }

        }
    }
}
