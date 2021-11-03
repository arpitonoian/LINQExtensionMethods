using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQ
{
    public class MyOrderedEnumerable<TKey, TSource> : IOrderedEnumerable<TSource>
    {
        private IEnumerable<TSource> list;
        public MyOrderedEnumerable(IEnumerable<TSource> source)
        {
            list = source;
        }

        IOrderedEnumerable<TSource> IOrderedEnumerable<TSource>.CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<TSource> GetEnumerator() { return list.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}

