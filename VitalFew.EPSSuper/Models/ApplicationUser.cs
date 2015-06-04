using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VitalFew.EPSSuper.Models
{
    public class ApplicationUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid UserID { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "User Type")]
        public ApplicationUserType UserType { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}