using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class RetrievePasswordViewModel
    {
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.PasswordReset.Email.Empty")]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.PasswordReset.Email")]
        [EmailAddress(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.InvalidEmail")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string Email { get; set; }
    }
}