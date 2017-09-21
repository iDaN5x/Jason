using System;

namespace Jason.Types
{
    public abstract class JsonElement
    {
        #region type conversions
        public static implicit operator JsonElement(decimal value)
        {
            return new JsonNumber(value);
        }

        public static explicit operator decimal(JsonElement element)
        {
            var number = element as JsonNumber;

            return number?.Value ??
                   throw new InvalidCastException();
        }
        
        public static implicit operator JsonElement(string value)
        {
            return new JsonString(value);
        }

        public static explicit operator string(JsonElement element)
        {
            var number = element as JsonString;

            return number?.Value ??
                   throw new InvalidCastException();
        }
        
        public static implicit operator JsonElement(bool value)
        {
            return new JsonBoolean(value);
        }

        public static explicit operator bool(JsonElement element)
        {
            var number = element as JsonBoolean;

            return number?.Value ??
                   throw new InvalidCastException();
        }
        #endregion
    }
}