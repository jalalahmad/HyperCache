using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperCache
{
    public class WorkQueue
    {
        public int MaxConcurrency { get; protected set; }
        private LimitedConcurrencyLevelTaskScheduler lcts;
        protected TaskFactory factory;
        protected ICache Cache { get; set; }



        public WorkQueue(ICache cache, int maxConcurrency = 10)
        {
            this.MaxConcurrency = maxConcurrency;
            this.Cache = cache;
            lcts = new LimitedConcurrencyLevelTaskScheduler(this.MaxConcurrency);
            factory = new TaskFactory(lcts);
        }

        public void Enqueue<TResult>(string id, Func<TResult> func, DateTimeOffset absoluteExpiration)
        {
            var task = factory.StartNew(func);
            task.ContinueWith((antecedent) =>
            {
                this.Cache.Set(id, antecedent.Result, absoluteExpiration);
            });
        }
    }
}
