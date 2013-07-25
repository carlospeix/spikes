using System;

namespace Reintegros.Modelo
{
	public class CriterioActualizadorDeHistorialAdapter : Criterio
	{
		Criterio criterioAdaptado;

		public CriterioActualizadorDeHistorialAdapter(Criterio criterioAdaptado)
		{
			this.criterioAdaptado = criterioAdaptado;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var reintegro = criterioAdaptado.Calcular(contexto, concepto);
			if (reintegro > 0)
				contexto.RegistrarReintegroTemporal(new Historial(1, reintegro));
			return reintegro;
		}
	}
}