using System;

namespace Reintegros.Modelo
{
	public class CriterioMontoAcumuladoEnPeriodo : Criterio
	{
		decimal montoMaximo;
		TimeSpan periodo;

		public CriterioMontoAcumuladoEnPeriodo(decimal montoMaximo, TimeSpan periodo)
		{
			this.montoMaximo = montoMaximo;
			this.periodo = periodo;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(this.periodo);
			var montoReintegro = montoMaximo - historial.Monto;

			if (montoReintegro < 0)
				montoReintegro = 0;

			if (concepto.MontoReclamado > montoReintegro)
				return montoReintegro;

			return concepto.MontoReclamado;
		}
	}
}