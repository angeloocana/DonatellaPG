using System.Web.Mvc;
using Donatella.Infrastructure.ModelMetadata;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Donatella.Infrastructure.IocRegistry
{
    public class ModelMetadataRegistry : Registry
    {
        public ModelMetadataRegistry()
        {
            For<ModelMetadataProvider>().Use<ExtensibleModelMetadataProvider>();
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IModelMetadataFilter>();
            });
        }
    }
}