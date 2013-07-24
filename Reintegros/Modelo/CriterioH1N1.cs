using System;

namespace Reintegros.Modelo
{
	/// <summary>
	/// Hay dos maneras de resolver un criterio como este. Una de ellas es esta
	/// en la cual el criterio es especifico del concepto e incorpora todas las
	/// opciones en el metodo Calcular.
	/// 
	/// Otra forma es desdoblarlo en tres criterios, una por cada condicion y
	/// luego combinarlos con un CriterioMayorMonto pero, dado que la condicion
	/// es que sea afiliado ("esAfiliado") probablemente hubiesen sido 3 criterios
	/// especificos, por lo cual me parece mejor uno solo.
	/// </summary>
	public class CriterioH1N1 : Criterio
	{
		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var porcentajeReintegro = 0;
			if (contexto.Variable<bool>("esAfiliado"))
				porcentajeReintegro = 50;
			else if (contexto.Variable<int>("edad") <= 6)
				porcentajeReintegro = 30;
			else
				porcentajeReintegro = 20;
			return Decimal.Round(concepto.MontoReclamado * porcentajeReintegro / 100, 2);
		}
	}

}