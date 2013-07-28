using System;
using NUnit.Framework;
using Reintegros.Modelo;

namespace Tests
{
	[TestFixture()]
	public class CriterioPanialesTest
	{
		Contexto contexto;
		Criterio criterio;

		[SetUp]
		public void SetUp()
		{
			contexto = new Contexto();
			criterio = new CriterioPaniales(2, 3.4m);
		}

		[Test()]
		public void ReintegraHasta2PorDia3Con40PorPanial()
		{
			var fechaNacimiento = new DateTime(2013, 1, 1);
			var fechaReintegro = new DateTime(2013, 2, 1);

            contexto["fechaNacimiento"] = fechaNacimiento;
			contexto.DefinirBuscadorDeHistorial((periodo) => new Historial(0, 0m));

			var reintegro = criterio.Calcular(contexto, new Concepto(200m, fechaReintegro));

			var dias = fechaReintegro.Subtract(fechaNacimiento).Days;

			Assert.That(reintegro, Is.EqualTo(dias * 2 * 3.4m));
		}
	}
}