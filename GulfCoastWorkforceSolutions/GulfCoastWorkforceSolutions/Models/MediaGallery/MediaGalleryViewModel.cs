using System.Collections.Generic;

namespace GulfCoastWorkforceSolutions.Models.MediaGallery
{
    public class MediaGalleryViewModel
    {
        public string MediaGalleryName { get; set; }
        public IEnumerable<MediaFileViewModel> MediaFiles { get; set; } = new List<MediaFileViewModel>();


        public MediaGalleryViewModel(string mediaGalleryName)
        {
            MediaGalleryName = mediaGalleryName;
        }
    }
}