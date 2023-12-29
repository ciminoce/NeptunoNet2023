namespace NeptunoNet2023.Windows
{
    partial class frmProveedorAE
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
            btnCancelar = new Button();
            btnOK = new Button();
            groupBox2 = new GroupBox();
            txtTelefono = new TextBox();
            groupBox1 = new GroupBox();
            cboCiudades = new ComboBox();
            cboPaises = new ComboBox();
            txtCodPostal = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtProveedor = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(561, 359);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 66);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.Aceptar;
            btnOK.Location = new Point(157, 359);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 66);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Location = new Point(41, 282);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(419, 71);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = " Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(7, 22);
            txtTelefono.MaxLength = 200;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(379, 23);
            txtTelefono.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboCiudades);
            groupBox1.Controls.Add(cboPaises);
            groupBox1.Controls.Add(txtCodPostal);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(41, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(718, 208);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Domicilio";
            // 
            // cboCiudades
            // 
            cboCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCiudades.FormattingEnabled = true;
            cboCiudades.Location = new Point(99, 169);
            cboCiudades.Name = "cboCiudades";
            cboCiudades.Size = new Size(320, 23);
            cboCiudades.TabIndex = 4;
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(99, 125);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(320, 23);
            cboPaises.TabIndex = 4;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            cboPaises.SelectionChangeCommitted += cboPaises_SelectionChangeCommitted;
            cboPaises.Click += cboPaises_SelectedIndexChanged;
            // 
            // txtCodPostal
            // 
            txtCodPostal.Location = new Point(99, 79);
            txtCodPostal.MaxLength = 200;
            txtCodPostal.Name = "txtCodPostal";
            txtCodPostal.Size = new Size(194, 23);
            txtCodPostal.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 172);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 2;
            label5.Text = "Ciudad:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(99, 39);
            txtDireccion.MaxLength = 200;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(560, 23);
            txtDireccion.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 128);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 2;
            label4.Text = "País:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 82);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "C.P.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 39);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Dirección:";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(111, 26);
            txtProveedor.MaxLength = 255;
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(589, 23);
            txtProveedor.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 29);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "Proveedor:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmProveedorAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtProveedor);
            Controls.Add(label1);
            Name = "frmProveedorAE";
            Text = "frmProveedorAE";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOK;
        private GroupBox groupBox2;
        private TextBox txtTelefono;
        private GroupBox groupBox1;
        private ComboBox cboCiudades;
        private ComboBox cboPaises;
        private TextBox txtCodPostal;
        private Label label5;
        private TextBox txtDireccion;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtProveedor;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}