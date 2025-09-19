using CMS.Core;
using CMS.DocumentEngine.Types.GCWS;
using CMS.DocumentEngine;
using GCWS.Controllers.Widgets;
using GCWS.Models.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget(ColorBlocksWidgetController.IDENTIFIER, typeof(ColorBlocksWidgetController), "Color Block List Widget", Description = "{GCWS.widget.ColorBlock.description$}", IconClass = "icon-ribbon")]
namespace GCWS.Controllers.Widgets
{
    public class ColorBlocksWidgetController : WidgetController<ColorBlocksWidgetProperties>
    {
        public const string IDENTIFIER = "GCWS.ColorBlocks";
        // GET: ColorBlocksWidget
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public ColorBlocksWidgetController()
        {
            pageUrlRetriever = Service.Resolve<IPageUrlRetriever>();
            attachmentUrlRetriever = Service.Resolve<IPageAttachmentUrlRetriever>();
        }
        public ActionResult Index()
        {
            var colorBlocks = ColorBlocksProvider.GetColorBlocks().TopN(4).ToList();
            var colorBlocksList = colorBlocks.Select(x =>
            {
                string imagePath = null;
                if (x.Icon1 != Guid.Empty)
                {
                    //var image = mediaFileRepository.GetMediaFile(x.Image, SiteContext.CurrentSiteID);
                    var imageAtt = AttachmentInfoProvider.GetAttachmentInfo(x.DocumentID, x.Icon1);
                    var image = attachmentUrlRetriever.Retrieve(imageAtt);
                    if (image != null)
                    {
                        imagePath = image.RelativePath;
                    }
                }
                return new ColorBlocksItem
                {
                    Title = x.Title,
                    Description = x.Description,
                    Icon = imagePath,
                    CtaUrl = pageUrlRetriever.Retrieve(x).RelativePath,
                    CtaLable = x.CTALabel,
                    BannerClassCSS = x.BannerCssClass,
                    Color = x.Color
                };
            }).ToList();

            //outputCacheDependencies.AddDependencyOnPages(news);
            return PartialView("Widgets/_ColorBlocksWidget", new ColorBlocksWidgetViewModel
            {
                colorBlocksItems = colorBlocksList
            });
        }
    }
}