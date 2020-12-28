using System.Collections.Generic;
using System.Linq;

namespace PropNotify.Core
{
    public static class ListExtension
    {
        public static void AddOrUpdate<T>(this List<T> sourceList, T newItem)
        {
            if (sourceList.Any(a => a.Equals(newItem)))
                sourceList.Remove(newItem);
            sourceList.Add(newItem);
        }
    }
}
