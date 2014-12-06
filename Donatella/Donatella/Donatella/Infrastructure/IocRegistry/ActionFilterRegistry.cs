using System;
using System.Web.Mvc;
using Donatella.Infrastructure.Ioc;
using Donatella.Models.Enums;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace Donatella.Infrastructure.IocRegistry
{
    public class ActionFilterRegistry : Registry
    {
        public ActionFilterRegistry(Func<IContainer> containerFactory)
        {
            For<IFilterProvider>().Use(new StructureMapFilterProvider(containerFactory));

            Policies.SetAllProperties(x => x.Matching(p =>
                (
                    p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) //ActionFilter normal
                    || p.DeclaringType.CanBeCastTo(typeof(AuthorizeAttribute))) //ActionFilter API
                && p.DeclaringType.Namespace.StartsWith("Donatella")
                && !p.PropertyType.IsPrimitive
                && p.PropertyType != typeof(string)
                && p.PropertyType != typeof(Permissoes)));
        }
    }
}