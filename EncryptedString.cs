using System;

namespace TEDinc.Utils.Encrition
{
    [Serializable]
    public sealed class EncryptedString : EncryptedBasedOnStrings<string>
    {
        public override bool Equals(object obj) =>
            Get() == (string)obj;

        public override int GetHashCode() =>
            base.GetHashCode();

        public static implicit operator EncryptedString(string value) =>
            new EncryptedString(value);

        public EncryptedString() =>
            Set("");
        public EncryptedString(string value) : base(value) { }
    }
}
