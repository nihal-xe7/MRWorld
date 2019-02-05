using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
	}
}