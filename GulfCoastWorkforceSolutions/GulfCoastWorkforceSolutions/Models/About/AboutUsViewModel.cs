using System.Collections.Generic;

using GulfCoastWorkforceSolutions.Models.References;

namespace GulfCoastWorkforceSolutions.Models.About
{
    public class AboutUsViewModel
    {
        public IEnumerable<AboutUsSectionViewModel> Sections { get; set; }

        public ReferenceViewModel Reference {get; set;}
    }
}