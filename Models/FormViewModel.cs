using System.ComponentModel.DataAnnotations;
using TestVal.Validation;

namespace TestVal.Models{
    public class FormViewModel{
        [Required(ErrorMessage="Name is required")]
        [MinLength(5,ErrorMessage="aieee {0} {1}")]
        [Test(3,ErrorMessage="Need more vals")]
        public string Name { get; set; }

        [Required]
        [Test(5)]
        public string Password { get; set; }
    }
}