namespace PensumTree
{
    partial class MantenimientoMaterias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoMaterias));
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUV = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbxEscuela = new System.Windows.Forms.ComboBox();
            this.cbxPreReq1 = new System.Windows.Forms.ComboBox();
            this.cbxPreReq2 = new System.Windows.Forms.ComboBox();
            this.cbxPreReq4 = new System.Windows.Forms.ComboBox();
            this.cbxPreReq3 = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chPar = new System.Windows.Forms.CheckBox();
            this.chImpar = new System.Windows.Forms.CheckBox();
            this.chLab = new System.Windows.Forms.CheckBox();
            this.chElectiva = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Ciclo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Codigo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(55, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 23);
            this.label10.TabIndex = 34;
            this.label10.Text = "Nombre:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "UV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Prerequisito:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "Escuela:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "Estado:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(211, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 20);
            this.txtNombre.TabIndex = 42;
            // 
            // txtUV
            // 
            this.txtUV.Location = new System.Drawing.Point(211, 92);
            this.txtUV.Name = "txtUV";
            this.txtUV.Size = new System.Drawing.Size(105, 20);
            this.txtUV.TabIndex = 43;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(211, 124);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(105, 20);
            this.txtCodigo.TabIndex = 45;
            // 
            // cbxEscuela
            // 
            this.cbxEscuela.FormattingEnabled = true;
            this.cbxEscuela.Location = new System.Drawing.Point(211, 187);
            this.cbxEscuela.Name = "cbxEscuela";
            this.cbxEscuela.Size = new System.Drawing.Size(158, 21);
            this.cbxEscuela.TabIndex = 49;
            // 
            // cbxPreReq1
            // 
            this.cbxPreReq1.FormattingEnabled = true;
            this.cbxPreReq1.Location = new System.Drawing.Point(597, 63);
            this.cbxPreReq1.Name = "cbxPreReq1";
            this.cbxPreReq1.Size = new System.Drawing.Size(121, 21);
            this.cbxPreReq1.TabIndex = 52;
            // 
            // cbxPreReq2
            // 
            this.cbxPreReq2.FormattingEnabled = true;
            this.cbxPreReq2.Location = new System.Drawing.Point(746, 63);
            this.cbxPreReq2.Name = "cbxPreReq2";
            this.cbxPreReq2.Size = new System.Drawing.Size(121, 21);
            this.cbxPreReq2.TabIndex = 53;
            // 
            // cbxPreReq4
            // 
            this.cbxPreReq4.FormattingEnabled = true;
            this.cbxPreReq4.Location = new System.Drawing.Point(746, 104);
            this.cbxPreReq4.Name = "cbxPreReq4";
            this.cbxPreReq4.Size = new System.Drawing.Size(121, 21);
            this.cbxPreReq4.TabIndex = 54;
            // 
            // cbxPreReq3
            // 
            this.cbxPreReq3.FormattingEnabled = true;
            this.cbxPreReq3.Location = new System.Drawing.Point(597, 104);
            this.cbxPreReq3.Name = "cbxPreReq3";
            this.cbxPreReq3.Size = new System.Drawing.Size(121, 21);
            this.cbxPreReq3.TabIndex = 55;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(419, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(101, 29);
            this.lblTitulo.TabIndex = 56;
            this.lblTitulo.Text = "Materias";
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Location = new System.Drawing.Point(12, 315);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(903, 361);
            this.dgvMaterias.TabIndex = 57;
            this.dgvMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(685, 153);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(172, 36);
            this.btnAgregar.TabIndex = 58;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(685, 204);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(172, 36);
            this.btnLimpiar.TabIndex = 59;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 60;
            this.label3.Text = "Filtro";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(685, 258);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(172, 36);
            this.btnEliminar.TabIndex = 62;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Checked = true;
            this.rdbActivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbActivo.Location = new System.Drawing.Point(211, 217);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(77, 27);
            this.rdbActivo.TabIndex = 63;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInactivo.Location = new System.Drawing.Point(294, 217);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(91, 27);
            this.rdbInactivo.TabIndex = 64;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chPar
            // 
            this.chPar.AutoSize = true;
            this.chPar.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.chPar.Location = new System.Drawing.Point(211, 148);
            this.chPar.Name = "chPar";
            this.chPar.Size = new System.Drawing.Size(55, 27);
            this.chPar.TabIndex = 67;
            this.chPar.Text = "Par";
            this.chPar.UseVisualStyleBackColor = true;
            // 
            // chImpar
            // 
            this.chImpar.AutoSize = true;
            this.chImpar.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.chImpar.Location = new System.Drawing.Point(294, 148);
            this.chImpar.Name = "chImpar";
            this.chImpar.Size = new System.Drawing.Size(76, 27);
            this.chImpar.TabIndex = 68;
            this.chImpar.Text = "Impar";
            this.chImpar.UseVisualStyleBackColor = true;
            // 
            // chLab
            // 
            this.chLab.AutoSize = true;
            this.chLab.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.chLab.Location = new System.Drawing.Point(475, 149);
            this.chLab.Name = "chLab";
            this.chLab.Size = new System.Drawing.Size(119, 27);
            this.chLab.TabIndex = 69;
            this.chLab.Text = "Laboratorio";
            this.chLab.UseVisualStyleBackColor = true;
            // 
            // chElectiva
            // 
            this.chElectiva.AutoSize = true;
            this.chElectiva.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.chElectiva.Location = new System.Drawing.Point(475, 204);
            this.chElectiva.Name = "chElectiva";
            this.chElectiva.Size = new System.Drawing.Size(88, 27);
            this.chElectiva.TabIndex = 70;
            this.chElectiva.Text = "Electiva";
            this.chElectiva.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(458, 268);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(221, 20);
            this.txtBuscar.TabIndex = 71;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // MantenimientoMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 704);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.chElectiva);
            this.Controls.Add(this.chLab);
            this.Controls.Add(this.chImpar);
            this.Controls.Add(this.chPar);
            this.Controls.Add(this.rdbInactivo);
            this.Controls.Add(this.rdbActivo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMaterias);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cbxPreReq3);
            this.Controls.Add(this.cbxPreReq4);
            this.Controls.Add(this.cbxPreReq2);
            this.Controls.Add(this.cbxPreReq1);
            this.Controls.Add(this.cbxEscuela);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtUV);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MantenimientoMaterias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MantenimientoMaterias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MantenimientoMaterias_FormClosed);
            this.Load += new System.EventHandler(this.MantenimientoMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUV;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cbxEscuela;
        private System.Windows.Forms.ComboBox cbxPreReq1;
        private System.Windows.Forms.ComboBox cbxPreReq2;
        private System.Windows.Forms.ComboBox cbxPreReq4;
        private System.Windows.Forms.ComboBox cbxPreReq3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chElectiva;
        private System.Windows.Forms.CheckBox chLab;
        private System.Windows.Forms.CheckBox chImpar;
        private System.Windows.Forms.CheckBox chPar;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}