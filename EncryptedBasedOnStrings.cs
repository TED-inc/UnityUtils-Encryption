using System;
using UnityEngine;
using TEDinc.Utils.Json;

namespace TEDinc.Utils.Encrition
{
    [Serializable]
    public abstract class EncryptedBasedOnStrings<T> : IEncrypted<T>
    {
        [SerializeField]
        protected string valueEcrypted;
        [SerializeField]
        protected string key;

        public virtual void Set(T obj) =>
            valueEcrypted = EncryptUtils.EncryptString(obj.ToString(), out key);
        public virtual T Get() =>
            JsonHelper.FromJson<T>(EncryptUtils.DecryptString(valueEcrypted, key));

        public override abstract bool Equals(object obj);

        public override int GetHashCode() =>
            base.GetHashCode();

        public override string ToString() =>
            Get().ToString();

        public static implicit operator T(EncryptedBasedOnStrings<T> ecrypted) =>
            ecrypted.Get();



        public EncryptedBasedOnStrings() { }

        public EncryptedBasedOnStrings(T obj) =>
            Set(obj);
    }
}