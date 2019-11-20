using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(
            this IEnumerable<T> source, uint EnumerableExtensions)
        {
            using (var enumerator = source.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return YieldBatchElements(enumerator, EnumerableExtensions - 1);
        }

        private static IEnumerable<T> YieldBatchElements<T>(
            IEnumerator<T> source, uint batchSize)
        {
            yield return source.Current;
            for (uint i = 0; i < batchSize && source.MoveNext(); i++)
                yield return source.Current;
        }

        public static async Task EachWithIndexAsync<T>(this IEnumerable<T> collection, Func<T, uint, Task> action)
        {
            uint index = 0;
            foreach (var item in collection)
            {
                await action(item, index++);
            }
        }

        public static void EachWithIndex<T>(this IEnumerable<T> collection, Action<T, uint> action)
        {
            uint index = 0;
            foreach (var item in collection)
            {
                action(item, index++);
            }
        }

        public static IEnumerable<T> DistinctBy<T, T2>(this IEnumerable<T> collection, Func<T, T2> selector)
        {
            HashSet<T2> seen = new HashSet<T2>();
            foreach (var t in collection)
            {
                T2 hashCode = selector(t);
                if (!seen.Contains(hashCode))
                {
                    seen.Add(hashCode);
                    yield return t;
                }
            }
        }
        
        public static void ConsecutiveSortOrder<T>(this IEnumerable<T> items, Action<T, uint> sortOrderSetter)
        {
            uint current = 0;
            foreach (T item in items)
            {
                sortOrderSetter(item, current++);
            }
        }
        
        public static IEnumerable<T> Compact<T>(this IEnumerable<T> source)
        {
            return source.Where(item => item != null);
        }

    }
}