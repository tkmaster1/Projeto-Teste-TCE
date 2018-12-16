namespace Livraria.Application.Interface.Base
{
    public interface IBaseApplicationService
    {
        void BeginTransaction();
        void Commit();
    }
}
