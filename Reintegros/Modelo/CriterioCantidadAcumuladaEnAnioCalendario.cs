using System;

namespace Reintegros.Modelo
{
	public class CriterioCantidadAcumuladaEnAnioCalendario : Criterio
	{
		int cantidadMaxima;

		public CriterioCantidadAcumuladaEnAnioCalendario(int cantidadMaxima)
		{
            this.cantidadMaxima = cantidadMaxima;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(DateRange.AnioCalendarioParaFecha(concepto.FechaPrestacion));
			var montoReintegro = cantidadMaxima <= historial.Cantidad ? 0m : concepto.MontoReclamado;

			return montoReintegro;
		}
	}
}