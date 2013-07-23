using System;
using System.Linq;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	public class CriterioMayorMonto : Criterio
	{
		IList<Criterio> criterios;

		public CriterioMayorMonto(IList<Criterio> criterios) : this(criterios.ToArray())
		{
		}

		public CriterioMayorMonto(params Criterio[] criterios)
		{
			this.criterios = new List<Criterio>(criterios);
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			return this.criterios.Max(criterio => criterio.Calcular(contexto, concepto));
		}
	}
}

