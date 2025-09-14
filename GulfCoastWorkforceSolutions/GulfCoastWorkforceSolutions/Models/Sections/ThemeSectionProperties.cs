using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Sections
{
    /// <summary>
    /// Section properties to define the theme.
    /// </summary>
    public class ThemeSectionProperties : ISectionProperties
    {
        /// <summary>
        /// Theme of the section.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "{$GulfCoastWorkforceSolutionsMVC.Section.ColorScheme.Label$}", Order = 1)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), ";{$GulfCoastWorkforceSolutionsMVC.Section.ColorScheme.None$}\r\nsection-gray;{$GulfCoastWorkforceSolutionsMVC.Section.ColorScheme.LightGray$}\r\nsection-red;{$GulfCoastWorkforceSolutionsMVC.Section.ColorScheme.Red$}")]
        public string Theme { get; set; }
    }
}