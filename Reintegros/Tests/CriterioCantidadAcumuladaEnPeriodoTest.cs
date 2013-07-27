using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriterioCantidadAcumuladaEnPeriodoTest
	{
		Contexto contexto;
		Criterio criterio;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			var unMes = TimeSpan.FromDays(30);
			criterio = new CriterioCantidadAcumuladaEnPeriodo(2, unMes);
		}

		[Test()]
		public void ReintegraPorConsultaRemanenteCantidadMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(1, 200m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(200m));
		}

		[Test()]
		public void ReintegraPorConsultaElTotalPorNoExcederCantidadMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(200m));
		}

		[Test()]
		public void NoReintegraPorExcederCantidadMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(2, 400m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(0m));
		}
	}
}