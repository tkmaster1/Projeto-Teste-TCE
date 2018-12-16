using Livraria.Application.Interface.Base;
using Livraria.Infrastructure.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace Livraria.Application.Base
{
    public class BaseApplicationService : IBaseApplicationService
    {
        private IUnitOfWork _uow;

        public BaseApplicationService()
        {
        }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
