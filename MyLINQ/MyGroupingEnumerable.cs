using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQ
{
    class MyGroupingEnumerable<TKey, TSource> : IGrouping<TKey, TSource>
    {
        private TKey key;
        private IEnumerable<TSource> elements;
        public TKey Key { get => key; }
        public List<TKey> KeyList { get; }
        public Dictionary<TKey, List<TSource>>.ValueCollection Values { get; }

        public MyGroupingEnumerable(TKey tkey, IEnumerable<TSource> telements)
        {
            key = tkey;
            elements = telements;
        }

        public MyGroupingEnumerable(List<TKey> keyList, Dictionary<TKey, List<TSource>>.ValueCollection values)
        {
            KeyList = keyList;
            Values = values;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
