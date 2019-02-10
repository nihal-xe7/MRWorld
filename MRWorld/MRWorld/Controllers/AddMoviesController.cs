using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using MRWorld.Models;

namespace MRWorld.Controllers
{
    public class AddMoviesController : Controller
    {
        public ApplicationDbContext _context;

        public AddMoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //
        // GET: /AddMovies/
        public ActionResult Index()
        {
            if(Session["UserId"]!=null)
            return View();
            else
            {
                TempData["msg"] = "<script>alert('You Have To login first.......');</script>";
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult AddMovieData(string name, string genre, string date, string rating,string description)
        {
            var mv = _context.Movies.Where(m => m.Name == name && m.Genre == genre && m.ReleaseDate == date).ToList();
            if (mv.Count > 0)
            {
                return Json(new {Message = "This Movie Already Added By Other User.\n Add New One.", JsonRequestBehavior.AllowGet});
            }
            else
            {
                var mov = new Movie() {Name = name, Genre = genre, ReleaseDate = date, Rating = rating,Description = description};
                
                _context.Movies.Add(mov);
                _context.SaveChanges();
                var mvv = _context.Movies.ToList();
                int c = mvv.Count();
                var addmv = new AddMovie()
                {
                    UserId = int.Parse(Session["UserId"].ToString()), MovieId = mvv[c-1].Id,
                    Date = DateTime.Now.ToString("dd-MM-yyyy")
                };
                _context.AddingData.Add(addmv);
                _context.SaveChanges();
                return Json(new {Message = "Success", JsonRequestBehavior.AllowGet});
            }

        }
    }
}