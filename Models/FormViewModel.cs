using System.ComponentModel.DataAnnotations;

namespace TestVal.Models{
    public class FormViewModel{
        [Required(ErrorMessage="Hola")]
        [MinLength(5,ErrorMessage="aieee {0} {1}")]
        public string Name { get; set; }
    }
}