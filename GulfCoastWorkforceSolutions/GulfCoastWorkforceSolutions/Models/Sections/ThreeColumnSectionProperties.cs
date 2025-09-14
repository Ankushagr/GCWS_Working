using Kentico.Forms.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Sections
{
    /// <summary>
    /// Section properties for the 'Three column section'.
    /// </summary>
    public class ThreeColumnSectionProperties : ThemeSectionProperties
    {
        /// <summary>
        /// Title of the section.
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "{$GulfCoastWorkforceSolutionsMVC.Section.Title.Label$}", Order = 1)]
        public string Title { get; set; }
    }
}