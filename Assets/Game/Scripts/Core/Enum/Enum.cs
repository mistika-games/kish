using System.Collections;
using System.Collections.Generic;

namespace Core.Enum
{
    public class Enum<T> : IEnum<T> where T : class, IEnumItem
    {
        private readonly List<T> _items = new();
        private readonly Dictionary<string, T> _idsCache = new();

        public void Add(T item)
        {
            _idsCache.Add(item.Id, item);
            _items.Add(item);
        }

        public int Count => _items.Count;
        public IEnumerable<string> Keys => _idsCache.Keys;

        public int ToIndex(T item)
        {
            return item.Index;
        }

        public bool TryFromIndex(int index, out T item)
        {
            if (index >= 0 && index < Count)
            {
                item = _items[index];
                return true;
            }
            
            item = null;
            return false;
        } 

        public string ToId(T item)
        {
            return item.Id;
        }

        public bool TryFromId(string id, out T item)
        {
            return _idsCache.TryGetValue(id, out item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}