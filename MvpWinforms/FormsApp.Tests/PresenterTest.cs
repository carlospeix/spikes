using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormsApp.Tests
{

	[TestClass]
	public class PresenterTest
	{
		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		#endregion

		/// <summary>
		/// Ejemplos:
		/// - El formulario debe contener tres inputs numericos
		/// - Uno de ellos no debe aparecer en reportes del año 2002
		/// - El total es la ingresos - egresos - impuestos
		/// - Si el total es mayor que 0, se puede grabar
		/// </summary>

		[TestMethod]
		public void InicializoCampoIngresos()
		{
			var vista = new FakeView();
			var p = new Presenter(vista);

			p.Initialize();

			Assert.IsTrue(vista.CampoIngresosVisible(), "El campo 1 no fue inicializado correctamente.");
		}

		[TestMethod]
		public void InicializoCampoEgresos()
		{
			var vista = new FakeView();
			var p = new Presenter(vista);

			p.Initialize();

			Assert.IsTrue(vista.CampoEgresosVisible(), "El campo 2 no fue inicializado correctamente.");
		}

		[TestMethod]
		public void InicializoCampoImpuestos()
		{
			var vista = new FakeView();
			var p = new Presenter(vista);

			p.Initialize();

			Assert.IsTrue(vista.CampoImpuestosVisible(), "El campo 3 no fue inicializado correctamente.");
		}

		[TestMethod]
		public void NoInicializoCampoImpuestosEnAnio2002()
		{
			var vista = new FakeView();
			var p = new Presenter(vista, new DateTime(2002, 1, 1));

			p.Initialize();

			Assert.IsFalse(vista.CampoImpuestosVisible(), "El campo 3 fue inicializado en año 2002.");
		}

		[TestMethod]
		public void CalculoDeTotal()
		{
			var vista = new FakeView();
			var p = new Presenter(vista, new DateTime(2002, 1, 1));

			p.Initialize();

			Assert.AreEqual(13, p.CalcularTotal(20, 5, 2));
		}

		[TestMethod]
		public void GrabacionExitosa()
		{
			var vista = new FakeView();
			var p = new Presenter(vista);

			p.Initialize();

			Assert.IsTrue(p.Grabar(30, 10, 4), "Deberia haber grabado con estos datos");
		}

		[TestMethod]
		public void GrabacionFallida()
		{
			var vista = new FakeView();
			var p = new Presenter(vista);

			p.Initialize();

			Assert.IsFalse(p.Grabar(10, 10, 4), "No deberia haber grabado con estos datos");
		}
	}

	public class FakeView : IView
	{
		bool _campoIngresosVisible;
		bool _campoEgresosVisible;
		bool _campoImpuestosVisible;

		public void InicializarCampoIngresos(int x, int y, string etiqueta, bool visible)
		{
			_campoIngresosVisible = visible;
		}

		public void InicializarCampoEgresos(int x, int y, string etuiqueta, bool visible)
		{
			_campoEgresosVisible = visible;
		}

		public void InicializarCampoImpuestos(int x, int y, string etuiqueta, bool visible)
		{
			_campoImpuestosVisible = visible;
		}

		public bool CampoIngresosVisible()
		{
			return _campoIngresosVisible;
		}

		public bool CampoEgresosVisible()
		{
			return _campoEgresosVisible;
		}

		public bool CampoImpuestosVisible()
		{
			return _campoImpuestosVisible;
		}
	}
}