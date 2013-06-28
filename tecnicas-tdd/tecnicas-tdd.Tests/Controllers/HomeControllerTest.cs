using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tecnicas_tdd;
using tecnicas_tdd.Controllers;

namespace tecnicas_tdd.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index_GreetsInTheMorning()
		{
			// Arrange
			HomeController controller = new HomeController(
				new FakeClock(new DateTime(2013, 6, 27, 10, 0, 0))
			);

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			ViewDataDictionary viewData = result.ViewData;
			Assert.AreEqual("Good morning", viewData["Message"]);
		}

		[TestMethod]
		public void Index_GreetsInTheEvening()
		{
			// Arrange
			HomeController controller = new HomeController(
				new FakeClock(new DateTime(2013, 6, 27, 14, 0, 0))
			);

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			ViewDataDictionary viewData = result.ViewData;
			Assert.AreEqual("Good evening", viewData["Message"]);
		}

		[TestMethod]
		public void About()
		{
			// Arrange
			HomeController controller = new HomeController(
				new FakeClock(new DateTime(2013, 6, 27, 10, 0, 0))
			);

			// Act
			ViewResult result = controller.About() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}