using System;
using System.Collections.Generic;
using System.Linq;

using CMS.DocumentEngine.Types.GCWS;

using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.News
{
    public class NewsViewModel
	{
        public IPageAttachmentUrl TeaserUrl { get; set; }


        public string Title { get; set; }


        public DateTime PublicationDate { get; set; }


        public string Summary { get; set; }


        public string Text { get; set; }


        //public IEnumerable<ArticleViewModel> RelatedArticles { get; set; }
        
        
        public string Url { get; set; }


        public static NewsViewModel GetViewModel(CMS.DocumentEngine.Types.GCWS.News news, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            return new NewsViewModel
            {
                //PublicationDate = article.PublicationDate,
                //RelatedArticles = article.Fields.RelatedArticles.OfType<Article>().Select(related => GetViewModel(related, pageUrlRetriever, attachmentUrlRetriever)),
                Summary = news.Fields.Summary,
                TeaserUrl = news.Fields.Image == null ? null : attachmentUrlRetriever.Retrieve(news.Fields.Image),
                //Text = news.Fields.Text,
                Title = news.Fields.Title,
                Url = pageUrlRetriever.Retrieve(news).RelativePath
            };
        }
    }
}