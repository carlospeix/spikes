using System;

namespace Reintegros.Modelo
{
	public class Concepto
	{
		decimal montoReclamado;
		DateTime fechaPrestacion;
		TimeSpan rangoUtilizado;

		public Concepto(decimal montoReclamado)
		{
			this.montoReclamado = montoReclamado;
		}

		public Concepto(decimal montoReclamado, DateTime fechaPrestacion)
		{
			this.montoReclamado = montoReclamado;
			this.fechaPrestacion = fechaPrestacion;
		}

		public Concepto(decimal montoReclamado, TimeSpan rango)
		{
			this.montoReclamado = montoReclamado;
			this.rangoUtilizado = rango;
		}

		public decimal MontoReclamado
		{
			get { return montoReclamado; }
		}

		public DateTime FechaPrestacion
		{
			get { return fechaPrestacion; }
		}

		public TimeSpan RangoUtilizado
		{
			get { return rangoUtilizado; }
		}
	}
}