using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entorno;

namespace TestEntorno
{
	[TestClass]
	public class EntornoTest
	{
		private Calculadora casio;

		[TestInitialize]
		public void Arrange()
		{
			casio = new Calculadora();
		}

		[TestMethod]
		public void PruebaSuma1Mas2()
		{
			var resultado = casio.Suma(1, 2);
			Assert.AreEqual(3, resultado);
		}

		[TestMethod]
		public void PruebaSuma2Mas3()
		{
			var resultado = casio.Suma(2, 3);
			Assert.AreEqual(5, resultado);
		}
	}
}
