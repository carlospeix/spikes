namespace FormsApp
{
	public interface IView
	{
		void InicializarCampoIngresos(int x, int y, string etiqueta, bool visible);
		void InicializarCampoEgresos(int x, int y, string etuiqueta, bool visible);
		void InicializarCampoImpuestos(int x, int y, string etuiqueta, bool visible);
	}
}