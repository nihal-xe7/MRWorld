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
        public ApplicationDbContext _context;

        public HomeController()
        {
            _context=new ApplicationDbContext();
        }
        public ActionResult Index(Users user)
        {

            if (Session["UserId"] != null)
                return View(user);
            else
            {
                TempData["msg"] = "<script>alert('You Have To login first.......');</script>";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult MovieList()
        {
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult UserData()
        {
            int id=int.Parse(Session["UserId"].ToString());
            var user =(Users) _context.Users.FirstOrDefault(u => u.Id == id);
            var mov = _context.AddingData.Where(a => a.UserId == id).ToList();
            int count = mov.Count;

            user.MovieAdded = count;

            return View(user);
        }
}
}