using System;

namespace Reintegros.Modelo
{
	public class CriterioMontoMaximo : Criterio
	{
		decimal montoMaximo;

		public CriterioMontoMaximo (decimal montoMaximo)
		{
			this.montoMaximo = montoMaximo;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var montoReintegro = this.montoMaximo;

			if (concepto.MontoReclamado > montoReintegro)
				return montoReintegro;

			return concepto.MontoReclamado;
		}
	}

}

