using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MRWorld.Models;

namespace MRWorld.Controllers
{
	public class MovieController : Controller
	{
		public ApplicationDbContext _context;
 
		public MovieController()
		{
			_context=new ApplicationDbContext();
		}

		//
		// GET: /Movie/
		public ActionResult Index()
		{
			if (Session["UserId"] != null)
			{
				var movie = _context.Movies.ToList();
				var users = _context.Users.ToList();
				var mvl = _context.AddingData.ToList();
				var mvList = new AddMovie() { Movies = movie, User = users, MovieList = mvl };
				return View(mvList);
			}
			else
			{
                TempData["msg"] = "<script>alert('You Have To login first.......');</script>";
				return RedirectToAction("Index", "Login");
			}
		   
		}
		public ActionResult MovieData(int id)
		{
			if (Session["UserId"] != null)
			{
				var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			   
				return View(movie);
			}
			else
			{
                TempData["msg"] = "<script>alert('You Have To login first.......');</script>";
				return RedirectToAction("Index", "Login");
			}

		}
	 

		public ActionResult MovieDetails(int id)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			return View(movie);
		}

		public ActionResult CollectData(string name)
		{
			var movie = _context.Movies.SqlQuery("Select * from Movies where Name like '"+name+"%'").ToList();
			if(movie==null)
				return Json(new { data = 0, JsonRequestBehavior.AllowGet });
			else
			{
				string str = "";
				foreach (var x in movie)
				{
					str += "<li onclick=location.replace('/Movie/MovieData/"+x.Id+"')>" + x.Name + "</li>";
				}

				return Json(new { data = str, JsonRequestBehavior.AllowGet });
			}
			
		}

        public ActionResult DeleteMovieIndex()
        {

            var movie = _context.Movies.ToList();
            return View(movie);
        }

        public ActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            TempData["msg"] = "<script>alert('Movie Deleted Successfully.......');</script>";
            return RedirectToAction("DeleteMovieIndex");
        }
	}
}