using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CMS.ContactManagement;

using GCWS.Personalization;

using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.Personalization;

[assembly: RegisterPersonalizationConditionType("GCWS.Personalization.IsInContactGroup", typeof(IsInContactGroupConditionType), "{$GCWSMvc.ConditionType.IsInContactGroup.Name$}", Description = "{$GCWSMvc.ConditionType.IsInContactGroup.Description$}", IconClass = "icon-app-contact-groups", Hint = "{$GCWSMvc.ConditionType.IsInContactGroup.Hint$}")]

namespace GCWS.Personalization
{
    /// <summary>
    /// Personalization condition type based on contact group.
    /// </summary>
    public class IsInContactGroupConditionType : ConditionType
    {
        /// <summary>
        /// List of selected contact group code names.
        /// </summary>
        [EditingComponent("GCWS.ContactGroupSelector", Order = 0, Label = "")]
        public List<string> SelectedContactGroups { get; set; }


        /// <summary>
        /// Variant name.
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "")]
        [EditingComponentProperty(nameof(TextInputProperties.Placeholder), "{$kentico.pagebuilder.variant.name$}")]
        [Required(ErrorMessage = "kentico.pagebuilder.variant.name.required")]
        public override string VariantName
        {
            get;
            set;
        }


        /// <summary>
        /// Evaluate condition type.
        /// </summary>
        /// <returns>Returns <c>true</c> if implemented condition is met.</returns>
        public override bool Evaluate()
        {
            var contact = ContactManagementContext.GetCurrentContact();
            if (contact == null)
            {
                return false;
            }

            if (SelectedContactGroups == null || SelectedContactGroups.Count == 0)
            {
                return contact.ContactGroups.Count == 0;
            }

            return contact.IsInAnyContactGroup(SelectedContactGroups.ToArray());
        }
    }
}