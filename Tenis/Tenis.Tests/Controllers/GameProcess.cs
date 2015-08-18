using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tenis.Controllers;

namespace Tenis.Tests.Controllers
{
	[TestClass]
	public class GameProcess
	{
		HomeController controller;

		[TestInitialize]
		public void Initialize()
		{
			controller = new HomeController(new TestSessionStore());
		}

		[TestMethod]
		public void GameStartsInZero()
		{
			var result = controller.Start("?", "?");
			Assert.AreEqual("Game", result.ViewName);
			Assert.AreEqual("0 - 0", result.ViewBag.Result);
		}

		[TestMethod]
		public void PlayerOneScores()
		{
			var result = controller.Start("?", "?");
			controller.PlayerOneScores();
			Assert.AreEqual("15 - 0", result.ViewBag.Result);
		}

		[TestMethod]
		public void PlayerOneAndTwoScores()
		{
			var result = controller.Start("?", "?");
			controller.PlayerOneScores();
			controller.PlayerTwoScores();
			Assert.AreEqual("15 - 15", result.ViewBag.Result);
		}
	}
}
