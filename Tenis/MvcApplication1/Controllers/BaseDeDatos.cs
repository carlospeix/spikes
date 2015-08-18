using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
	public class BaseDeDatos
	{
		private TennisBoard _tenisboard;

		public void Guardar(TennisBoard tenisboard)
		{
			_tenisboard = tenisboard;
		}

		public TennisBoard Leer()
		{
			return _tenisboard;
		}
	}
}