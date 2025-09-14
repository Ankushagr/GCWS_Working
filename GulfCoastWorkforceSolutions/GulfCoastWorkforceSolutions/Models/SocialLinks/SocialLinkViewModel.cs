using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.SocialLinks
{
    public class SocialLinkViewModel
    {
        public string Url { get; set; }


        public string IconPath { get; set; }


        public string Title { get; set; }


        public static SocialLinkViewModel GetViewModel(SocialLink link, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            return new SocialLinkViewModel
            {
                Url = link.Fields.Url,
                Title = link.Fields.Title,
                IconPath = attachmentUrlRetriever.Retrieve(link.Fields.Icon).RelativePath
            };
        }
    }
}