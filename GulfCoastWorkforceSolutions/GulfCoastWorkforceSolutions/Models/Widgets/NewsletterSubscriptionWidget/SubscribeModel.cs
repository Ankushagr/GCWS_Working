using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GulfCoastWorkforceSolutions.Models.Widgets
{
    public class SubscribeModel
    {
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Email.Required")]
        [EmailAddress(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.InvalidEmail")]
        [DisplayName("GulfCoastWorkforceSolutionsMvc.News.SubscriberEmail")]
        [MaxLength(250, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.News.LongEmail")]
        public string Email { get; set; }
    }
}