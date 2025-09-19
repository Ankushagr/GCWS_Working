using CMS.Core;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Routing;
using GCWS.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace GCWS.Controllers
{
    public class MenuController : Controller
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageUrlRetriever urlRetriever;

        public MenuController()
        {
            // Initializes instances of required services
            // NOTE: This method of instantiating services is not recommended for
            // real-world projects and is only used for the sake of brevity in this tutorial.
            // Instead, we recommend configuring a dependency injection container to resolve
            // object dependencies (e.g., Autofac). See the Xperience documentation for details.
            pageRetriever = Service.Resolve<IPageRetriever>();
            urlRetriever = Service.Resolve<IPageUrlRetriever>();
        }

        // GET: Loads and displays the site's navigation menu
        public ActionResult GetMenu()
        {
            // Retrieves a collection of page objects with data for the menu (pages of all page types)
            IEnumerable<TreeNode> menuItems = pageRetriever.Retrieve<TreeNode>(query => query
                                                    // Selects pages that have the 'Show in menu" flag enabled
                                                    .MenuItems()
                                                    // Only loads pages from the first level of the site's content tree
                                                    .NestingLevel(1)
                                                    // Filters the query to only include necessary columns
                                                    .Columns("DocumentName", "NodeID", "NodeSiteID")
                                                    // Loads pages together with their URL path data (performance reasons)
                                                    .WithPageUrlPaths()
                                                    // Uses the menu item order from the content tree
                                                    .OrderByAscending("NodeOrder"));

            // Creates a collection of view models based on the menu item data
            IEnumerable<MenuItemViewModel> model = menuItems.Select(item => new MenuItemViewModel()
            {
                // Gets the name of the page as the menu item caption text
                MenuItemText = item.DocumentName,
                // Retrieves the URL for the page (as a relative virtual path)
                MenuItemRelativeUrl = urlRetriever.Retrieve(item).RelativePath
            });

            return PartialView("_SiteMenu", model);
        }
    }
}