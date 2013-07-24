using System;
using System.Linq;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	public class CriterioMenorMonto : Criterio
	{
		IList<Criterio> criterios;

		public CriterioMenorMonto(IList<Criterio> criterios) : this(criterios.ToArray())
		{
		}

		public CriterioMenorMonto(params Criterio[] criterios)
		{
			this.criterios = new List<Criterio>(criterios);
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			return this.criterios.Min(criterio => criterio.Calcular(contexto, concepto));
		}
	}
}

