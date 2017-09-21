using System;

namespace Jason.Types
{
    public class JsonBoolean : JsonElement, IEquatable<JsonBoolean>
    {
        public bool Value { get; }

        public JsonBoolean(bool value = default(bool))
        {
            Value = value;
        }

        #region implements IEquatable<JsonBoolean>
        public bool Equals(JsonBoolean other)
        {
            return ReferenceEquals(this, other) || Value == other?.Value;
        }

        public override bool Equals(object obj)
        {
            var boolean= obj as JsonBoolean;
            return Equals(boolean);
        }

        public override int GetHashCode() => Value.GetHashCode();
        #endregion
        
        #region type conversions
        public static implicit operator JsonBoolean(bool value)
        {
            return new JsonBoolean(value);
        }

        public static explicit operator bool(JsonBoolean boolean)
        {
            return boolean?.Value ??
                   throw new ArgumentNullException(nameof(boolean));
        }
        #endregion
    }
}