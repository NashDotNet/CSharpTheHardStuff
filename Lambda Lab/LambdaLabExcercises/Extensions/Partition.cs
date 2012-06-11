using System.Collections.Generic;

namespace System.Linq
{
    // @hammett: "Linq doesn't have a Partition operation that returns two sets? (filtered/complement).. sad!"

    // GroupBy can be seen as a partition. We specialize it to have exactly two groups:
    
    public static class PartitionExtension
    {
        public static Tuple<IEnumerable<T>, IEnumerable<T>> Partition<T>(
            this IEnumerable<T> enumeration, 
            Func<T, bool> criteria)
        {
            IEnumerable<IGrouping<bool, T>> whole = enumeration.GroupBy(criteria);

            return new Tuple<IEnumerable<T>, IEnumerable<T>>(
                whole.Where(x => x.Key).SelectMany(x => x),
                whole.Where(x => !x.Key).SelectMany(x => x));
        }
    }
}