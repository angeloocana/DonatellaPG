using Donatella.App.Concrete;
using Donatella.App.Interface;
using StructureMap.Configuration.DSL;

namespace Donatella.Infrastructure.IocRegistry
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}