namespace AdminEmpleadosFront
{
    partial class FrmEditEmpleados
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
            btnAceptar = new Button();
            btnCerrar = new Button();
            label1 = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDni = new TextBox();
            txtDireccion = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtIngreso = new DateTimePicker();
            label6 = new Label();
            txtSalario = new NumericUpDown();
            label7 = new Label();
            cmbDepartamento = new ComboBox();
            departamentoBindingSource = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)txtSalario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departamentoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(209, 312);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 31);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(302, 312);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(86, 31);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 2;
            label1.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(126, 21);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(61, 27);
            txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(126, 99);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(236, 27);
            txtNombre.TabIndex = 2;
            txtNombre.Validating += txt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 103);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 64);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 6;
            label3.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(126, 60);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(236, 27);
            txtDni.TabIndex = 1;
            txtDni.Validating += txt_Validating;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(126, 137);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(236, 27);
            txtDireccion.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 141);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 8;
            label4.Text = "Dirección";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 187);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 10;
            label5.Text = "Ingreso";
            // 
            // txtIngreso
            // 
            txtIngreso.Checked = false;
            txtIngreso.CustomFormat = "dd/MM/yyyy";
            txtIngreso.Format = DateTimePickerFormat.Custom;
            txtIngreso.Location = new Point(126, 179);
            txtIngreso.Margin = new Padding(3, 4, 3, 4);
            txtIngreso.Name = "txtIngreso";
            txtIngreso.Size = new Size(116, 27);
            txtIngreso.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 221);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 12;
            label6.Text = "Salario";
            // 
            // txtSalario
            // 
            txtSalario.DecimalPlaces = 2;
            txtSalario.Location = new Point(126, 219);
            txtSalario.Margin = new Padding(3, 4, 3, 4);
            txtSalario.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(117, 27);
            txtSalario.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 261);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 14;
            label7.Text = "Departamento";
            // 
            // cmbDepartamento
            // 
            cmbDepartamento.DataSource = departamentoBindingSource;
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartamento.FormattingEnabled = true;
            cmbDepartamento.Location = new Point(126, 257);
            cmbDepartamento.Margin = new Padding(3, 4, 3, 4);
            cmbDepartamento.Name = "cmbDepartamento";
            cmbDepartamento.Size = new Size(236, 28);
            cmbDepartamento.TabIndex = 6;
            cmbDepartamento.ValueMember = "id";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider1.ContainerControl = this;
            // 
            // FrmEditEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 359);
            Controls.Add(cmbDepartamento);
            Controls.Add(label7);
            Controls.Add(txtSalario);
            Controls.Add(label6);
            Controls.Add(txtIngreso);
            Controls.Add(label5);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(txtDni);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmEditEmpleados";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar empleados";
            Load += FrmEditEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)txtSalario).EndInit();
            ((System.ComponentModel.ISupportInitialize)departamentoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCerrar;
        private Label label1;
        private TextBox txtId;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private TextBox txtDni;
        private TextBox txtDireccion;
        private Label label4;
        private Label label5;
        private DateTimePicker txtIngreso;
        private Label label6;
        private NumericUpDown txtSalario;
        private Label label7;
        private ComboBox cmbDepartamento;
        private BindingSource departamentoBindingSource;
        private ErrorProvider errorProvider1;
    }
}