using GCWS;
using GCWS.Models.Sections;

//using GCWS.Models.PageTemplates;
//using GCWS.Models.Sections;
//using GCWS.Models.Widgets;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

// Widgets
//[assembly: RegisterWidget(ComponentIdentifiers.TESTIMONIAL_WIDGET, "{$GCWSmvc.widget.testimonial.name$}", typeof(TestimonialWidgetProperties), Description = "{$GCWSmvc.widget.testimonial.description$}", IconClass = "icon-right-double-quotation-mark")]
//[assembly: RegisterWidget(ComponentIdentifiers.CTA_BUTTON_WIDGET, "{$GCWSmvc.widget.ctabutton.name$}", typeof(CTAButtonWidgetProperties), Description = "{$GCWSmvc.widget.ctabutton.description$}", IconClass = "icon-rectangle-a")]

//// Sections
[assembly: RegisterSection(ComponentIdentifiers.SINGLE_COLUMN_SECTION, "singlecolumn", typeof(ThemeSectionProperties), Description = "SingleColumnSection", IconClass = "icon-square")]
[assembly: RegisterSection(ComponentIdentifiers.TWO_COLUMN_SECTION, "twocolumn", typeof(ThemeSectionProperties), Description = "TwoColumnSection", IconClass = "icon-l-cols-2")]
[assembly: RegisterSection(ComponentIdentifiers.THREE_COLUMN_SECTION, "threecolumn", typeof(ThreeColumnSectionProperties), Description = "ThreeColumnSection", IconClass = "icon-l-cols-3")]

//// Page templates
//[assembly: RegisterPageTemplate(ComponentIdentifiers.LANDING_PAGE_SINGLE_COLUMN_TEMPLATE, "{$GCWSmvc.pagetemplate.landingpagesinglecolumn.name$}", typeof(LandingPageSingleColumnProperties), Description = "{$GCWSmvc.pagetemplate.landingpagesinglecolumn.description$}")]
