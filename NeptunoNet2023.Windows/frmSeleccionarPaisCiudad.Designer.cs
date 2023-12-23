namespace NeptunoNet2023.Windows
{
    partial class frmSeleccionarPaisCiudad
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
            components = new System.ComponentModel.Container();
            cboPaises = new ComboBox();
            btnCancelar = new Button();
            btnOK = new Button();
            label2 = new Label();
            label1 = new Label();
            cboCiudades = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(113, 36);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(340, 23);
            cboPaises.TabIndex = 11;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(443, 116);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 66);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.Aceptar;
            btnOK.Location = new Point(40, 116);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 66);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 39);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "País:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 68);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 7;
            label1.Text = "Ciudad:";
            // 
            // cboCiudades
            // 
            cboCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCiudades.FormattingEnabled = true;
            cboCiudades.Location = new Point(113, 68);
            cboCiudades.Name = "cboCiudades";
            cboCiudades.Size = new Size(340, 23);
            cboCiudades.TabIndex = 11;
            cboCiudades.SelectedIndexChanged += cboCiudades_SelectedIndexChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSeleccionarPaisCiudad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 206);
            Controls.Add(cboCiudades);
            Controls.Add(cboPaises);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmSeleccionarPaisCiudad";
            Text = "frmSeleccionarPaisCiudad";
            Load += frmSeleccionarPaisCiudad_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPaises;
        private Button btnCancelar;
        private Button btnOK;
        private Label label2;
        private Label label1;
        private ComboBox cboCiudades;
        private ErrorProvider errorProvider1;
    }
}