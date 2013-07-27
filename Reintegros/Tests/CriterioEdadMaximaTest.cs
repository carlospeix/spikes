using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriterioEdadMaximaTest
	{
		Contexto contexto;
		Criterio criterio;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			criterio = new CriterioEdadMaxima(25);
		}

		[Test()]
		public void Reintegra100PorCientoParaBeneficierioDe24Anios()
		{
			contexto["edad"] = 24;
			var reintegro = criterio.Calcular(contexto, new Concepto(300m));

			Assert.That(reintegro, Is.EqualTo(300m));
		}

		[Test()]
		public void NoReintegraParaBeneficierioDe35Anios()
		{
			contexto["edad"] = 35;
			var reintegro = criterio.Calcular(contexto, new Concepto(300m));

			Assert.That(reintegro, Is.EqualTo(0m));
		}
	}
}