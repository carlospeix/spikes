using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriterioMontoMaximoTest
	{
		Contexto contexto;
		Criterio criterio;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			criterio = new CriterioMontoMaximo(300m);
		}

		[Test()]
		public void PagaTodoLoSolicitado()
		{
			var reintegro = criterio.Calcular(contexto, new Concepto(300m));

			Assert.That(reintegro, Is.EqualTo(300m));
		}

		[Test()]
		public void ReintegraSolo300DeLos400()
		{
			var reintegro = criterio.Calcular(contexto, new Concepto(400m));

			Assert.That(reintegro, Is.EqualTo(300m));
		}
	}
}