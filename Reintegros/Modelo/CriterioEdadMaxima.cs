using System;
using System.Linq;
using System.Collections.Generic;

namespace Reintegros.Modelo
{
	public class CriterioEdadMaxima : Criterio
	{
		int edad;

        public CriterioEdadMaxima(int edad)
		{
            this.edad = edad;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			if (contexto.Variable<int>("edad") <= this.edad)
            	return concepto.MontoReclamado;

            return 0m;
		}
	}
}

