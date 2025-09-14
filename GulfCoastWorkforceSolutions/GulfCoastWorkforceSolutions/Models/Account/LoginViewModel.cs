using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.SignIn.EmailUserName.Empty")]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.SignIn.EmailUserName")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.SignIn.Password")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string Password { get; set; }


        [DisplayName("GulfCoastWorkforceSolutionsMvc.SignIn.StaySignedIn")]
        public bool StaySignedIn { get; set; }
    }
}