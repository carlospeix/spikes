using System;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	/// <summary>
	/// Asi me imagino la clase Regla, con una coleccion de criterios, privada.
	/// 
	/// Esta regla estará asociada a uno o mas conceptos, de la manera mas adecuada
	/// de acuerdo a las posibilidades del ORM
	/// 
	/// Otro de los datos de esta regla es si funciona por el mecanismo "menor de
	/// todos los montos" o "mayor de todos los montos".
	/// 
	/// Por ultimo, ObtenerCriterio() o similar, debe asegurarse de devolver
	/// los criterios "envueltos" por el decorator de actualizacion de historial.
	/// </summary>
	public class Regla
	{
		// Coleccion de los criterios
		IList<Criterio> criterios;

		// veran ustedes la mejor manera de implementar este dato
		string modo = "menor";

		public Regla()
		{
			criterios = new List<Criterio>();
		}

		public Criterio ObtenerCriterio()
		{
			Criterio criterio;

			if ("menor".Equals(modo))
				criterio = new CriterioMenorMonto(criterios);
			else
				criterio = new CriterioMayorMonto(criterios);
				
			return new CriterioActualizadorDeHistorialAdapter(criterio);
		}
	}
}