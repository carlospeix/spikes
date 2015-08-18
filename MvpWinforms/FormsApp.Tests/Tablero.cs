namespace FormsApp.Tests
{
	public class Tablero
	{
		private readonly string _jugador1;
		private readonly string _jugador2;

		public Tablero(string jugador1, string jugador2)
		{
			_jugador1 = jugador1;
			_jugador2 = jugador2;
		}

		public string Titulo
		{
			get { return _jugador1 + " vs " + _jugador2; }
		}
	}
}