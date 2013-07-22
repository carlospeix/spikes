using System;

namespace Reintegros.Modelo
{
	public class Concepto
	{
		decimal montoReclamado;

		public Concepto(decimal montoReclamado)
		{
			this.montoReclamado = montoReclamado;
		}

		public decimal MontoReclamado
		{
			get { return montoReclamado; }
		}
	}
}