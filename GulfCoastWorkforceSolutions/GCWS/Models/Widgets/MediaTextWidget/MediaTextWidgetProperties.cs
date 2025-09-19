using CMS.DocumentEngine;
using CMS.SiteProvider;
using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GCWS.Models.Widgets
{
    public class MediaTextWidgetProperties : IWidgetProperties
    {
        private string mLinkUrl;


        /// <summary>
        /// Text to be displayed.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Guid of an image to be displayed.
        /// </summary>
        public IEnumerable<MediaFilesSelectorItem> Image { get; set; } = Enumerable.Empty<MediaFilesSelectorItem>();

        /// <summary>
        /// Text to be displayed.
        /// </summary>
        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Content", Order = 0)]
        public string Text { get; set; }





        /// <summary>
        /// Gets or sets URL to which a visitor is redirected after clicking on the <see cref="Text"/>.
        /// </summary>
        [EditingComponent(UrlSelector.IDENTIFIER, Order = 0, Label = "{GCWS.Widget.MediaText.LinkUrl$}")]
        [EditingComponentProperty(nameof(UrlSelectorProperties.Placeholder), "{GCWS.Widget.MediaText.LinkUrl.Placeholder$}")]
        [EditingComponentProperty(nameof(UrlSelectorProperties.Tabs), ContentSelectorTabs.Page)]
        public string LinkUrl
        {
            get
            {
                return mLinkUrl;
            }
            set
            {
                mLinkUrl = GetNormalizedUrl(value, SiteContext.CurrentSite);
            }
        }


        /// <summary>
        /// Gets or sets a title for a link defined by <see cref="LinkUrl"/>.
        /// </summary>
        /// <remarks>
        /// If URL targets a page in the site then URL is stored in a given format '~/en-us/article'.
        /// </remarks>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "{GCWS.Widget.MediaText.LinkTitle$}")]
        [VisibilityCondition(nameof(LinkUrl), ComparisonTypeEnum.IsNotEmpty)]
        public string LinkTitle { get; set; } = String.Empty;


        private string GetNormalizedUrl(string url, SiteInfo site)
        {
            if (DocumentURLProvider.TryUnresolveUrl(url, site.SiteID, out var path))
            {
                return path;
            }

            return url;
        }
    }
}