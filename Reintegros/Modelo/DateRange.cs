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
			return new DateRange(DateTime.Today.Subtract(periodo), DateTime.Today);
		}
	}
}