using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitalFew.EPSSuper.Models;

namespace VitalFew.EPSSuper.Controllers
{
    public class ManageUsersController : BaseController
    {
        //private Entities db = new Entities();
        private DatabaseContext db = new DatabaseContext();

        // GET: ManageUsers
        public async Task<ActionResult> Index()
        {
            return View(db.ApplicationUser.Include(model => model.UserType).OrderByDescending(model => model.UpdatedOn).ToList());
        }

        // GET: ManageUsers/Create
        public ActionResult Create()
        {
            var model = new ApplicationUser();
            model.Active = true;

            return View(model);
        }

        // POST: ManageUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (!UserExists(user.Email))
                {
                    user.UserID = Guid.NewGuid();
                    user.UserType = db.ApplicationUserType.FirstOrDefault(type => type.UserTypeID == user.UserType.UserTypeID);
                    user.CreatedOn = DateTime.Now;
                    user.UpdatedOn = DateTime.Now;
                    user.CreatedBy = HttpContext.User.Identity.Name;
                    user.UpdatedBy = HttpContext.User.Identity.Name;

                    db.ApplicationUser.Add(user);
                    await db.SaveChangesAsync();

                    SuccessMessage = "User [" + user.Email + "] is added";
                    return RedirectToAction("Index", "ManageUsers");
                }
                else
                {
                    ErrorMessage = "User alrady exists with Email [" + user.Email + "]";
                }
            }
            
            return View(user);
        }

        // GET: ManageUsers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                var user = db.ApplicationUser.Include(model => model.UserType).Where(model => model.UserID == id).FirstOrDefault();

                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: ManageUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var userExisting = db.ApplicationUser.Where(model => model.UserID == user.UserID).FirstOrDefault();

                if (user != null)
                {
                    userExisting.UserType = db.ApplicationUserType.FirstOrDefault(type => type.UserTypeID == user.UserType.UserTypeID);
                    userExisting.Active = user.Active;
                    userExisting.UpdatedOn = DateTime.Now;
                    userExisting.UpdatedBy = HttpContext.User.Identity.Name;

                    await db.SaveChangesAsync();

                    SuccessMessage = "User [" + user.Email + "] is updated";
                }

                return RedirectToAction("Index", "ManageUsers");
            }

            return View(user);
        }

        // GET: ManageUsers/Edit/5
        public async Task<ActionResult> Status(Guid? id)
        {
            if (id != null)
            {
                var user = db.ApplicationUser.Include(model => model.UserType).Where(model => model.UserID == id).FirstOrDefault();

                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: ManageUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Status(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var userExisting = db.ApplicationUser.Where(model => model.UserID == user.UserID).FirstOrDefault();

                if (user != null)
                {
                    userExisting.Active = !user.Active;
                    userExisting.UpdatedOn = DateTime.Now;
                    userExisting.UpdatedBy = HttpContext.User.Identity.Name;

                    await db.SaveChangesAsync();

                    if (!user.Active)
                    {
                        SuccessMessage = "User [" + user.Email + "] is activated";
                    }
                    else
                    {
                        SuccessMessage = "User [" + user.Email + "] is deactivated";
                    }
                }

                return RedirectToAction("Index", "ManageUsers");
            }

            return View(user);
        }

        private bool UserExists(string email)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var user = db.ApplicationUser.Where(model => model.Email.ToUpper() == email.ToUpper()).FirstOrDefault();

                if (user == null)
                {
                    return false;
                }

                return true;
            }
        }

      }
}
