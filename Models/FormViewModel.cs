using System.ComponentModel.DataAnnotations;
using TestVal.Validation;

namespace TestVal.Models{
    public class FormViewModel{
        [Required(ErrorMessage = "hello")]
        [MinLength(5,ErrorMessage="aieee {0} {1}")]
        [Test(3,ErrorMessage="second")]
        public string Name { get; set; }

        [Required(ErrorMessage = "aieee")]
        [Test(5)]
        public string Password { get; set; }
    }
}