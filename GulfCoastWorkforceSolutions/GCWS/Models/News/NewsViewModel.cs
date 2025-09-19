using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.GCWS;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCWS.Models
{
    public class NewsViewModel
    {
       public IPageAttachmentUrl TeaserUrl { get; set; }


        public string Title { get; set; }


        public DateTime ReleaseDate { get; set; }


        public string Summary { get; set; }


        public string Category { get; set; }


     //   public IEnumerable<NewsViewModel> RelatedArticles { get; set; }


        public string Description { get; set; }
        public string Url { get; set; }


        public static NewsViewModel GetViewModel(News news, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            return new NewsViewModel
            {
                ReleaseDate = news.Fields.RealeaseDate,
               //RelatedArticles = article.Fields.RelatedArticles.OfType<Article>().Select(related => GetViewModel(related, pageUrlRetriever, attachmentUrlRetriever)),
                Summary = news.Fields.Summary,
                TeaserUrl = news.Fields.Image == null ? null : attachmentUrlRetriever.Retrieve(news.Fields.Image),
                Description = news.Fields.Description,
                Title = news.Fields.Title,
                Url = pageUrlRetriever.Retrieve(news).RelativePath,
                Category = news.Fields.Category,
            };
        }
    }
}