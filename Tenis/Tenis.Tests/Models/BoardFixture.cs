using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tenis.Models;

namespace Tenis.Tests.Models
{
	[TestClass]
	public class BoardFixture
	{
		[TestMethod]
		public void BoardTitleWithPlayerNames()
		{
			var board = new TennisBoard("Federer", "Nadal");
			Assert.AreEqual("Federer vs Nadal", board.Title);
		}

		[TestMethod]
		public void BoardTitleWithOtherPlayerNames()
		{
			var board = new TennisBoard("Rios", "Nalbandian");
			Assert.AreEqual("Rios vs Nalbandian", board.Title);
		}

		[TestMethod]
		public void GameStartsInZero()
		{
			var board = new TennisBoard("X", "Y");
			Assert.AreEqual("0 - 0", board.Result);
		}

		[TestMethod]
		public void PlayerOneScores()
		{
			var board = new TennisBoard("X", "Y");
			board.Player1Scores();
			Assert.AreEqual("15 - 0", board.Result);
		}

		[TestMethod]
		public void PlayerOneScoresTwoTimes()
		{
			var board = new TennisBoard("X", "Y");
			board.Player1Scores();
			board.Player1Scores();
			Assert.AreEqual("30 - 0", board.Result);
		}

		[TestMethod]
		public void PlayerTwoScores()
		{
			var board = new TennisBoard("X", "Y");
			board.Player2Scores();
			Assert.AreEqual("0 - 15", board.Result);
		}

		[TestMethod]
		public void PlayerTwoScoresThreeTimes()
		{
			var board = new TennisBoard("X", "Y");
			board.Player2Scores();
			board.Player2Scores();
			board.Player2Scores();
			Assert.AreEqual("0 - 40", board.Result);
		}

	}
}
