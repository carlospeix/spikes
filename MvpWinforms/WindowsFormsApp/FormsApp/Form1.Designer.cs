namespace FormsApp
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.textIngresos = new System.Windows.Forms.TextBox();
			this.textEgresos = new System.Windows.Forms.TextBox();
			this.textImpuestos = new System.Windows.Forms.TextBox();
			this.labelTotal = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(197, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Grabar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textIngresos
			// 
			this.textIngresos.Location = new System.Drawing.Point(27, 23);
			this.textIngresos.Name = "textIngresos";
			this.textIngresos.Size = new System.Drawing.Size(100, 20);
			this.textIngresos.TabIndex = 1;
			this.textIngresos.Text = "0";
			this.textIngresos.TextChanged += new System.EventHandler(this.textIngresos_TextChanged);
			// 
			// textEgresos
			// 
			this.textEgresos.Location = new System.Drawing.Point(172, 23);
			this.textEgresos.Name = "textEgresos";
			this.textEgresos.Size = new System.Drawing.Size(100, 20);
			this.textEgresos.TabIndex = 2;
			this.textEgresos.Text = "0";
			this.textEgresos.TextChanged += new System.EventHandler(this.textEgresos_TextChanged);
			// 
			// textImpuestos
			// 
			this.textImpuestos.Location = new System.Drawing.Point(27, 72);
			this.textImpuestos.Name = "textImpuestos";
			this.textImpuestos.Size = new System.Drawing.Size(100, 20);
			this.textImpuestos.TabIndex = 3;
			this.textImpuestos.Text = "0";
			this.textImpuestos.TextChanged += new System.EventHandler(this.textImpuestos_TextChanged);
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.Location = new System.Drawing.Point(172, 78);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(13, 13);
			this.labelTotal.TabIndex = 4;
			this.labelTotal.Text = "0";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 150);
			this.Controls.Add(this.labelTotal);
			this.Controls.Add(this.textImpuestos);
			this.Controls.Add(this.textEgresos);
			this.Controls.Add(this.textIngresos);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textIngresos;
		private System.Windows.Forms.TextBox textEgresos;
		private System.Windows.Forms.TextBox textImpuestos;
		private System.Windows.Forms.Label labelTotal;
	}
}