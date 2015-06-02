using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VitalFew.EPSSuper.Controllers
{
    public class BaseController : Controller
    {
             
        public BaseController()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_userManager != null)
                //{
                //    _userManager.Dispose();
                //    _userManager = null;
                //}

                //if (_signInManager != null)
                //{
                //    _signInManager.Dispose();
                //    _signInManager = null;
                //}
            }

            base.Dispose(disposing);
        }

    }
}