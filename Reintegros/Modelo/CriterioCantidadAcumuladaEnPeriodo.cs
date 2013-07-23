using System;

namespace Reintegros.Modelo
{
	public class CriterioCantidadAcumuladaEnPeriodo : Criterio
	{
		decimal cantidadMaxima;
		TimeSpan periodo;

		public CriterioCantidadAcumuladaEnPeriodo(decimal montoMaximo, TimeSpan periodo)
		{
			this.cantidadMaxima = montoMaximo;
			this.periodo = periodo;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(DateRange.PasadoDesdeHoy(this.periodo));
			var montoReintegro = cantidadMaxima <= historial.Cantidad ? 0m : concepto.MontoReclamado;

			return montoReintegro;
		}
	}
}