using System;

namespace Reintegros.Modelo
{
	public class Historial
	{
		int cantidad;
		decimal monto;

		public Historial(int cantidad, decimal monto)
		{
			this.cantidad = cantidad;
			this.monto = monto;
		}

		public int Cantidad
		{
			get { return this.cantidad; }
		}

		public void SumarCantidad(int cantidad)
		{
			this.cantidad += cantidad;
		}

		public decimal Monto
		{
			get { return this.monto; }
		}

		public void SumarMonto(decimal monto)
		{
			this.monto += monto;
		}

		public static Historial operator +(Historial h1, Historial h2)
		{
			return new Historial(h1.cantidad + h2.cantidad, h1.monto + h2.monto);
		}
	}
}