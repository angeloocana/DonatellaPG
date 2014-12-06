using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Pol.Infrastructure.IocRegistry
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}