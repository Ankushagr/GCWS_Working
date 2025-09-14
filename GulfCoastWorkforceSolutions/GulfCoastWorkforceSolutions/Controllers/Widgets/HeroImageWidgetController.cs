using System;
using System.Linq;
using System.Web.Mvc;

using CMS.MediaLibrary;
using CMS.SiteProvider;

using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

using GulfCoastWorkforceSolutions.Controllers.Widgets;
using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Models.Widgets;
using GulfCoastWorkforceSolutions.Repositories;

[assembly: RegisterWidget(HeroImageWidgetController.IDENTIFIER, typeof(HeroImageWidgetController), "{$GulfCoastWorkforceSolutionsmvc.widget.heroimage.name$}", Description = "{$GulfCoastWorkforceSolutionsmvc.widget.heroimage.description$}", IconClass = "icon-badge")]

namespace GulfCoastWorkforceSolutions.Controllers.Widgets
{
    /// <summary>
    /// Controller for hero image widget.
    /// </summary>
    public class HeroImageWidgetController : WidgetController<HeroImageWidgetProperties>
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "GulfCoastWorkforceSolutions.LandingPage.HeroImage";


        private readonly IMediaFileRepository mediaFileRepository;
        private readonly IOutputCacheDependencies outputCacheDependencies;
        private readonly IComponentPropertiesRetriever componentPropertiesRetriever;
        private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;


        /// <summary>
        /// Creates an instance of <see cref="BannerWidgetController"/> class.
        /// </summary>
        public HeroImageWidgetController(
            IMediaFileRepository mediaFileRepository, 
            IOutputCacheDependencies outputCacheDependencies,
            IComponentPropertiesRetriever componentPropertiesRetriever,
            IMediaFileUrlRetriever mediaFileUrlRetriever)
        {
            this.mediaFileRepository = mediaFileRepository;
            this.outputCacheDependencies = outputCacheDependencies;
            this.componentPropertiesRetriever = componentPropertiesRetriever;
            this.mediaFileUrlRetriever = mediaFileUrlRetriever;
        }


        public ActionResult Index()
        {
            var properties = componentPropertiesRetriever.Retrieve<HeroImageWidgetProperties>();
            var image = GetImage(properties);

            outputCacheDependencies.AddDependencyOnInfoObject<MediaFileInfo>(image?.FileGUID ?? Guid.Empty);

            return PartialView("Widgets/_HeroImageWidget", new HeroImageWidgetViewModel
            {
                ImagePath = image == null ? null : mediaFileUrlRetriever.Retrieve(image).RelativePath,
                Text = properties.Text,
                ButtonText = properties.ButtonText,
                ButtonTarget = properties.ButtonTarget,
                Theme = properties.Theme
            });
        }


        private MediaFileInfo GetImage(HeroImageWidgetProperties properties)
        {
            var imageGuid = properties.Image.FirstOrDefault()?.FileGuid ?? Guid.Empty;
            if (imageGuid == Guid.Empty)
            {
                return null;
            }

            return mediaFileRepository.GetMediaFile(imageGuid, SiteContext.CurrentSiteID);
        }
    }
}