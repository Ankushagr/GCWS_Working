using System;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.GCWS;
using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public IEnumerable<News> GetTopNews(int count)
        {
            return NewsProvider.GetNews()
                .OrderByDescending(n => n.RealeaseDate)
                .Take(count)
                .ToList();
        }
    }
}