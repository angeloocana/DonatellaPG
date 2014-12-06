using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Donatella.Infrastructure.Adapters
{
    public class MyRequiredAttributeAdapter : RequiredAttributeAdapter
    {
        public MyRequiredAttributeAdapter(
            System.Web.Mvc.ModelMetadata metadata,
            ControllerContext context,
            RequiredAttribute attribute
        )
            : base(metadata, context, attribute)
        {
            //attribute.ErrorMessageResourceType = typeof(MyNewResource);
            //attribute.ErrorMessageResourceName = "PropertyValueRequired";
        }
    }
}