using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace TestVal.Util{
    public class TranslatedValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach(var attribute in context.ValidationMetadata.ValidatorMetadata.OfType<ValidationAttribute>()){
                attribute.ErrorMessage= $"{attribute.GetType().Name} - {attribute.ErrorMessage}";
            }
        }
    }
}