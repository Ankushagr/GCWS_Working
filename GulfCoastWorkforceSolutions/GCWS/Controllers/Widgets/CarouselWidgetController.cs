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
using CMS.Core;

[assembly: RegisterWidget(CarouselWidgetController.IDENTIFIER, typeof(CarouselWidgetController), "Carousel Widget", Description = "{GCWS.widget.Carousel.description$}", IconClass = "icon-ribbon")]

namespace GCWS.Controllers.Widgets
{
    public class CarouselWidgetController : WidgetController<CarouselWidgetProperties>
    {
        public const string IDENTIFIER = "GCWS.Carousel";
        // GET: Carousel
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public CarouselWidgetController()
        {
            pageUrlRetriever = Service.Resolve<IPageUrlRetriever>();
            attachmentUrlRetriever = Service.Resolve<IPageAttachmentUrlRetriever>();
        }
        public ActionResult Index()
        {
            var carousel = CarouselProvider.GetCarousels().TopN(4).ToList();
            var carouselList = carousel.Select(x =>
            {
                string imagePath = null;
                if (x.Banner != Guid.Empty)
                {
                    //var image = mediaFileRepository.GetMediaFile(x.Image, SiteContext.CurrentSiteID);
                    var imageAtt = AttachmentInfoProvider.GetAttachmentInfo(x.DocumentID, x.Banner);
                    var image = attachmentUrlRetriever.Retrieve(imageAtt);
                    if (image != null)
                    {
                        imagePath = image.RelativePath;
                    }
                }
                return new CarouselItems
                {
                    Title = x.Title,
                    BannerText = x.BannerText,
                    Banner = imagePath,
                    CtaUrl = x.CTAUrl,
                    CtaLable = x.CTALable
                };
            }).ToList();

            //outputCacheDependencies.AddDependencyOnPages(news);
            return PartialView("Widgets/_CarouselWidget", new CarouselWidgetViewModel
            {
                carouselItems = carouselList
            });
        }
    }
}