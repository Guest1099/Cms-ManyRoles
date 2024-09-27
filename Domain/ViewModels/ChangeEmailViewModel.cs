using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class ChangeEmailViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }
    }
}
