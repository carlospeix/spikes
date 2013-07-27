using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class Test
	{
		TimeSpan unMes;
        TimeSpan todaLaVida;
		Contexto contexto;

		[SetUp]
		public void SetUp()
		{
			unMes = TimeSpan.FromDays(30);
            todaLaVida = TimeSpan.MaxValue;
			contexto = new Contexto();
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

			var adapter = new CriterioActualizadorDeHistorialAdapter(criterioConjunto);

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

        [Test()]
        public void ReintegroBonoBioquimico100Porciento()
        {
            contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));
            contexto["esAfiliado"] = true;
            Criterio criterioPorcentaje = new CriterioPorcentaje(100);

            var reintegro = criterioPorcentaje.Calcular(contexto, new Concepto(200m));

            Assert.That(reintegro, Is.EqualTo(200m));
        }

        [Test()]
        public void ReintegroAlquilerAndadorConAsiento3Meses50PeXMes()
        {
//            contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));
//
//            Criterio criterioConjunto = new CriterioMenorMonto(
//                new CriterioMontoAcumuladoEnPeriodo(50m, unMes),
//                new CriterioRango(tresMeses)
//            );
//
//            var adapter = new CriterioActualizadorDeHistorialAdapter(criterioConjunto, unMes);
//
//            var reintegro1 = adapter.Calcular(contexto, new Concepto(10m));
//            var reintegro2 = adapter.Calcular(contexto, new Concepto(10m));
//            var reintegro3 = adapter.Calcular(contexto, new Concepto(10m));
//            var reintegro4 = adapter.Calcular(contexto, new Concepto(10m));
//            
//            Assert.That(reintegro1, Is.EqualTo(10m));
//            Assert.That(reintegro2, Is.EqualTo(10m));
//            Assert.That(reintegro3, Is.EqualTo(10m));
//            Assert.That(reintegro4, Is.EqualTo(0m));
        }

		[Test()]
		public void ReintegroAlquilerAndadorConAsiento3Meses50PeXMesAlternativo()
		{
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));

			Criterio criterioConjunto = new CriterioMenorMonto(
				new CriterioMontoAcumuladoEnPeriodo(50m, unMes),
				new CriterioCantidadAcumuladaEnPeriodo(3, todaLaVida)
			);

			var adapter = new CriterioActualizadorDeHistorialAdapter(criterioConjunto);

			var reintegro1 = adapter.Calcular(contexto, new Concepto(10m));
			var reintegro2 = adapter.Calcular(contexto, new Concepto(10m));
			var reintegro3 = adapter.Calcular(contexto, new Concepto(10m));
			var reintegro4 = adapter.Calcular(contexto, new Concepto(10m));

			Assert.That(reintegro1, Is.EqualTo(10m));
			Assert.That(reintegro2, Is.EqualTo(10m));
			Assert.That(reintegro3, Is.EqualTo(10m));
			Assert.That(reintegro4, Is.EqualTo(0m));
		}
	}
}