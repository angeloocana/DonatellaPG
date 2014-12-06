using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace Donatella.Infrastructure.Ioc
{
    public class StructureMapDependecyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapDependecyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            var container = _containerFactory();

            return serviceType.IsAbstract || serviceType.IsInterface
                ? container.TryGetInstance(serviceType)
                : container.GetInstance(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _containerFactory().GetAllInstances(serviceType).Cast<object>();
        }
    }
}