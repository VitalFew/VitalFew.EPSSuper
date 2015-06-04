using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitalFew.EPSSuper.Models
{
    public class ApplicationUserType
    {
        [Key]
        //[Display(Name = "User Type")]
        //[Required(ErrorMessage = "The User Type is required")]
        //[DefaultValue(0)]
        public int UserTypeID { get; set; }

        [Display(Name = "User Type")]
        //[Required(ErrorMessage = "The User Type is required")]
        //[DefaultValue("----Select----")]
        public string Description { get; set; }

    }
}