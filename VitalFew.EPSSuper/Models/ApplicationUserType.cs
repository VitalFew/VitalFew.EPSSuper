using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitalFew.EPSSuper.Models
{
    public class ApplicationUserType
    {
        [Key]
        public int UserTypeID { get; set; }
        public string Description { get; set; }

    }
}