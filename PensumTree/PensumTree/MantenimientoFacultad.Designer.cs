namespace PensumTree
{
    partial class MantenimientoFacultad
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvFacultades = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacultades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(630, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 148;
            this.label3.Text = "Filtro";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(678, 77);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(172, 36);
            this.btnLimpiar.TabIndex = 147;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(678, 26);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(172, 36);
            this.btnAgregar.TabIndex = 146;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvFacultades
            // 
            this.dgvFacultades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacultades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacultades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFacultades.Location = new System.Drawing.Point(12, 186);
            this.dgvFacultades.Name = "dgvFacultades";
            this.dgvFacultades.Size = new System.Drawing.Size(860, 329);
            this.dgvFacultades.TabIndex = 145;
            this.dgvFacultades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacultades_CellClick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(373, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(97, 29);
            this.lblTitulo.TabIndex = 144;
            this.lblTitulo.Text = "Facultad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 142;
            this.label6.Text = "Estado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 23);
            this.label10.TabIndex = 141;
            this.label10.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(174, 59);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(396, 29);
            this.txtNombre.TabIndex = 151;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Checked = true;
            this.rdbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbActivo.Location = new System.Drawing.Point(174, 110);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(79, 28);
            this.rdbActivo.TabIndex = 152;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInactivo.Location = new System.Drawing.Point(265, 110);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(91, 28);
            this.rdbInactivo.TabIndex = 153;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(686, 145);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(164, 20);
            this.txtBuscar.TabIndex = 154;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // MantenimientoFacultad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 528);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.rdbInactivo);
            this.Controls.Add(this.rdbActivo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvFacultades);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Name = "MantenimientoFacultad";
            this.Text = "MantenimientoFacultad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MantenimientoFacultad_FormClosed);
            this.Load += new System.EventHandler(this.MantenimientoFacultad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacultades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvFacultades;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}