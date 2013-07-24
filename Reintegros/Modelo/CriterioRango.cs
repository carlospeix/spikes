using System;

namespace Reintegros.Modelo
{
    public class CriterioRango : Criterio
    {
        int cantidadMaxima;
        TimeSpan rango;

        public CriterioRango(TimeSpan rango)
        {
            this.rango = rango;
        }

        public decimal Calcular(Contexto contexto, Concepto concepto)
        {
            var historial = contexto.ObtenerHistorial(this.rango);
            var rangoDisponible = rango - historial.Rango;
            var montoReintegro = 0m;

            if (rangoDisponible.TotalDays > 0)
                montoReintegro = concepto.MontoReclamado;
            
            return montoReintegro;
        }
    }
}