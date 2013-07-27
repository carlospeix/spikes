using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriteriosAcumuladosEnAnioCalendarioTest
	{
		Contexto contexto;
		Criterio criterioMonto, criterioCantidad;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			criterioMonto = new CriterioMontoAcumuladoEnAnioCalendario(300);
			criterioCantidad = new CriterioCantidadAcumuladaEnAnioCalendario(2);
		}

		[Test()]
		public void ConstruyeCorrectamenteElFiltroPorAñoCalendarioMonto()
		{
			var concepto = new Concepto(200, new DateTime(2013, 10, 10));
			DateRange periodoCalculado = null;

			// Capturo el periodo para chequear si el criterio lo calcula correctamente
			contexto.DefinirBuscadorDeHistorial((periodo) => {
				periodoCalculado = periodo;
				return new Historial(0, 0m);
			});

			criterioMonto.Calcular(contexto, concepto);

			Assert.That(periodoCalculado.Desde, Is.EqualTo(new DateTime(2013, 1, 1)));
			Assert.That(periodoCalculado.Hasta, Is.EqualTo(new DateTime(2013, 12, 31)));
		}

		[Test()]
		public void ConstruyeCorrectamenteElFiltroPorAñoCalendarioCantidad()
		{
			var concepto = new Concepto(200, new DateTime(2013, 10, 10));
			DateRange periodoCalculado = null;

			// Capturo el periodo para chequear si el criterio lo calcula correctamente
			contexto.DefinirBuscadorDeHistorial((periodo) => {
				periodoCalculado = periodo;
				return new Historial(0, 0m);
			});

			criterioCantidad.Calcular(contexto, concepto);

			Assert.That(periodoCalculado.Desde, Is.EqualTo(new DateTime(2013, 1, 1)));
			Assert.That(periodoCalculado.Hasta, Is.EqualTo(new DateTime(2013, 12, 31)));
		}
	}
}