using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
	public class JuegoController : Controller
	{
		private BaseDeDatos _datos;

		public JuegoController() : this(new BaseDeDatos())
		{
		}

		public JuegoController(BaseDeDatos datos)
		{
			_datos = datos;
		}

		public ViewResult Inicio(string p, string p_2)
		{
			var tenisboard = new TennisBoard("x", "x");
			_datos.Guardar(tenisboard);
			ViewBag.Puntaje = tenisboard.Result;

			return View("Juego");
		}


		public ViewResult Punto1()
		{
			var tenisboard = _datos.Leer();
			tenisboard.Player1Scores();

			ViewBag.Puntaje = tenisboard.Result;

			return View("Juego");
		}
	}
}