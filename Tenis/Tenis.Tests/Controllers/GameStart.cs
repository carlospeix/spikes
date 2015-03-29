using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tenis.Controllers;

namespace Tenis.Tests.Controllers
{
	[TestClass]
	public class Inicio
	{
		HomeController _controller;

		[TestInitialize]
		public void Initialize()
		{
			_controller = new HomeController(new TestSessionStore());
		}

		[TestMethod]
		public void StartPage()
		{
			var result = _controller.Index();
			Assert.AreEqual("Index", result.ViewName);
		}

		[TestMethod]
		public void HappyPathStart()
		{
			var result = _controller.Start("Federer", "Nadal");
			Assert.AreEqual("Game", result.ViewName);
			Assert.AreEqual("Federer vs Nadal", result.ViewBag.Title);
		}

		[TestMethod]
		public void PlayerOneNotSpecified()
		{
			var result = _controller.Start("", "Nadal");
			Assert.AreEqual("Index", result.ViewName);
			Assert.AreEqual("You should input a name for the first player", result.ViewBag.ErrorMessage);
		}

		[TestMethod]
		public void PlayerTwoNotSpecified()
		{
			var result = _controller.Start("Federer", "");
			Assert.AreEqual("Index", result.ViewName);
			Assert.AreEqual("You should input a name for the second player", result.ViewBag.ErrorMessage);
		}
	}
}
