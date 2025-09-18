using System;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine.Types.GCWS;
using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.PageTemplates
{
    public class NewsViewModel
	{
        public string TeaserPath { get; set; }


        public string Title { get; set; }


        public DateTime PublicationDate { get; set; }


        public string Text { get; set; }

        public string Summary { get; set; } 


		//public IEnumerable<RelatedNewsViewModel> RelatedNews { get; set; }


        public static NewsViewModel GetViewModel(CMS.DocumentEngine.Types.GCWS.News news, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            return new NewsViewModel
			{
                PublicationDate = news.RealeaseDate,
				//RelatedNews = article.Fields.RelatedArticles.OfType<news>().Select(relatedArticle => RelatedNewsViewModel.GetViewModel(relatedArticle, true, pageUrlRetriever, attachmentUrlRetriever)),
                TeaserPath = news.Fields.Image == null ? null : attachmentUrlRetriever.Retrieve(news.Fields.Image).RelativePath,
                Summary = news.Fields.Summary,
                Title = news.Fields.Title
            };
        }
    }
}