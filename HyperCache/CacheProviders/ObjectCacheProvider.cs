using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace HyperCache.CacheProviders
{
    class ObjectCacheProvider : ICache
    {
        protected MemoryCache cache = MemoryCache.Default;
        #region ICache Members

        public object this[string index]
        {
            get { return cache[index]; }
        }

        public void Set(string id, object value, DateTimeOffset absoluteExpiration)
        {
            cache.Set(new CacheItem(id, value), new CacheItemPolicy { AbsoluteExpiration = absoluteExpiration });
        }

        #endregion


    }

}
