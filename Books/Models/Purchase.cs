using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a first name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name:")]
        public string LastName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required(ErrorMessage ="Please enter a state/province")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage ="Please enter a country")]
        public string Country { get; set; }

        [Required(ErrorMessage ="Please enter a phone number")]
        [Phone]
        public string Phone { get; set; }

    }
}
