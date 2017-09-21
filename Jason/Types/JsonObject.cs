using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Jason.Types
{
    public class JsonObject : JsonElement, IDictionary<string, JsonElement>, IEquatable<JsonObject>
    {
        private readonly IDictionary<string, JsonElement> _fields;

        public JsonObject()
        {
            _fields = new Dictionary<string, JsonElement>();
        }
        
        public JsonObject(IDictionary<string, JsonElement> fields)
        {
            _fields = new Dictionary<string, JsonElement>(fields);
        }

        #region implements IDictionary<string, JsonElement>
        public JsonElement this[string key]
        {
            get => _fields[key];
            set => _fields[key] = value;
        }
        
        public IEnumerator<KeyValuePair<string, JsonElement>> GetEnumerator()
        {
            return _fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _fields).GetEnumerator();
        }

        public void Add(KeyValuePair<string, JsonElement> item) => _fields.Add(item);

        public void Clear() => _fields.Clear();

        public bool Contains(KeyValuePair<string, JsonElement> item) => _fields.Contains(item);

        public void CopyTo(KeyValuePair<string, JsonElement>[] array, int arrayIndex)
        {
            _fields.CopyTo(array, arrayIndex);  
        } 

        public bool Remove(KeyValuePair<string, JsonElement> item) => _fields.Remove(item);

        public int Count => _fields.Count;

        public bool IsReadOnly => _fields.IsReadOnly;

        public void Add(string key, JsonElement value) => _fields.Add(key, value);

        public bool ContainsKey(string key) => _fields.ContainsKey(key);

        public bool Remove(string key) => _fields.Remove(key);

        public bool TryGetValue(string key, out JsonElement value)
        {
            return _fields.TryGetValue(key, out value);
        }

        public ICollection<string> Keys => _fields.Keys;

        public ICollection<JsonElement> Values => _fields.Values;

        #endregion

        #region implements IEquatable<JsonObject>
        public bool Equals(JsonObject other)
        {
            if (ReferenceEquals(other, null)) return false;

            return ReferenceEquals(this, other) || this.Except(other).Any();
        }

        public override bool Equals(object obj)
        {
            var jsonObj = obj as JsonObject;
            return Equals(jsonObj);
        }

        public override int GetHashCode()
        {
            return (_fields != null ? _fields.GetHashCode() : 0);
        }
        #endregion
    }
}