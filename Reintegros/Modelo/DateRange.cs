using System;

namespace Reintegros.Modelo
{
	public class DateRange
	{
		public readonly DateTime Desde;
		public readonly DateTime Hasta;

		public DateRange(DateTime desde, DateTime hasta)
		{
			Desde = desde;
			Hasta = hasta;
		}

		public static DateRange PasadoDesdeHoy(TimeSpan periodo)
		{
			if (periodo.Equals(TimeSpan.MaxValue))
				return new DateRange(DateTime.MinValue, DateTime.Today);
			return new DateRange(DateTime.Today.Subtract(periodo), DateTime.Today);
		}

		public static DateRange AnioCalendarioParaFecha(DateTime fecha)
		{
			return new DateRange(new DateTime(fecha.Year, 1, 1), new DateTime(fecha.Year, 12, 31));
		}
	}
}