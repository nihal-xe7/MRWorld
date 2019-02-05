using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRWorld.Models;

namespace MRWorld.Controllers
{
    public class LoginController : Controller
    {
        public ApplicationDbContext _context;

        public LoginController()
        {
            _context=new ApplicationDbContext();
        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            TempData["msg"] = "<script>alert('You Have To login first.......');</script>";
            var user = new Users();
            return View(user);
        }

        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCheck(Users user)
        {
            if (!ModelState.IsValid)
            {
                View("Index", user);
            }
            else
            {
                var usr = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.Id;
                    Session["UserName"] = usr.Name;
                    return RedirectToAction("Index", "Home", usr);
                }
                else
                {
                    return Content("Wrong Email Or Password");
                }
            }
            return Content("Wrong Email Or Password or empty");
        }
	}
}