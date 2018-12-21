using JsonResourceLocalizer.Constants;
using System.ComponentModel.DataAnnotations;

namespace JsonResourceLocalizer.ViewModels
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = DataAnnotationKeys.Required)]
        public string Id { get; set; }

        [Required(ErrorMessage = DataAnnotationKeys.Required)]
        [MaxLength(50, ErrorMessage = DataAnnotationKeys.MaxLength)]
        public string Name { get; set; }
        [Required(ErrorMessage = DataAnnotationKeys.Required)]
        [MaxLength(5,ErrorMessage = DataAnnotationKeys.MaxLength)]
        public string RollNo { get; set; }        
    }
}
