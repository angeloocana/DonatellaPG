using System;
using System.Web.Http;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace Donatella.Infrastructure.Ioc
{
    public class ControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if ((type.CanBeCastTo(typeof(Controller)) || type.CanBeCastTo(typeof(ApiController))) && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}