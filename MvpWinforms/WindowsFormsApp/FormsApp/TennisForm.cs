using System.Windows.Forms;

namespace FormsApp
{
	public partial class TennisForm : Form, ITennisView
	{
		private TennisPresenter _presenter;

		public TennisForm(string jugador1, string jugador2)
		{
			InitializeComponent();
			_presenter = new TennisPresenter(this);
			_presenter.Inicializar(jugador1, jugador2);
		}

		public void SetTitulo(string titulo)
		{
			this.Text = titulo;
		}

		private void TennisForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_presenter = null;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		}
	}
}
