using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class Test
	{
		TimeSpan unMes;
		Contexto contexto;

		[SetUp]
		public void SetUp()
		{
			unMes = TimeSpan.FromDays(30);
			contexto = new Contexto();
		}

		[Test()]
		public void PagaTodoLoSolicitado()
		{
			Criterio criterio = new CriterioMontoMaximo(300m);

			var reintegro = criterio.Calcular(contexto, new Concepto(300m));

			Assert.That(reintegro, Is.EqualTo(300m));
		}

		[Test()]
		public void ReintegraHastaUnTope()
		{
			Criterio criterio = new CriterioMontoMaximo(200m);

			var reintegro = criterio.Calcular(contexto, new Concepto(300m));

			Assert.That(reintegro, Is.EqualTo(200m));
		}

		[Test()]
		public void NoReintegraExcederMontoMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 300));
			Criterio criterio = new CriterioMontoAcumuladoEnPeriodo(300, unMes);

			var reintegro = criterio.Calcular(contexto, new Concepto(10));

			Assert.That(reintegro, Is.EqualTo(0));
		}

		[Test()]
		public void ReintegraPorConsultaRemanenteMontoMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 200m));
			Criterio criterio = new CriterioMontoAcumuladoEnPeriodo(300m, unMes);

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(100m));
		}

		[Test()]
		public void ReintegraPorConsultaRemanenteCantidadMensual()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(1, 200m));
			Criterio criterio = new CriterioCantidadAcumuladaEnPeriodo(2, unMes);

			var reintegro = criterio.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(200m));
		}

		[Test()]
		public void NoReintegraPorExcederCantidadMensualAunqueMontoAlcance()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(2, 400m));
			Criterio criterioConjunto = new CriterioMenorMonto(
				new CriterioMontoAcumuladoEnPeriodo(600m, unMes),
				new CriterioCantidadAcumuladaEnPeriodo(2, unMes)
			);

			var reintegro = criterioConjunto.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(0));
		}

		[Test()]
		public void DebeAcumularReintegrosEnHistorialYTomarlosEnCuentaEnOtroCalculo()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(1, 400m));

			Criterio criterioConjunto = new CriterioMenorMonto(
				new CriterioMontoAcumuladoEnPeriodo(600m, unMes),
				new CriterioCantidadAcumuladaEnPeriodo(2, unMes)
			);

			var adapter = new CriterioActualizadorDeHistorialDecorator(criterioConjunto);

			var reintegro1 = adapter.Calcular(contexto, new Concepto(200m));
			var reintegro2 = adapter.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro1, Is.EqualTo(200m));
			Assert.That(reintegro2, Is.EqualTo(0m));
		}

		[Test()]
		public void ReintegroVacunaH1N1Afiliado50PorCiento()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));
			contexto["esAfiliado"] = true;
			contexto["edad"] = 35;
			Criterio criterioH1N1 = new CriterioH1N1();

			var reintegro = criterioH1N1.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(100m));
		}

		[Test()]
		public void ReintegroVacunaH1N1Beneficiario20Porciento()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));
			contexto["esAfiliado"] = false;
			contexto["edad"] = 35;
			Criterio criterioH1N1 = new CriterioH1N1();

			var reintegro = criterioH1N1.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(40m));
		}

		[Test()]
		public void ReintegroVacunaH1N16Anios30Porciento()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));
			contexto["esAfiliado"] = false;
			contexto["edad"] = 5;
			Criterio criterioH1N1 = new CriterioH1N1();

			var reintegro = criterioH1N1.Calcular(contexto, new Concepto(200m));

			Assert.That(reintegro, Is.EqualTo(60));
		}
	}
}