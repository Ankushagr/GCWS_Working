using Kentico.Membership;

namespace GulfCoastWorkforceSolutions.Models.Account
{
    public class YourAccountViewModel
    {
        public User User { get; set; }

        public bool AvatarUpdateFailed { get; set; }
    }
}