using System;
using System.Web.Mvc;
using Tenis.Models;

namespace Tenis.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISessionStore _sessionStore;

		public HomeController() : this(new SessionStore())
		{
		}

		public HomeController(ISessionStore sessionStore)
		{
			_sessionStore = sessionStore;
		}

		public ViewResult Index()
		{
			return View("Index");
		}

		public ViewResult Start(string player1, string player2)
		{
			if (String.IsNullOrWhiteSpace(player1))
			{
				ViewBag.ErrorMessage = "You should input a name for the first player";
				return View("Index");
			}
			if (String.IsNullOrWhiteSpace(player2))
			{
				ViewBag.ErrorMessage = "You should input a name for the second player";
				return View("Index");
			}

			var board = new TennisBoard(player1, player2);
			_sessionStore["Game"] = board;

			ViewBag.Title = board.Title;
			ViewBag.Result = board.Result;

			return View("Game");
		}

		public ViewResult PlayerOneScores()
		{
			var board = (TennisBoard)_sessionStore["Game"];
			board.Player1Scores();

			ViewBag.Title = board.Title;
			ViewBag.Result = board.Result;
			return View("Game");
		}

		public ViewResult PlayerTwoScores()
		{
			var board = (TennisBoard)_sessionStore["Game"];
			board.Player2Scores();

			ViewBag.Title = board.Title;
			ViewBag.Result = board.Result;
			return View("Game");
		}
	}
}