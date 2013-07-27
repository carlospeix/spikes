using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriterioMontoAcumuladoEnPeriodoTest
	{
		Contexto contexto;
		Criterio criterio;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			var unMes = TimeSpan.FromDays(30);
			criterio = new CriterioMontoAcumuladoEnPeriodo(300, unMes);
		}

		[Test()]
		public void NoReintegraExcederMontoMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 300));

			var reintegro = criterio.Calcular(contexto, new Concepto(10));

			Assert.That(reintegro, Is.EqualTo(0));
		}

		[Test()]
		public void ReintegraPorConsultaElTotalPorNoEscederMontoMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(200m));
		}

		[Test()]
		public void ReintegraPorConsultaRemanenteMontoMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 200m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(100m));
		}
	}
}