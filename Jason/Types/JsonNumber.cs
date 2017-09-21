using System;

namespace Jason.Types
{
    public class JsonNumber : JsonElement, IEquatable<JsonNumber>
    {
        public decimal Value { get; }

        public JsonNumber(decimal value = default (decimal))
        {
            Value = value;
        }

        #region implements IEquatable<JsonNumber>
        public bool Equals(JsonNumber other)
        {
            return ReferenceEquals(this, other) || Value == other?.Value;
        }

        public override bool Equals(object obj)
        {
            var number = obj as JsonNumber;
            return Equals(number);
        }

        public override int GetHashCode() => Value.GetHashCode();
        #endregion
        
        #region type conversions
        public static implicit operator JsonNumber(decimal value)
        {
            return new JsonNumber(value);
        }
        
        public static explicit operator decimal(JsonNumber number)
        {
            return number?.Value ?? 
                   throw new ArgumentNullException(nameof(number));
        }
        #endregion
    }
}