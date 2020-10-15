using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace TestVal.Validation
{
    public class TestAttributeAdapter:AttributeAdapterBase<TestAttribute>
    {
        public TestAttributeAdapter(TestAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext) => Attribute.ErrorMessage;

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-test", GetErrorMessage(context));
        }
    }

    public class TestAttributeAdapterProvider:IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider =
            new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is TestAttribute classicMovieAttribute)
            {
                return new TestAttributeAdapter(classicMovieAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}