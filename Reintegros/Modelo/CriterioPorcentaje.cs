using System;
using System.Linq;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	public class CriterioPorcentaje : Criterio
	{
		int porcentaje;

        public CriterioPorcentaje(int porcentaje)
		{
            this.porcentaje = porcentaje;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
            var porcentajeReintegro = this.porcentaje;

            return Decimal.Round(concepto.MontoReclamado * porcentajeReintegro / 100, 2);
		}
	}
}

