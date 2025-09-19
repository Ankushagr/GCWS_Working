using CMS.Core;
using CMS.DocumentEngine.Types.GCWS;
using GCWS.Controllers.PageTemplates;
using GCWS.Models;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterPageTemplate("GCWS.News", typeof(NewsPageTemplateController), "News Page Template", Description = "Displat News Details", IconClass = "icon-l-text")]


namespace GCWS.Controllers.PageTemplates
{
    public class NewsPageTemplateController : PageTemplateController
    {
        // GET: NewsPageTemplate
        //private readonly IPageDataContextRetriever pageDataContextRetriver;
        //private readonly IPageUrlRetriever pageUrlRetriever;
        //private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        //private readonly IPageRetriever pageRetriever;

        //public NewsPageTemplateController()
        //{
        //    pageRetriever = Service.Resolve<IPageRetriever>();
        //    pageUrlRetriever = Service.Resolve<IPageUrlRetriever>();
        //    attachmentUrlRetriever = Service.Resolve<IPageAttachmentUrlRetriever>();
        //    pageDataContextRetriver = Service.Resolve<IPageDataContextRetriever>();

        //}

        private readonly IPageDataContextRetriever pageDataContextRetriver;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;


        public NewsPageTemplateController(IPageDataContextRetriever pageDataContextRetriver, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.pageDataContextRetriver = pageDataContextRetriver;
            this.pageUrlRetriever = pageUrlRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }
        public ActionResult Index()
        {
            var news = pageDataContextRetriver.Retrieve<News>().Page;
            if (news == null)
            {
                return HttpNotFound();
            }
            return View("PageTemplates/_News", NewsViewModel.GetViewModel(news, pageUrlRetriever, attachmentUrlRetriever));
        }
    }
}