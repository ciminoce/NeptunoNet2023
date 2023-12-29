namespace NeptunoNet2023.Windows
{
	partial class frmPrincipal
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
            btnPaises = new Button();
            btnSalir = new Button();
            btnCategorias = new Button();
            btnCiudades = new Button();
            btnClientes = new Button();
            btnProveedores = new Button();
            SuspendLayout();
            // 
            // btnPaises
            // 
            btnPaises.Image = Properties.Resources.america_50px;
            btnPaises.Location = new Point(40, 61);
            btnPaises.Name = "btnPaises";
            btnPaises.Size = new Size(134, 70);
            btnPaises.TabIndex = 0;
            btnPaises.Text = "Países";
            btnPaises.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPaises.UseVisualStyleBackColor = true;
            btnPaises.Click += btnPaises_Click;
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.shutdown_48px;
            btnSalir.Location = new Point(658, 357);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 70);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCategorias
            // 
            btnCategorias.Image = Properties.Resources.categorize_50px;
            btnCategorias.Location = new Point(40, 169);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(134, 70);
            btnCategorias.TabIndex = 0;
            btnCategorias.Text = "Categorías";
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnCiudades
            // 
            btnCiudades.Image = Properties.Resources.city_50px;
            btnCiudades.Location = new Point(199, 61);
            btnCiudades.Name = "btnCiudades";
            btnCiudades.Size = new Size(134, 70);
            btnCiudades.TabIndex = 0;
            btnCiudades.Text = "Ciudades";
            btnCiudades.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCiudades.UseVisualStyleBackColor = true;
            btnCiudades.Click += btnCiudades_Click;
            // 
            // btnClientes
            // 
            btnClientes.Image = Properties.Resources.client_management_50px;
            btnClientes.Location = new Point(363, 61);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(134, 70);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Image = Properties.Resources.customer_50px;
            btnProveedores.Location = new Point(199, 169);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(134, 70);
            btnProveedores.TabIndex = 0;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnCategorias);
            Controls.Add(btnProveedores);
            Controls.Add(btnClientes);
            Controls.Add(btnCiudades);
            Controls.Add(btnPaises);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPaises;
		private Button btnSalir;
		private Button btnCategorias;
		private Button btnCiudades;
        private Button btnClientes;
        private Button btnProveedores;
    }
}