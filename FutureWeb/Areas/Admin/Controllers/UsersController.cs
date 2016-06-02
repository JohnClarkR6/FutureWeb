using FutureWeb.Areas.Admin.ViewModels;
using FutureWeb.Infrastructure;
using FutureWeb.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")] //only lets users with admin role view
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(new UsersIndex        //uses the Users model in ViewModels
            {
                Users = Database.Session.Query<User>().ToList()    //Querys the Database to query the user model entity and turn it into a list
            });
        }

        public ActionResult New()  //create a new user , New action
        {
            return View(new UsersNew
            {
                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckbox   //allows you to give users roles
                {
                    Id = role.Id,
                    IsChecked = false,
                    Name = role.Name
                }).ToList()
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(UsersNew form)    //httppost for form on new action
        {
            var user = new User();
            SyncRoles(form.Roles, user.Roles);

            if (Database.Session.Query<User>().Any(u => u.Username == form.Username))     //querys the database for usernames, if it is unique it will continue
                ModelState.AddModelError("Username", "Username must be unique");

            if (!ModelState.IsValid)
                return View(form);

            user.Email = form.Email;
            user.Username = form.Username;
            user.SetPassword(form.Password);

            Database.Session.Save(user);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<User>(id);  //load us the user by the id
            if (user == null)                            //if it doesnt exists return http not found
                return HttpNotFound();

            return View(new UsersEdit
            {
                Username = user.Username,
                Email = user.Email,

                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckbox
                {
                    Id = role.Id,
                    IsChecked = user.Roles.Contains(role),
                    Name = role.Name
                }).ToList()
            });
         }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsersEdit form)
        {
            var user = Database.Session.Load<User>(id);   //load up user by Id to edit
            if (user == null)
                return HttpNotFound();

           SyncRoles(form.Roles, user.Roles);

            if (Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))   //make sure they wont use the same username, and if they dont change the username
                ModelState.AddModelError("username", "Username must be unique");   //if username is in the database but the id is not the same return

            if (!ModelState.IsValid)      //if anythign failed return to the form again
                return View(form); 

            user.Username = form.Username;    //updating the data ont he object and tell NHhibernate to update the database.
            user.Email = form.Email;
            Database.Session.Update(user);

            return RedirectToAction("index");   //return back to admin when complete
        }

        public ActionResult ResetPassword(int id)
        {
            var user = Database.Session.Load<User>(id);   //load up user from database
            if (user == null)
                return HttpNotFound();

            return View(new UsersResetPassword
            {
                Username = user.Username,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int id, UsersResetPassword form)
        {
            var user = Database.Session.Load<User>(id);  //load up user
            if (user == null)
                return HttpNotFound();

            form.Username = user.Username;    //make sure username are the same from database and controller

            if (!ModelState.IsValid)
                return View(form);

            user.SetPassword(form.Password);      //set new password
            Database.Session.Update(user);     //save new password

            return RedirectToAction("index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
                return HttpNotFound();

            Database.Session.Delete(user);
            return RedirectToAction("index");
        }

        private void SyncRoles(IList<RoleCheckbox> checkboxes, IList<Role> roles)
        {
            var selectedRoles = new List<Role>();

            foreach (var role in Database.Session.Query<Role>())
            {
                var checkbox = checkboxes.Single(c => c.Id == role.Id);
                checkbox.Name = role.Name;

                if (checkbox.IsChecked)
                    selectedRoles.Add(role);
            }

            foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
                roles.Add(toAdd);

            foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
                roles.Remove(toRemove);

        }
    }  
}