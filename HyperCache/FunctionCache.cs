using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace HyperCache
{
    public class FunctionCache  
    {

        protected ObjectCache _cache = MemoryCache.Default; 

        public FunctionCache()
            
        {
            
        }

        public FunctionCache(ObjectCache cache)
        {
            _cache = cache;
        }

        public  TResult Get<TResult>(Func<TResult> func)
        {
            string id = GenerateKey(func.Method.Name,func.Target.GetHashCode());
            TResult val = default(TResult);
            TResult test = default(TResult);
            try
            {
                val = (TResult)_cache[id];
            }
            catch { }
            if (val ==null || val.Equals(test))
            {
                val = func.Invoke();
                _cache[id] = val;
            }
            return val;
        }


        protected string GenerateKey(params object[] p)
        {
            return p.Aggregate<object,string>("",(accu, next) => accu + next.ToString());
        }
        

    }
}
