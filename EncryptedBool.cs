using System;
using UnityEngine;
using TEDinc.Utils.MathExt.Rand;

namespace TEDinc.Utils.Encrition
{
    [Serializable]
    public sealed class EncryptedBool : IEncrypted<bool> 
    {
        [SerializeField]
        private int valueEcrypted;
        [SerializeField]
        private int key;

        public void Set(bool value)
        {
            key = RandomExt.Random.Next(int.MinValue, int.MaxValue);
            int valueInt = RandomExt.Random.Next(0, int.MaxValue / 3) * 2 + (value ? 1 : 0);
            valueEcrypted = valueInt ^ key;
        }

        public bool Get() =>
            ((valueEcrypted ^ key) % 2) == 1;

        public override bool Equals(object obj) =>
            Get() == (bool)obj;

        public override int GetHashCode() =>
            base.GetHashCode();
        public override string ToString() =>
            Get().ToString();

        public static implicit operator bool(EncryptedBool ecrypted) =>
            ecrypted.Get();

        public static implicit operator EncryptedBool(bool value) =>
            new EncryptedBool(value);

        public EncryptedBool() =>
                Set(false);
        public EncryptedBool(bool value) =>
            Set(value);
    }
}
