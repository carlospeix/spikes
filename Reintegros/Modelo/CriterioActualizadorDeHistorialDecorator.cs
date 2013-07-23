using System;

namespace Reintegros.Modelo
{
	public class CriterioActualizadorDeHistorialDecorator : Criterio
	{
		Criterio criterioAdaptado;

		public CriterioActualizadorDeHistorialDecorator(Criterio criterioAdaptado)
		{
			this.criterioAdaptado = criterioAdaptado;
		}

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var reintegro = criterioAdaptado.Calcular(contexto, concepto);
			if (reintegro > 0)
				contexto.RegistrarReintegroTemporal(reintegro);
			return reintegro;
		}
	}
}