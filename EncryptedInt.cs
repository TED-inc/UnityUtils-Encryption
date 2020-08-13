using System;
using UnityEngine;
using TEDinc.Utils.MathExt.Rand;

namespace TEDinc.Utils.Encrition
{
    [Serializable]
    public sealed class EncryptedInt : IEncrypted<int>
    {
        [SerializeField]
        private int valueEcrypted;
        [SerializeField]
        private int key;

        public void Set(int value)
        {
            key = RandomExt.Random.Next(int.MinValue, int.MaxValue);
            valueEcrypted = value ^ key;
        }

        public int Get() =>
            valueEcrypted ^ key;


        public override bool Equals(object obj) =>
            Get() == (int)obj;

        public override int GetHashCode() =>
            base.GetHashCode();

        public override string ToString() =>
            Get().ToString();

        public static implicit operator int(EncryptedInt ecrypted) =>
            ecrypted.Get();

        public static implicit operator EncryptedInt(int value) =>
            new EncryptedInt(value);


        public EncryptedInt() =>
            Set(0);
        public EncryptedInt(int value) =>
            Set(value);
    }
}