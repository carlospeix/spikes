using System;

namespace Reintegros.Modelo
{
	public class CriterioCantidadAcumuladaEnPeriodo : Criterio
	{
		int cantidadMaxima;
		TimeSpan periodo;

		public CriterioCantidadAcumuladaEnPeriodo(int cantidadMaxima, TimeSpan periodo)
		{
            this.cantidadMaxima = cantidadMaxima;
			this.periodo = periodo;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(this.periodo);
			var montoReintegro = cantidadMaxima <= historial.Cantidad ? 0m : concepto.MontoReclamado;

			return montoReintegro;
		}
	}
}