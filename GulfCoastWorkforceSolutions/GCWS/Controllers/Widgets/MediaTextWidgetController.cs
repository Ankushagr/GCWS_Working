using CMS.Core;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using GCWS.Controllers.Widgets;
using GCWS.Infrastructure;
using GCWS.Models.Widgets;
using GCWS.Repositories;
using GCWS.Repositories.Implementation;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget(MediaTextWidgetController.IDENTIFIER, typeof(MediaTextWidgetController), "Media Text Widget", Description = "{GCWS.widget.MediaText.description$}", IconClass = "icon-ribbon")]

namespace GCWS.Controllers.Widgets
{
    public class MediaTextWidgetController : WidgetController<MediaTextWidgetProperties>
    {
        public const string IDENTIFIER = "GCWS.MediaText";
        // GET: MediaTextWidget
        private readonly IMediaFileRepository mediaFileRepository;
        private readonly IOutputCacheDependencies outputCacheDependencies;
        private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;
        private readonly IComponentPropertiesRetriever componentPropertiesRetriever;

        public MediaTextWidgetController(IMediaFileRepository mediaFileRepository, IOutputCacheDependencies outputCacheDependencies, IMediaFileUrlRetriever mediaFileUrlRetriever,
            IComponentPropertiesRetriever componentPropertiesRetriever)
        {
            this.mediaFileRepository = mediaFileRepository;
            this.mediaFileUrlRetriever = mediaFileUrlRetriever;
            this.componentPropertiesRetriever = componentPropertiesRetriever;
            this.outputCacheDependencies = outputCacheDependencies;
        }
        public ActionResult Index()
        {
            var properties = componentPropertiesRetriever.Retrieve<MediaTextWidgetProperties>();
            var imagePath = GetImagePath(properties);

            return PartialView("Widgets/_MediaTextWidget", new MediaTextWidgetViewModel
            {
                Title = properties.Title,
                Image = imagePath,
                Text = properties.Text,
                LinkUrl = properties.LinkUrl,
                LinkTitle = properties.LinkTitle
            });
        }
        private string GetImagePath(MediaTextWidgetProperties properties)
        {
            var imageGuid = properties.Image.FirstOrDefault()?.FileGuid ?? Guid.Empty;
            if (imageGuid == Guid.Empty)
            {
                return null;
            }

            outputCacheDependencies.AddDependencyOnInfoObject<MediaFileInfo>(imageGuid);

            var image = mediaFileRepository.GetMediaFile(imageGuid, SiteContext.CurrentSiteID);
            if (image == null)
            {
                return string.Empty;
            }

            return mediaFileUrlRetriever.Retrieve(image).RelativePath;
        }
    }
}