using System;

namespace Reintegros.Modelo
{
	public class CriterioActualizadorDeHistorialAdapter : Criterio
	{
		Criterio criterioAdaptado;
        TimeSpan periodo;

		public CriterioActualizadorDeHistorialAdapter(Criterio criterioAdaptado)
		{
			this.criterioAdaptado = criterioAdaptado;
		}

        public CriterioActualizadorDeHistorialAdapter(Criterio criterioAdaptado, TimeSpan rango)
        {
            this.periodo = rango;
            this.criterioAdaptado = criterioAdaptado;
        }

		public decimal Calcular(Contexto contexto, Concepto concepto)
		{
			var reintegro = criterioAdaptado.Calcular(contexto, concepto);
			if (reintegro > 0)
				contexto.RegistrarReintegroTemporal(reintegro, periodo);
			return reintegro;
		}
	}
}