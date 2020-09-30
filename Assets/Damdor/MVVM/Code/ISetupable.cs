namespace Damdor.MVVM
{
    public interface ISetupable<T>
    {
        void Setup(T model);
    }
}