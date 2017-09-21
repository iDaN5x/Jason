using System;

namespace Jason.Types
{
    public class JsonString : JsonElement, IEquatable<JsonString>
    {
        public string Value { get; }

        public JsonString(string value = default (string))
        {
            Value = value;
        }

        #region implements IEquatable<JsonString>
        public bool Equals(JsonString other)
        {
            return ReferenceEquals(this, other) || Value == other?.Value;
        }

        public override bool Equals(object obj)
        {
            var str = obj as JsonString;
            return Equals(str);
        }

        public override int GetHashCode() => Value.GetHashCode();
        #endregion
        
        #region type conversions
        public static implicit operator JsonString(string value)
        {
            return new JsonString(value);
        }
        
        public static explicit operator string(JsonString str)
        {
            return str.Value ??
                   throw new ArgumentNullException(nameof(str));
        }
        #endregion
    }
}