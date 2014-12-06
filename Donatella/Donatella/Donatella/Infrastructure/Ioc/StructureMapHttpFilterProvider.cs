using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using StructureMap;
using System.Web.Http.Filters;

namespace Donatella.Infrastructure.Ioc
{
    public class StructureMapHttpFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly Func<IContainer> _container;

        public StructureMapHttpFilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);
            var container = _container();

            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}