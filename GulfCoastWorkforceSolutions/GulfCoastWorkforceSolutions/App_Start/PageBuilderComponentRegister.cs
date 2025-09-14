using GulfCoastWorkforceSolutions;
using GulfCoastWorkforceSolutions.Models.Sections;

//using GulfCoastWorkforceSolutions.Models.PageTemplates;
//using GulfCoastWorkforceSolutions.Models.Sections;
//using GulfCoastWorkforceSolutions.Models.Widgets;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

// Widgets
//[assembly: RegisterWidget(ComponentIdentifiers.TESTIMONIAL_WIDGET, "{$GulfCoastWorkforceSolutionsmvc.widget.testimonial.name$}", typeof(TestimonialWidgetProperties), Description = "{$GulfCoastWorkforceSolutionsmvc.widget.testimonial.description$}", IconClass = "icon-right-double-quotation-mark")]
//[assembly: RegisterWidget(ComponentIdentifiers.CTA_BUTTON_WIDGET, "{$GulfCoastWorkforceSolutionsmvc.widget.ctabutton.name$}", typeof(CTAButtonWidgetProperties), Description = "{$GulfCoastWorkforceSolutionsmvc.widget.ctabutton.description$}", IconClass = "icon-rectangle-a")]

//// Sections
[assembly: RegisterSection(ComponentIdentifiers.SINGLE_COLUMN_SECTION, "singlecolumn", typeof(ThemeSectionProperties), Description = "SingleColumnSection", IconClass = "icon-square")]
[assembly: RegisterSection(ComponentIdentifiers.TWO_COLUMN_SECTION, "twocolumn", typeof(ThemeSectionProperties), Description = "TwoColumnSection", IconClass = "icon-l-cols-2")]
[assembly: RegisterSection(ComponentIdentifiers.THREE_COLUMN_SECTION, "threecolumn", typeof(ThreeColumnSectionProperties), Description = "ThreeColumnSection", IconClass = "icon-l-cols-3")]

//// Page templates
//[assembly: RegisterPageTemplate(ComponentIdentifiers.LANDING_PAGE_SINGLE_COLUMN_TEMPLATE, "{$GulfCoastWorkforceSolutionsmvc.pagetemplate.landingpagesinglecolumn.name$}", typeof(LandingPageSingleColumnProperties), Description = "{$GulfCoastWorkforceSolutionsmvc.pagetemplate.landingpagesinglecolumn.description$}")]
