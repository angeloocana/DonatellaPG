namespace Domain.Interfaces
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
