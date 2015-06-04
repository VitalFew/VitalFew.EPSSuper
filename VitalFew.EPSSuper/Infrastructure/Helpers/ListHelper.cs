using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitalFew.EPSSuper.Models;

namespace VitalFew.EPSSuper.Infrastructure.Helpers
{
    public class ListHelper
    {
        public static IEnumerable<SelectListItem> GetUserTypeList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var itemList = new List<SelectListItem>();

                itemList.AddRange(from l in db.ApplicationUserType
                           orderby l.UserTypeID
                           select new SelectListItem { Value = l.UserTypeID.ToString(), Text = l.Description });

                return itemList;
            }
        }
    }
}