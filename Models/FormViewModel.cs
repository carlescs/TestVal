using System.ComponentModel.DataAnnotations;
using TestVal.Validation;

namespace TestVal.Models{
    public class FormViewModel{
        [Required(ErrorMessage="Hola")]
        [MinLength(5,ErrorMessage="aieee {0} {1}")]
        [Test(ErrorMessage="ccccc")]
        public string Name { get; set; }
    }
}