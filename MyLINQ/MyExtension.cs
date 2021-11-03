using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQ
{
    public static class Enumerablee
    {
        public static IEnumerable<TResult> SelecteExt<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException();
            var callection​ = new TResult[source.Count()];
            int i = 0;
            foreach (var s in source)
            {
                callection[i++] = selector(s);
            }
            return callection;
        }

        public static IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            var callection = new List<TSource>();
            int i = 0;
            foreach (var s in source)
            {
                if (predicate(s))
                    callection.Add(s);
            }
            return callection;
        }

        public static List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            List<TSource> List = new List<TSource>();
            foreach (var i in source)
                List.Add(i);
            return List;
        }

        public static Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException();
            if (keySelector == null) throw new ArgumentNullException();

            var DictionaryList = new Dictionary<TKey, TSource>();
            foreach (var s in source)
            {
                DictionaryList.Add(keySelector(s), s);
            }
            return DictionaryList;
        }
        public static IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException();
            if (keySelector == null) throw new ArgumentNullException();

            var DictionaryList = new SortedList<TKey, TSource>();

            foreach (var s in source)
            {
                DictionaryList.Add(keySelector(s), s);
            }

            return new MyOrderedEnumerable<TKey, TSource>(DictionaryList.Values);
        }

        public static IOrderedEnumerable<TSource> OrderByDescExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException();
            if (keySelector == null) throw new ArgumentNullException();

            var DictionaryList = new SortedList<TKey, TSource>();
            foreach (var s in source)
            {
                DictionaryList.Add(keySelector(s), s);
            }
            var descList = new List<TSource>();
            for (int i = DictionaryList.Count - 1; i >= 0; i--)
            {
                descList.Add(DictionaryList.Values[i]);
            }
            return new MyOrderedEnumerable<TKey, TSource>(descList);
        }


        public static IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null ) throw new ArgumentNullException();
            if (keySelector == null) throw new ArgumentNullException();
            List<TKey> KeyList = new List<TKey>();
            Dictionary<TKey, List<TSource>> ContDictonory = new Dictionary<TKey, List<TSource>>();

            foreach (TSource s in source)
            {
                TKey key = keySelector(s);
                if (!ContDictonory.ContainsKey(key))
                {
                    ContDictonory.Add(key, new List<TSource> { s });
                    KeyList.Add(key);
                }
                else
                {
                    ContDictonory[key].Add(s);
                }
            }

            foreach (var key in KeyList)
            {
                yield return new MyGroupingEnumerable<TKey, TSource>(key, ContDictonory[key]);
            }
        }
    }
}
