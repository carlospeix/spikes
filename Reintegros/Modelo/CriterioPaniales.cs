using System;

namespace Reintegros.Modelo
{
	/// <summary>
	/// Hay dos variantes para este algoritmo. Una es considerar que los 
	/// pañales corresponden desde el nacimiento del bebe.
	/// 
	/// La otra es que corresponde desde la primera fecha de reclamo de
	/// reintegro y desde ahi se calcula.
	/// </summary>
	public class CriterioPaniales : Criterio
	{
		int cantidadDiaria;
		decimal reintegroPorPanial;

		public CriterioPaniales (int cantidadDiaria, decimal reintegroPorPanial)
		{
			this.cantidadDiaria = cantidadDiaria;
			this.reintegroPorPanial = reintegroPorPanial;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var historial = contexto.ObtenerHistorial(
				new DateRange(contexto.Variable<DateTime>("fechaNacimiento"), concepto.FechaPrestacion));

			var fechaNacimiento = contexto.Variable<DateTime>("fechaNacimiento");
			var fechaReintegro = concepto.FechaPrestacion;

			var dias = fechaReintegro.Subtract(fechaNacimiento).Days;

			var cantidadPaniales = dias * this.cantidadDiaria;

			var reintegro = (cantidadPaniales - historial.Cantidad) * this.reintegroPorPanial;

			return reintegro;
		}
	}
}