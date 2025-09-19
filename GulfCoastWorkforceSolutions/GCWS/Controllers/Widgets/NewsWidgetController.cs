using System;
using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.GCWS;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using GCWS.Controllers.Widgets;
using GCWS.Models.Widgets;
using GCWS.Infrastructure;
using GCWS.Repositories;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using CMS.Core;

[assembly: RegisterWidget(NewsWidgetController.IDENTIFIER, typeof(NewsWidgetController), "News List Widget", Description = "{GCWS.widget.news.description$}", IconClass = "icon-ribbon")]
namespace GCWS.Controllers.Widgets
{
    /// <summary>
    /// Controller for banner widget.
    /// </summary>
    public class NewsWidgetController : WidgetController<NewsWidgetProperties>
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "GCWS.NewsWidget";

        //private readonly IMediaFileRepository mediaFileRepository;
        //private readonly IOutputCacheDependencies outputCacheDependencies;
        //private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;
        //private readonly IComponentPropertiesRetriever componentPropertiesRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public NewsWidgetController()
        {
            pageUrlRetriever = Service.Resolve<IPageUrlRetriever>();
            attachmentUrlRetriever = Service.Resolve<IPageAttachmentUrlRetriever>();
        }

        /// <summary>
        /// Creates an instance of <see cref="NewsWidgetController"/> class.
        /// </summary>
        /// <param name="mediaFileRepository">Repository for media files.</param>
        //public NewsWidgetController(
        //          IMediaFileRepository mediaFileRepository,
        //	IOutputCacheDependencies outputCacheDependencies,
        //	IMediaFileUrlRetriever mediaFileUrlRetriever,
        //	IComponentPropertiesRetriever componentPropertiesRetriever,
        //IPageAttachmentUrlRetriever attachmentUrlRetriever,
        //IPageUrlRetriever pageUrlRetriever)
        //{
        //	this.mediaFileRepository = mediaFileRepository;
        //	this.outputCacheDependencies = outputCacheDependencies;
        //	this.mediaFileUrlRetriever = mediaFileUrlRetriever;
        //	this.componentPropertiesRetriever = componentPropertiesRetriever;
        //	this.attachmentUrlRetriever = attachmentUrlRetriever;
        //	this.pageUrlRetriever = pageUrlRetriever;
        //}

        public ActionResult Index()
        {
            var news = NewsProvider.GetNews().TopN(4).ToList();
            var newsList = news.Select(x =>
            {
                string imagePath = null;
                if (x.Image != Guid.Empty)
                {
                    //var image = mediaFileRepository.GetMediaFile(x.Image, SiteContext.CurrentSiteID);
                    var imageAtt = AttachmentInfoProvider.GetAttachmentInfo(x.DocumentID, x.Image);
                    var image = attachmentUrlRetriever.Retrieve(imageAtt);
                    if (image != null)
                    {
                        imagePath = image.RelativePath;
                    }
                }
                return new NewsItems
                {
                    Title = x.Title,
                    Summary = x.Summary,
                    Description = x.Description,
                    ImagePath = imagePath,
                    NewsUrl = pageUrlRetriever.Retrieve(x).RelativePath
                };
            }).ToList();

            //outputCacheDependencies.AddDependencyOnPages(news);
            return PartialView("Widgets/_NewsWidget", new NewsWidgetViewModel
            {
                NewsList = newsList
            });
        }


        //private string GetImagePath(NewsWidgetProperties properties)
        //      {
        //          var imageGuid = properties.Image.FirstOrDefault()?.FileGuid ?? Guid.Empty;
        //          if (imageGuid == Guid.Empty)
        //          {
        //              return null;
        //          }

        //          outputCacheDependencies.AddDependencyOnInfoObject<MediaFileInfo>(imageGuid);

        //          var image = mediaFileRepository.GetMediaFile(imageGuid, SiteContext.CurrentSiteID);
        //          if (image == null)
        //          {
        //              return string.Empty;
        //          }

        //          return mediaFileUrlRetriever.Retrieve(image).RelativePath;
        //      }
    }
}