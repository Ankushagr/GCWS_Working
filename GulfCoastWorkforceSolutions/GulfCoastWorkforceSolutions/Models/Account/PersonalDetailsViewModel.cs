using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Kentico.Membership;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class PersonalDetailsViewModel
    {
        [DisplayName("GulfCoastWorkforceSolutionsMvc.SignIn.EmailUserName")]
        public string UserName { get; set; }


        [DisplayName("GulfCoastWorkforceSolutionsMvc.Register.FirstName")]
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.FirstName.Empty")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Register.LastName.Empty")]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.Register.LastName")]
        [MaxLength(100, ErrorMessage = @"GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string LastName { get; set; }


        public PersonalDetailsViewModel()
        {
            
        }


        public PersonalDetailsViewModel(User user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}