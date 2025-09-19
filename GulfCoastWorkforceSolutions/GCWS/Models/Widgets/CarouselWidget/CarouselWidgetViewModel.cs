using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWS.Models.Widgets
{
    public class CarouselWidgetViewModel
    {
        public List<CarouselItems> carouselItems {  get; set; }
    }

    public class CarouselItems
    {
        public string Title { get; set; }
        public string CtaLable { get; set; }
        public string CtaUrl { get; set; }
        public string Banner { get; set; }
        public string BannerText { get; set; }
    }
}