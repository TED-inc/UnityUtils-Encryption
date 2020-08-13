namespace TEDinc.Utils.Encrition
{
    public interface IEncrypted<T>
    {
        void Set(T value);
        T Get();
    }
}
