using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infra.Repositories.EF
{
    public class ContextManager
    {
        private const string ContextKey = "Infra.Repositories.EF.ContextManager.Context";
        public DbContext Context
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new EFDbContext();
                }

                return (EFDbContext)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
