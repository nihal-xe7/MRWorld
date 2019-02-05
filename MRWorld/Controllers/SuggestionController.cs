using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MRWorld.Models;

namespace MRWorld.Controllers
{
	public class SuggestionController : Controller
	{
		public ApplicationDbContext _context;

		public  SuggestionController()
		{
			_context=new ApplicationDbContext();
		}

		//
		// GET: /Suggestion/
		public ActionResult Index()
		{

			if (Session["UserId"] != null)
			{
				var mvD = _context.AddingData.ToList();

				List<Suggestion> listData = new List<Suggestion>();

				foreach (var mv in mvD)
				{
					var movie = _context.Movies.FirstOrDefault(m => m.Id == mv.MovieId);
					var user = _context.Users.FirstOrDefault(u => u.Id == mv.UserId);
					listData.Add(new Suggestion()
					{
						MovieName = movie.Name, AddedBy = user.Name, ReleaseDate = movie.ReleaseDate,
						Rating = movie.Rating, Genre = movie.Genre,Id=movie.Id
					});

				}

				return View(listData);
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		public ActionResult GetMovies(string t, string val)
		{
			var movie = _context.Movies.ToList();
			
			if (t.Equals("Genre"))
			{
			   movie = _context.Movies.Where(m =>m.Genre ==val).ToList();
			}
			else if (t.Equals("Rating"))
			{
			  movie = _context.Movies.Where(m => m.Rating == val).ToList();

			}

			List<Suggestion> listData = new List<Suggestion>();

			foreach (var mv in movie)
			{
				var mvx = _context.AddingData.Where(m => m.MovieId == mv.Id);
				var x = mvx.ToList();

				if (x.Count>0)
				{
				  var  mvD = _context.AddingData.FirstOrDefault(m => m.MovieId == mv.Id);
					var user = _context.Users.FirstOrDefault(u => u.Id == mvD.UserId);
					listData.Add(new Suggestion()
					{
						MovieName = mv.Name,
						AddedBy = user.Name,
						ReleaseDate = mv.ReleaseDate,
						Rating = mv.Rating,
						Genre = mv.Genre,
						Id = mv.Id
					});
				}
			}

			return View(listData);
		}

	   
	}
}