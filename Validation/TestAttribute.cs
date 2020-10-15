using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestVal.Validation{
    public class TestAttribute : ValidationAttribute
    {
        public int NumUpper { get; }

        public TestAttribute(int numUpper)
        {
            NumUpper = numUpper;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = (string) value;
            return val.Count(char.IsUpper) >= NumUpper
                ? ValidationResult.Success 
                : new ValidationResult(ErrorMessage);
        }
    }
}