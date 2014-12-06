using Donatella.Infrastructure.Ioc;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Donatella.Infrastructure.IocRegistry
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.With(new ControllerConvention());
            });
        }
    }
}