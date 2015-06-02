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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public ApplicationUserType UserType { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}