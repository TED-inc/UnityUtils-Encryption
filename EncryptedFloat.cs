using System;

namespace TEDinc.Utils.Encrition
{
    [Serializable]
    public sealed class EncryptedFloat : EncryptedBasedOnStrings<float> 
    {
        public override bool Equals(object obj) =>
            Get() == (float)obj;

        public override int GetHashCode() =>
            base.GetHashCode();

        public static implicit operator EncryptedFloat(float value) =>
            new EncryptedFloat(value);

        public EncryptedFloat() =>
            Set(0f);
        public EncryptedFloat(float normalInt) : base(normalInt) { }
    }
}