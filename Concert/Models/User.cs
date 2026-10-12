using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Concert.Models
{
    public class User
    {
        public int RegistrationId { get; set; }
    
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Home Address is required")]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pin Code is required")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Please select how you heard about the concert")]
        public string HeardAboutConcert { get; set; }

        public string OtherSource { get; set; }

        public decimal VirtualConcertFee { get; set; }
      
        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Please select a payment method")]
        public string PaymentMethod { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}

