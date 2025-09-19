using CMS.DocumentEngine;
using GCWS.Controllers.Widgets;
using GCWS.Models.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Linq;
using System.Web.Mvc;


//[assembly: RegisterWidget(
//    "GCWS.Widgets.HelloWorldWidget",      // unique identifier
//    "Hello World Widget",                 // name shown in widget picker
//    typeof(HelloWorldWidgetController),
//    customViewName: "Widgets/HelloWorld",
//    IconClass = "icon-l-rocket")]

[assembly: RegisterWidget("GCWS.Widgets.HelloWorldWidget", typeof(HelloWorldWidgetController), "Hello demo", IconClass = "icon-form")]

namespace GCWS.Controllers.Widgets
{
    public class HelloWorldWidgetController : WidgetController<HellowWorldWidgetProperty>
    {
        //private readonly IPageRetriever pageRetriever;
       // private readonly IComponentPropertiesRetriever propertiesRetriever;

        //public HelloWorldWidgetController(IComponentPropertiesRetriever _propertiesRetriever)
        //{
        //    this.propertiesRetriever = _propertiesRetriever;
        //}
        public ActionResult Index(HellowWorldWidgetProperty property)
        {
            var path = property.SelectedPath;
           // var props = propertiesRetriever.Retrieve<HellowWorldWidgetProperty>();
           // string documentPath = props.PagePaths.FirstOrDefault()?.NodeAliasPath;
           // var path = props.PagePaths;
            //if (string.IsNullOrEmpty(path))
            //{
            //    return Content("<div style='color:gray'>No path selected.</div>");
            //}
            //    var pages = pageRetriever.Retrieve<TreeNode>(
            //query => query
            //    .Path(path, PathTypeEnum.Explicit)
            //    .Columns("DocumentName", "NodeAliasPath"),
            //cache => cache.Key($"{nameof(HelloWorldWidgetController)}|{path}")
            // );
            return PartialView("Widgets/HelloWorld", property);
        }
    }
}