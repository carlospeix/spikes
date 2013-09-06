using System;

namespace FormsApp
{
	public class Presenter
	{
		private readonly IView _vista;
		private readonly DateTime _fechaActual;

		public Presenter(IView vista)
		{
			_vista = vista;
			_fechaActual = DateTime.Today;
		}

		public Presenter(IView vista, DateTime fechaActual)
		{
			_vista = vista;
			_fechaActual = fechaActual;
		}

		public void Initialize()
		{
			_vista.InicializarCampoIngresos(10, 10, "Ingresos:", true);
			_vista.InicializarCampoEgresos(50, 10, "Egresos:", true);
			if (_fechaActual.Year != 2002)
				_vista.InicializarCampoImpuestos(10, 20, "Imp Emergencia:", true);
		}

		public int CalcularTotal(int ingresos, int egresos, int impEmergencia)
		{
			return ingresos - egresos - impEmergencia;
		}

		public bool Grabar(int ingresos, int egresos, int impEmergencia)
		{
			if (CalcularTotal(ingresos, egresos, impEmergencia) > 0)
				return true;
			return false;
		}
	}
}