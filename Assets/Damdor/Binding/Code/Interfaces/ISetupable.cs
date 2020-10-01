namespace Damdor.Binding
{
    public interface ISetupable<T>
    {
        void Setup(T model);
    }
}