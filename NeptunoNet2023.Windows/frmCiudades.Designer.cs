﻿namespace NeptunoNet2023.Windows
{
	partial class frmCiudades
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			panel2 = new Panel();
			dgvDatos = new DataGridView();
			colCiudad = new DataGridViewTextBoxColumn();
			colPais = new DataGridViewTextBoxColumn();
			panel1 = new Panel();
			toolStrip1 = new ToolStrip();
			toolStripButton1 = new ToolStripButton();
			toolStripButton2 = new ToolStripButton();
			toolStripButton3 = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripButton4 = new ToolStripButton();
			toolStripButton5 = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			tsbCerrar = new ToolStripButton();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// panel2
			// 
			panel2.Controls.Add(dgvDatos);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(0, 62);
			panel2.Name = "panel2";
			panel2.Size = new Size(800, 329);
			panel2.TabIndex = 8;
			// 
			// dgvDatos
			// 
			dgvDatos.AllowUserToAddRows = false;
			dgvDatos.AllowUserToDeleteRows = false;
			dgvDatos.AllowUserToResizeColumns = false;
			dgvDatos.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
			dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colCiudad, colPais });
			dgvDatos.Dock = DockStyle.Fill;
			dgvDatos.Location = new Point(0, 0);
			dgvDatos.MultiSelect = false;
			dgvDatos.Name = "dgvDatos";
			dgvDatos.ReadOnly = true;
			dgvDatos.RowTemplate.Height = 25;
			dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvDatos.Size = new Size(800, 329);
			dgvDatos.TabIndex = 0;
			// 
			// colCiudad
			// 
			colCiudad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colCiudad.HeaderText = "Ciudad";
			colCiudad.Name = "colCiudad";
			colCiudad.ReadOnly = true;
			// 
			// colPais
			// 
			colPais.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colPais.HeaderText = "País";
			colPais.Name = "colPais";
			colPais.ReadOnly = true;
			// 
			// panel1
			// 
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 391);
			panel1.Name = "panel1";
			panel1.Size = new Size(800, 59);
			panel1.TabIndex = 7;
			// 
			// toolStrip1
			// 
			toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripSeparator1, toolStripButton4, toolStripButton5, toolStripSeparator2, tsbCerrar });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(800, 62);
			toolStrip1.TabIndex = 6;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			toolStripButton1.Image = Properties.Resources.Nuevo;
			toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(46, 59);
			toolStripButton1.Text = "Nuevo";
			toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripButton2
			// 
			toolStripButton2.Image = Properties.Resources.Delete;
			toolStripButton2.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton2.ImageTransparentColor = Color.Magenta;
			toolStripButton2.Name = "toolStripButton2";
			toolStripButton2.Size = new Size(44, 59);
			toolStripButton2.Text = "Borrar";
			toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripButton3
			// 
			toolStripButton3.Image = Properties.Resources.Edit;
			toolStripButton3.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton3.ImageTransparentColor = Color.Magenta;
			toolStripButton3.Name = "toolStripButton3";
			toolStripButton3.Size = new Size(44, 59);
			toolStripButton3.Text = "Editar";
			toolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 62);
			// 
			// toolStripButton4
			// 
			toolStripButton4.Image = Properties.Resources.Buscar;
			toolStripButton4.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton4.ImageTransparentColor = Color.Magenta;
			toolStripButton4.Name = "toolStripButton4";
			toolStripButton4.Size = new Size(46, 59);
			toolStripButton4.Text = "Buscar";
			toolStripButton4.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripButton5
			// 
			toolStripButton5.Image = Properties.Resources.Update;
			toolStripButton5.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton5.ImageTransparentColor = Color.Magenta;
			toolStripButton5.Name = "toolStripButton5";
			toolStripButton5.Size = new Size(63, 59);
			toolStripButton5.Text = "Actualizar";
			toolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 62);
			// 
			// tsbCerrar
			// 
			tsbCerrar.Image = Properties.Resources.Close;
			tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
			tsbCerrar.ImageTransparentColor = Color.Magenta;
			tsbCerrar.Name = "tsbCerrar";
			tsbCerrar.Size = new Size(44, 59);
			tsbCerrar.Text = "Cerrar";
			tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
			tsbCerrar.Click += tsbCerrar_Click;
			// 
			// frmCiudades
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(toolStrip1);
			Name = "frmCiudades";
			Text = "frmCiudades";
			Load += frmCiudades_Load;
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel2;
		private DataGridView dgvDatos;
		private Panel panel1;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton3;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton toolStripButton4;
		private ToolStripButton toolStripButton5;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton tsbCerrar;
		private DataGridViewTextBoxColumn colCiudad;
		private DataGridViewTextBoxColumn colPais;
	}
}