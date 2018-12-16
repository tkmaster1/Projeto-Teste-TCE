using Livraria.Infrastructure.Data.Interfaces;
using System.Data.Entity;
using System.Web;

namespace Livraria.Infrastructure.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public DbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new modeloContext();
            }

            return (DbContext)HttpContext.Current.Items[ContextKey];
        }
    }

    public static class DatabaseManager
    {
        private const string ContextKey = "ContextManager.Context";
        public static DbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new modeloContext();
            }

            return (DbContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
