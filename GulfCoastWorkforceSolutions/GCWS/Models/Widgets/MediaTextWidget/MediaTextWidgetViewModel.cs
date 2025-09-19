using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWS.Models.Widgets
{
    public class MediaTextWidgetViewModel
    {
        /// <summary>
        /// Background image path.
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Text.
        /// </summary>
        public string Image { get; set; }


        /// <summary>
        /// Button text.
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// Target of button link.
        /// </summary>
        public string LinkUrl { get; set; }


        /// <summary>
        /// Theme of the widget.
        /// </summary>
        public string LinkTitle { get; set; }
    }
}