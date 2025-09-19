using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWS.Models.Widgets
{
    public class ColorBlocksWidgetViewModel
    {
        public List<ColorBlocksItem> colorBlocksItems { get; set; }
    }
    public class ColorBlocksItem
    {
        /// <summary>
        /// Banner background image path.
        /// </summary>
        public string Icon { get; set; }


        /// <summary>
        /// Banner text.
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Gets or sets URL to which the visitor is redirected after clicking on the <see cref="Text"/>.
        /// </summary>
        public string Description { get; set; }
        public string Color { get; set; }
        public string CtaLable { get; set; }
        public string CtaUrl { get; set; }
        public string BannerClassCSS { get; set; }

    }
}