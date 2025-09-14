using System.Collections.Generic;

using GulfCoastWorkforceSolutions.Models.Contacts;

namespace GulfCoastWorkforceSolutions.Models.Cafes
{
    public class IndexViewModel
    {
        public IEnumerable<CafeViewModel> CompanyCafes { get; set; }


        public Dictionary<string, List<ContactViewModel>> PartnerCafes { get; set; }
    }
}