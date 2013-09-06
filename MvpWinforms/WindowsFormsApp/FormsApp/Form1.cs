using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsApp
{
	public partial class Form1 : Form, IView
	{
		private Presenter _presenter;

		public Form1()
		{
			InitializeComponent();
			_presenter = new Presenter(this);
		}

		private void textIngresos_TextChanged(object sender, EventArgs e)
		{
			labelTotal.Text = _presenter.CalcularTotal(
				Convert.ToInt32(textIngresos.Text), Convert.ToInt32(textEgresos.Text), Convert.ToInt32(textImpuestos.Text)).ToString();
		}

		private void textEgresos_TextChanged(object sender, EventArgs e)
		{
			labelTotal.Text = _presenter.CalcularTotal(
				Convert.ToInt32(textIngresos.Text), Convert.ToInt32(textEgresos.Text), Convert.ToInt32(textImpuestos.Text)).ToString();
		}

		private void textImpuestos_TextChanged(object sender, EventArgs e)
		{
			labelTotal.Text = _presenter.CalcularTotal(
				Convert.ToInt32(textIngresos.Text), Convert.ToInt32(textEgresos.Text), Convert.ToInt32(textImpuestos.Text)).ToString();
		}

		public void InicializarCampoIngresos(int x, int y, string etiqueta, bool visible)
		{
			textIngresos.Visible = visible;
		}

		public void InicializarCampoEgresos(int x, int y, string etuiqueta, bool visible)
		{
			textEgresos.Visible = visible;
		}

		public void InicializarCampoImpuestos(int x, int y, string etuiqueta, bool visible)
		{
			textIngresos.Visible = visible;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (_presenter.Grabar(Convert.ToInt32(textIngresos.Text), Convert.ToInt32(textEgresos.Text), Convert.ToInt32(textImpuestos.Text)))
				MessageBox.Show(this, "Grabado OK");
		}
	}
}
