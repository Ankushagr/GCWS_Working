using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using Kentico.Content.Web.Mvc;

using GulfCoastWorkforceSolutions.Models.Contacts;
using GulfCoastWorkforceSolutions.Repositories;

namespace GulfCoastWorkforceSolutions.Models.Cafes
{
    public class CafeViewModel
    {
        public string PhotoPath { get; set; }


        public string Note { get; set; }


        public ContactViewModel Contact { get; set; }


        public static CafeViewModel GetViewModel(Cafe cafe, ICountryRepository countryRepository, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            return new CafeViewModel
            {
                PhotoPath = cafe.Fields.Photo == null ? null : attachmentUrlRetriever.Retrieve(cafe.Fields.Photo).RelativePath,
                Note = cafe.Fields.AdditionalNotes,
                Contact = ContactViewModel.GetViewModel(cafe, countryRepository)
            };
        }
    }
}