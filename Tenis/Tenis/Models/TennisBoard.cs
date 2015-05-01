using System;

namespace Tenis.Models
{
	public class TennisBoard
	{
		private readonly string _player1;
		private readonly string _player2;
		private string _score;
		private int _pointsPlayer1;
		private int _pointsPlayer2;

		public TennisBoard(string player1, string player2)
		{
			_player1 = player1;
			_player2 = player2;
			_pointsPlayer1 = 0;
			_pointsPlayer2 = 0;
		}

		public string Title
		{
			get { return String.Format("{0} vs {1}", _player1, _player2); }
		}

		public string Result
		{
			get { return String.Format("{0} - {1}", 
				GetTennisScore(_pointsPlayer1), 
				GetTennisScore(_pointsPlayer2)); }
		}

		public void Player1Scores()
		{
			_pointsPlayer1++;
		}

		public void Player2Scores()
		{
			_pointsPlayer2++;
		}

		private int GetTennisScore(int points)
		{
			switch (points)
			{
				case 1:
					return 15;
				case 2:
					return 30;
				case 3:
					return 40;
			}
			return points;
		}
	}
}