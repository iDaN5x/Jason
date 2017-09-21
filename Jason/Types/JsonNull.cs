using System;

namespace Jason.Types
{
    public class JsonNull : JsonElement, IEquatable<JsonNull>
    {
        public object Value { get; } = null;

        public static JsonNull Instance { get; }

        static JsonNull()
        {
            Instance = new JsonNull();
        }

        #region implements IEquatable<JsonNull>
        public bool Equals(JsonNull other)
        {
            return !ReferenceEquals(other, null);
        }

        public override bool Equals(object obj)
        {
            var nul = obj as JsonNull;
            return Equals(nul);
        }

        public override int GetHashCode() => 0;
        #endregion
    }
}