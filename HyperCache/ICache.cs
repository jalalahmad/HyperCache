using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperCache
{
    public interface ICache
    {
        object this[string index] { get; }
        void Set(string id, object value, DateTimeOffset absoluteExpiration);
    }
}
