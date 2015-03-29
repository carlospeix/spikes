namespace FormsApp
{
	public class TennisPresenter
	{
		private readonly ITennisView _view;

		public TennisPresenter(ITennisView view)
		{
			_view = view;
		}

		public void Inicializar(string jugador1, string jugador2)
		{
			_view.SetTitulo(jugador1 + " vs " + jugador2);
		}
	}
}