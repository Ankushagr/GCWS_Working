using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace GCWS.Models.Sections
{
    /// <summary>
    /// Section properties to define the theme.
    /// </summary>
    public class ThemeSectionProperties : ISectionProperties
    {
        /// <summary>
        /// Theme of the section.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "{GCWS.Section.ColorScheme.Label$}", Order = 1)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), ";{GCWS.Section.ColorScheme.None$}\r\nsection-gray;{GCWS.Section.ColorScheme.LightGray$}\r\nsection-red;{GCWS.Section.ColorScheme.Red$}")]
        public string Theme { get; set; }
    }
}