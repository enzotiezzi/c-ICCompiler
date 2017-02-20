namespace Interpretador
{
	partial class FormMain
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtIn = new System.Windows.Forms.TextBox();
			this.txtOut = new System.Windows.Forms.TextBox();
			this.btnCompile = new System.Windows.Forms.Button();
			this.btnExec = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnExec);
			this.panel1.Controls.Add(this.btnCompile);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(491, 45);
			this.panel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 45);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtIn);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtOut);
			this.splitContainer1.Size = new System.Drawing.Size(491, 354);
			this.splitContainer1.SplitterDistance = 240;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			// 
			// txtIn
			// 
			this.txtIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtIn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIn.Location = new System.Drawing.Point(0, 0);
			this.txtIn.Multiline = true;
			this.txtIn.Name = "txtIn";
			this.txtIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtIn.Size = new System.Drawing.Size(491, 240);
			this.txtIn.TabIndex = 0;
			this.txtIn.WordWrap = false;
			this.txtIn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtIn_PreviewKeyDown);
			// 
			// txtOut
			// 
			this.txtOut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOut.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOut.Location = new System.Drawing.Point(0, 0);
			this.txtOut.Multiline = true;
			this.txtOut.Name = "txtOut";
			this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOut.Size = new System.Drawing.Size(491, 110);
			this.txtOut.TabIndex = 1;
			this.txtOut.WordWrap = false;
			// 
			// btnCompile
			// 
			this.btnCompile.Location = new System.Drawing.Point(12, 11);
			this.btnCompile.Name = "btnCompile";
			this.btnCompile.Size = new System.Drawing.Size(75, 23);
			this.btnCompile.TabIndex = 0;
			this.btnCompile.Text = "Compilar!";
			this.btnCompile.UseVisualStyleBackColor = true;
			this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
			// 
			// btnExec
			// 
			this.btnExec.Location = new System.Drawing.Point(93, 11);
			this.btnExec.Name = "btnExec";
			this.btnExec.Size = new System.Drawing.Size(75, 23);
			this.btnExec.TabIndex = 1;
			this.btnExec.Text = "Executar!";
			this.btnExec.UseVisualStyleBackColor = true;
			this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 399);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Name = "FormMain";
			this.Text = "Interpretador";
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox txtIn;
		private System.Windows.Forms.TextBox txtOut;
		private System.Windows.Forms.Button btnExec;
		private System.Windows.Forms.Button btnCompile;

	}
}

