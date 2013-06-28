using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tecnicas_tdd.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		IClock clock;

		public HomeController(IClock clock)
		{
			this.clock = clock;
		}

		public ActionResult Index()
		{
			if (this.clock.Now.Hour < 12)
				ViewData["Message"] = "Good morning";
			else
				ViewData["Message"] = "Good evening";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}