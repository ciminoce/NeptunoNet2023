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
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnCategorias);
            Controls.Add(btnPaises);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPaises;
        private Button btnSalir;
        private Button btnCategorias;
    }
}