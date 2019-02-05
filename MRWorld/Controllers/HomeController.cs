using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRWorld.Models;

namespace MRWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Users user)
        {

            if (Session["UserId"] != null)
                return View(user);
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult MovieList()
        {
            return RedirectToAction("Index","Movie");
          
        }
    }
}