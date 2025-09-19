using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GCWS.Models.Widgets
{
    public class HellowWorldWidgetProperty : IWidgetProperties
    {
        public string Message { get; set; } = "Hello World!";
        [EditingComponent(PathSelector.IDENTIFIER, Label = "text", Order = 1)]
        public IEnumerable<PathSelectorItem> PagePaths { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER,
            Label = "Select page path",
            Order = 0)]
        public string SelectedPath { get; set; } = "";   // <-- must be string
    }
}