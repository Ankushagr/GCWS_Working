using System.ComponentModel.DataAnnotations;

using CMS.Ecommerce;

namespace GulfCoastWorkforceSolutions.Models.Checkout
{
    public class CustomerViewModel
    {
        [Required]
        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Firstname")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Lastname")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Email.Required")]
        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Email")]
        [EmailAddress(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.InvalidEmail")]
        [MaxLength(100, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.News.LongEmail")]
        public string Email { get; set; }


        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Phone")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(26, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceededed")]
        public string PhoneNumber { get; set; }


        [Display(Name = "GulfCoastWorkforceSolutionsMvc.CompanyName")]
        [MaxLength(200, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceededed")]
        public string Company { get; set; }


        [Display(Name = "GulfCoastWorkforceSolutionsMvc.OrganizationId")]
        [MaxLength(50, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceededed")]
        public string OrganizationID { get; set; }


        [Display(Name = "GulfCoastWorkforceSolutionsMvc.TaxRegistrationId")]
        [MaxLength(50, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceededed")]
        public string TaxRegistrationID { get; set; }


        public bool IsCompanyAccount { get; set; }


        public CustomerViewModel(CustomerInfo customer)
        {
            if (customer == null)
            {
                return;
            }

            FirstName = customer.CustomerFirstName;
            LastName = customer.CustomerLastName;
            Email = customer.CustomerEmail;
            PhoneNumber = customer.CustomerPhone;
            Company = customer.CustomerCompany;
            OrganizationID = customer.CustomerOrganizationID;
            TaxRegistrationID = customer.CustomerTaxRegistrationID;
            IsCompanyAccount = customer.CustomerHasCompanyInfo;
        }


        public CustomerViewModel()
        {
        }


        public void ApplyToCustomer(CustomerInfo customer, bool emailCanBeChanged)
        {
            customer.CustomerFirstName = FirstName;
            customer.CustomerLastName = LastName;
            customer.CustomerPhone = PhoneNumber;
            customer.CustomerCompany = Company;
            customer.CustomerOrganizationID = OrganizationID;
            customer.CustomerTaxRegistrationID = TaxRegistrationID;

            if (emailCanBeChanged)
            {
                customer.CustomerEmail = Email;
            }
        }
    }
}