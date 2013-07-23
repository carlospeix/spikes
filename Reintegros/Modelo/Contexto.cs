using System;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	public class Contexto
	{
		Func<DateRange, Historial> buscadorDeHistorial;
		Historial historialTemporal;
		IDictionary<string, object> variables;

		public Contexto()
		{
			buscadorDeHistorial = (periodo) => new Historial(0, 0m);
			historialTemporal = new Historial(0, 0m);
			variables = new Dictionary<string, object>();
		}

		public void DefinirBuscadorDeHistorial(Func<DateRange, Historial> buscadorDeHistorial)
		{
			this.buscadorDeHistorial = buscadorDeHistorial;
		}

		public Historial ObtenerHistorial(DateRange periodo)
		{
			return buscadorDeHistorial(periodo) + historialTemporal;
		}

		public void RegistrarReintegroTemporal(decimal reintegro)
		{
			this.historialTemporal.SumarCantidad(1);
			this.historialTemporal.SumarMonto(reintegro);
		}

		public object this[string key]
		{
			get { return variables[key]; }
			set { variables[key] = value; }
		}

		public T Variable<T>(string key)
		{
			if (!variables.ContainsKey(key))
				throw new InvalidOperationException(String.Format("No existe la variable de contexto {0}.", key));

			if (variables[key].GetType() != typeof(T))
				throw new InvalidOperationException(
					String.Format("Conflicto de tipos de variable de contexto {0}. en el contexto. Esperado {1}, almacenado {2}.", 
					              key, typeof(T), variables[key].GetType()));

			return (T)variables[key];
		}
	}
}