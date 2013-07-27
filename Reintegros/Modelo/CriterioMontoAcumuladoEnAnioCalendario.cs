using System;

namespace Reintegros.Modelo
{
	public class CriterioMontoAcumuladoEnAnioCalendario : Criterio
	{
		decimal montoMaximo;

		public CriterioMontoAcumuladoEnAnioCalendario(decimal montoMaximo)
		{
			this.montoMaximo = montoMaximo;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(DateRange.AnioCalendarioParaFecha(concepto.FechaPrestacion));
			var montoReintegro = montoMaximo - historial.Monto;

			if (montoReintegro < 0)
				montoReintegro = 0;

			if (concepto.MontoReclamado > montoReintegro)
				return montoReintegro;

			return concepto.MontoReclamado;
		}
	}
}