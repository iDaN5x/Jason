using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Jason.Types
{
    public class JsonArray : JsonElement, IList<JsonElement>, IEquatable<JsonArray>
    {
        private readonly IList<JsonElement> _items;

        public JsonArray()
        {
            _items = new List<JsonElement>();
        }
        
        public JsonArray(IEnumerable<JsonElement> items)
        {
            _items = items.ToList();
        }


        #region implements IList<JsonElement>
        public JsonElement this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }
        
        public IEnumerator<JsonElement> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _items).GetEnumerator();

        public void Add(JsonElement item) => _items.Add(item);

        public void Clear() => _items.Clear();

        public bool Contains(JsonElement item) => _items.Contains(item);

        public void CopyTo(JsonElement[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public bool Remove(JsonElement item) => _items.Remove(item);

        public int Count => _items.Count;

        public bool IsReadOnly => _items.IsReadOnly;

        public int IndexOf(JsonElement item) => _items.IndexOf(item);

        public void Insert(int index, JsonElement item) => _items.Insert(index, item);

        public void RemoveAt(int index) => _items.RemoveAt(index);
        #endregion

        #region implements IEquatable<JsonArray>
        public bool Equals(JsonArray other)
        {
            if (ReferenceEquals(other, null)) return false;
            
            return ReferenceEquals(this, other) || this.Except(other).Any();
        }

        public override bool Equals(object obj)
        {
            var arr = obj as JsonArray;
            return Equals(arr);
        }

        public override int GetHashCode()
        {
            return (_items != null ? _items.GetHashCode() : 0);
        }
        #endregion
    }
}