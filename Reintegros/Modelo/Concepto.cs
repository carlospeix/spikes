using System;

namespace Reintegros.Modelo
{
	public class Concepto
	{
		decimal montoReclamado;
		TimeSpan rangoUtilizado;

		public Concepto(decimal montoReclamado)
		{
			this.montoReclamado = montoReclamado;
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

		public TimeSpan RangoUtilizado
		{
			get { return rangoUtilizado; }
		}
	}
}