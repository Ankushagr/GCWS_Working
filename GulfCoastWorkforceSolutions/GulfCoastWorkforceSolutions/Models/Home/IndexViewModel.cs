using System.Collections.Generic;
using GulfCoastWorkforceSolutions.Models.References;

namespace GulfCoastWorkforceSolutions.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<HomeSectionViewModel> HomeSections { get; set; }

        public ReferenceViewModel Reference { get; set; }
    }
}