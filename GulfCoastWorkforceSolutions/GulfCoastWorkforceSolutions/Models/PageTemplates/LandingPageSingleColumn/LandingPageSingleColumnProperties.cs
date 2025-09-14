using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

namespace GulfCoastWorkforceSolutions.Models.PageTemplates
{
    public class LandingPageSingleColumnProperties : IPageTemplateProperties
    {
        /// <summary>
        /// Indicates if logo should be shown.
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "{$GulfCoastWorkforceSolutionsMVC.PageTemplate.LandingPageSingleColumn.ShowLogo$}", Order = 1)]
        public bool ShowLogo { get; set; } = true;


        /// <summary>
        /// Background color CSS class of the header.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "{$GulfCoastWorkforceSolutionsMVC.PageTemplate.LandingPageSingleColumn.HeaderColor$}", Order = 2)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "first-color;{$GulfCoastWorkforceSolutionsMVC.PageTemplate.LandingPageSingleColumn.FirstColor$}\r\nsecond-color;{$GulfCoastWorkforceSolutionsMVC.PageTemplate.LandingPageSingleColumn.SecondColor$}\r\nthird-color;{$GulfCoastWorkforceSolutionsMVC.PageTemplate.LandingPageSingleColumn.ThirdColor$}")]
        public string HeaderColorCssClass { get; set; } = "first-color";
    }
}