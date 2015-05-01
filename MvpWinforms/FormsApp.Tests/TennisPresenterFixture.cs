using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
X- Si juegan Federer y Nadal titulo debe ser "Federer vs Nadal"
X- Si juegan Del Potro y Djokovic titulo debe ser "Del Potro vs Djokovic"
- Si el partido recien comienza el marcador debe ser 0 - 0
- Si el jugador 1 gana el primer punto el marcador debe ser 15 - 0
- Si el jugador 1 gana dos puntos punto el marcador debe ser 30 - 0
- Si el jugador 2 gana el primer punto el marcador debe ser 0 - 15
- Si el jugador 2 gana tres puntos el marcador debe ser 0 - 40
- Si el game esta 40 - 0 y el jugador 1 gana punto, el marcador debe ser 0 - 0
 */

namespace FormsApp.Tests
{
	[TestClass]
	public class TennisPresenterFixture
	{
		private JuegoPresenter _presenter;
		private JuegoVistaTest _view;

		[TestMethod]
		public void ArriesgoPrimeaLetraYAcierto()
		{
			DadoQueInicioElJuegoConLaPalabra("Jungla");

			CuandoArriesgoLaLetra("a");

			DeboVerLaPlantilla("_ _ _ _ A");
		}

		private void DeboVerLaPlantilla(string plantillaEsperada)
		{
			Assert.AreEqual(plantillaEsperada, _view.TEST_Plantilla());
		}

		private void CuandoArriesgoLaLetra(string letra)
		{
			_presenter.LetraArriesgada(letra);
		}

		private void DadoQueInicioElJuegoConLaPalabra(string palabraSecreta)
		{
			_view = new JuegoVistaTest();
			_presenter = new JuegoPresenter(_view, palabraSecreta);
		}


		[TestMethod]
		public void TestMethod1()
		{
			var view = new TennisView();
			var presenter = new TennisPresenter(view);
			presenter.Inicializar("Federer", "Nadal");
			Assert.AreEqual("Federer vs Nadal", view.GetTitulo());
		}
	}

	public class JuegoVistaTest
	{
		private string plantilla;

		public string TEST_Plantilla()
		{
			return plantilla;
		}

		public void MostrarPlantilla(string plantilla)
		{
			this.plantilla = plantilla;
		}
	}

	public class TennisView : ITennisView
	{
		private string _titulo;

		public string GetTitulo()
		{
			return _titulo;
		}

		public void SetTitulo(string titulo)
		{
			_titulo = titulo;
		}
	}
}
