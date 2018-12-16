using System.Data.Entity;

namespace Livraria.Infrastructure.Data.Interfaces
{
    public interface IContextManager
    {
        DbContext GetContext();
    }
}
