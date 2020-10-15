using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestVal.Validation{
    public class TestAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = (string) value;
            return val.Count(char.IsUpper) > 3 
                ? ValidationResult.Success 
                : new ValidationResult(ErrorMessage);
        }
    }
}