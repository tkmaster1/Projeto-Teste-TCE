using Livraria.Application.Interface;
using Livraria.Application.Services;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Repository.Base;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Interfaces.Services.Base;
using Livraria.Domain.Services;
using Livraria.Domain.Services.Base;
using Livraria.Infrastructure.Data.Context;
using Livraria.Infrastructure.Data.Interfaces;
using Livraria.Infrastructure.Data.Repositories;
using Livraria.Infrastructure.Data.Repositories.Base;
using Livraria.Infrastructure.Data.UoW;
using Ninject.Modules;

namespace Livraria.Infrastructure.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            #region Application

            Bind<ILivroApplicationService>().To<LivroApplicationService>();

            #endregion

            #region Domain Service

            Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            Bind<ILivroService>().To<LivroService>();

            #endregion

            #region Repository

            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ILivroRepository>().To<LivroRepository>();

            #endregion
        }
    }
}
