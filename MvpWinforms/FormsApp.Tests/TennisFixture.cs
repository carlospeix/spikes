using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormsApp.Tests
{
	[TestClass]
	public class TennisFixture
	{
		// Si juegan Federer y Nadal titulo debe ser "Federer vs Nadal"
		[TestMethod]
		public void TituloParaFedererNadal()
		{
			var tablero = new Tablero("Federer", "Nadal");
			Assert.AreEqual("Federer vs Nadal", tablero.Titulo);
		}
	
		// - Si juegan Del Potro y Djokovic titulo debe ser "Del Potro vs Djokovic"
		[TestMethod]
		public void TituloParaDelPortoDjokovic()
		{
			var tablero = new Tablero("Del Potro", "Djokovic");
			Assert.AreEqual("Del Potro vs Djokovic", tablero.Titulo);
		}

	}
}
