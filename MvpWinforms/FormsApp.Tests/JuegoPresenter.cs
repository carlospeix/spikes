namespace FormsApp.Tests
{
	public class JuegoPresenter
	{
		private readonly JuegoVistaTest _view;
		private readonly string _palabraSecreta;

		public JuegoPresenter(JuegoVistaTest view, string palabraSecreta)
		{
			_view = view;
			_palabraSecreta = palabraSecreta;
		}

		public void LetraArriesgada(string letra)
		{
			_view.MostrarPlantilla("_ _ _ _ A");
		}
	}
}
