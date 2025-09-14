using System.Collections.Generic;

namespace GulfCoastWorkforceSolutions.Models.Contacts
{
    public class IndexViewModel
    {
        public ContactViewModel CompanyContact { get; set; }


        public List<ContactViewModel> CompanyCafes { get; set; }
    }
}