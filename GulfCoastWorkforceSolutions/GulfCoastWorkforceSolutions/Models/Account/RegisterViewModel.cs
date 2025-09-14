using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Kentico.Membership;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.EmailUserName.Empty")]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.Register.EmailUserName")]
        [EmailAddress(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.InvalidEmail")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.Register.Password")]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.Password.Empty")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.Register.PasswordConfirmation")]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.PasswordConfirmation.Empty")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        [Compare("Password", ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.PasswordConfirmation.Invalid")]
        public string PasswordConfirmation { get; set; }


        [DisplayName("GulfCoastWorkforceSolutionsMvc.FirstName")]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.FirstName.Empty")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string FirstName { get; set; }


        [DisplayName("GulfCoastWorkforceSolutionsMvc.LastName")]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.LastName.Empty")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string LastName { get; set; }
    }
}