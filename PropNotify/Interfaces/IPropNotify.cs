using System;
using System.Collections.Generic;
using PropNotify.Core;

namespace PropNotify.Interfaces
{
    public interface IPropNotify<T> where T : IEquatable<T>
    {
        void OnNotify(T obj, string triggeredBy);
        List<ActionHolder<T>> Actions { get; set; }
        List<Dictionary<string, T>> Notifications { get; set; }
    }
}
