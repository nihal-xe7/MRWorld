using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MRWorld.Models;

namespace MRWorld.Controllers
{
	public class RegistrationController : Controller
	{
		//
		// GET: /Registration/

		public ApplicationDbContext _context;

		public RegistrationController()
		{
			_context=new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var registration = new Registration();
		   
				return View(registration);
		   
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Registration register)
		{
			if (!ModelState.IsValid)
			{
				View("Index", register);
			}
			var customer=new Users()
			{
				Name = register.Name,
				Email=register.Email,
				Password = register.Password,
				
			};

			_context.Users.Add(customer);
			_context.SaveChanges();

			var user = _context.Users.ToList();
			var c = user.Count;

			var id = user[c - 1].Id;

			var member=new MemberShip()
			{
				UserId = int.Parse(id.ToString()),
				MemberShipType = register.MemberShipType,
				Paid = "0",
				joinDate = DateTime.Now.ToString("dd-MM-yyyy"),
				ExpireDate = (DateTime.Now.ToString("dd-MM-")+(int.Parse(DateTime.Now.ToString("yyyy"))+1).ToString())
			};

			_context.MemberShips.Add(member);
			_context.SaveChanges();
			
			return RedirectToAction("Index","Login");

		  
		}
	}
}