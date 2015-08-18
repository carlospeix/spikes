using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
	[TestClass]
	public class JuegoControllerTest
	{
		[TestMethod]
		public void InicioJuegoTest()
		{
			var datos = new BaseDeDatos();
			var juego = new JuegoController(datos);

			var result = juego.Inicio("x", "y");

			Assert.AreEqual("0 - 0", result.ViewBag.Puntaje);
		}

		[TestMethod]
		public void Puntaje15CeroTest()
		{
			var datos = new BaseDeDatos();
			var juego = new JuegoController(datos);

			juego.Inicio("x", "y");

			var result = juego.Punto1();

			Assert.AreEqual("15 - 0", result.ViewBag.Puntaje);
		}
	}
}