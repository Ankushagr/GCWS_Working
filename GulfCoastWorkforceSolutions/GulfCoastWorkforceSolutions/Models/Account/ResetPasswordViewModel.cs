using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class ResetPasswordViewModel
    {
        public int UserId { get; set; }


        public string Token { get; set; }


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
    }
}