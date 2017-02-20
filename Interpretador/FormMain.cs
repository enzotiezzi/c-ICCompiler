using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpretador
{
	public partial class FormMain : Form
	{
		private Compiler.Syntax.Expression ex;

		public FormMain()
		{
			InitializeComponent();
		}

		private void txtIn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
				e.IsInputKey = true;
		}

		private void btnCompile_Click(object sender, EventArgs e)
		{
			txtOut.Text = "";
			Compiler.TokenParser p = new Compiler.TokenParser(txtIn.Text);
			ex = Compiler.Syntax.Program.Parse(p);
			if (ex == null)
			{
				if (Compiler.Syntax.Program.ErrorToken != null)
				{
					txtOut.Text = "Ln " + Compiler.Syntax.Program.ErrorToken.Line +
						" Col " + Compiler.Syntax.Program.ErrorToken.Column + ": ";
				}
				else
				{
					txtOut.Text = "Ln " + p.Line +
						" Col " + p.Column + ": ";
				}
				if (Compiler.Syntax.Program.ErrorDescription != null)
					txtOut.Text += Compiler.Syntax.Program.ErrorDescription;
				else
					txtOut.Text += p.ErrorDescription;
			}
			else
			{
				txtOut.Text = "Compilado com sucesso!";
			}
		}

		private void btnExec_Click(object sender, EventArgs e)
		{
			if (ex != null)
			{
				txtOut.Text = "Resultado: " + ex.Evaluate();
			}
			else
			{
				txtOut.Text = "Nada para executar!";
			}
		}
	}
}
