using System;

namespace Reintegros.Modelo
{
	public interface Criterio
	{
		decimal Calcular(Contexto contexto, Concepto concepto);
	}
}

