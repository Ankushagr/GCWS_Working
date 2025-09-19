using CMS.MediaLibrary;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;

namespace GCWS.Models.Widgets
{
    /// <summary>
    /// View model for Banner widget.
    /// </summary>
    public class NewsWidgetViewModel
    {
        public List<NewsItems> NewsList { get; set; }
	}
    public class NewsItems 
    {
		/// <summary>
		/// Banner background image path.
		/// </summary>
		public string ImagePath { get; set; }


		/// <summary>
		/// Banner text.
		/// </summary>
		public string Title { get; set; }


		/// <summary>
		/// Gets or sets a title for a link defined by <see cref="LinkUrl"/>.
		/// </summary>
		public string Summary { get; set; }


		/// <summary>
		/// Gets or sets URL to which the visitor is redirected after clicking on the <see cref="Text"/>.
		/// </summary>
		public string Description { get; set; }
		public string ReleaseDate { get; set; }
		public string NewsUrl { get; set; }
	}
}