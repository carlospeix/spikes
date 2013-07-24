using System;

namespace Reintegros.Modelo
{
	public class Historial
	{
		int cantidad;
		decimal monto;
        TimeSpan rango;

		public Historial(int cantidad, decimal monto)
		{
			this.cantidad = cantidad;
			this.monto = monto;
		}

        public Historial(int cantidad, decimal monto, TimeSpan rango)
        {
            this.cantidad = cantidad;
            this.monto = monto;
            this.rango = rango;
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

        public TimeSpan Rango
        {
            get { return this.rango; }
        }

		public static Historial operator +(Historial h1, Historial h2)
		{
			return new Historial(h1.cantidad + h2.cantidad, h1.monto + h2.monto, h1.rango + h2.rango);
		}

        public void SumarRango(TimeSpan rango)
        {
            this.rango += rango;
        }
	}
}
