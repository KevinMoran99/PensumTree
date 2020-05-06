namespace PensumTree
{
    partial class ModuloPensum
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.txtFin = new System.Windows.Forms.TextBox();
            this.panelCiclo1 = new System.Windows.Forms.Panel();
            this.btnCiclo1 = new System.Windows.Forms.Button();
            this.lblCiclo1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panelCiclos = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bntOptativas = new System.Windows.Forms.Button();
            this.panelCiclo1.SuspendLayout();
            this.panelCiclos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año de inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año de fin:";
            // 
            // txtInicio
            // 
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(140, 20);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(104, 26);
            this.txtInicio.TabIndex = 2;
            // 
            // txtFin
            // 
            this.txtFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFin.Location = new System.Drawing.Point(140, 52);
            this.txtFin.Name = "txtFin";
            this.txtFin.Size = new System.Drawing.Size(104, 26);
            this.txtFin.TabIndex = 3;
            // 
            // panelCiclo1
            // 
            this.panelCiclo1.AutoScroll = true;
            this.panelCiclo1.Controls.Add(this.btnCiclo1);
            this.panelCiclo1.Location = new System.Drawing.Point(15, 37);
            this.panelCiclo1.Name = "panelCiclo1";
            this.panelCiclo1.Size = new System.Drawing.Size(253, 567);
            this.panelCiclo1.TabIndex = 4;
            // 
            // btnCiclo1
            // 
            this.btnCiclo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCiclo1.Location = new System.Drawing.Point(85, 14);
            this.btnCiclo1.Name = "btnCiclo1";
            this.btnCiclo1.Size = new System.Drawing.Size(56, 47);
            this.btnCiclo1.TabIndex = 1;
            this.btnCiclo1.Text = "+";
            this.btnCiclo1.UseVisualStyleBackColor = true;
            this.btnCiclo1.Click += new System.EventHandler(this.handlerComun_Click);
            // 
            // lblCiclo1
            // 
            this.lblCiclo1.AutoSize = true;
            this.lblCiclo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCiclo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiclo1.Location = new System.Drawing.Point(95, 5);
            this.lblCiclo1.Margin = new System.Windows.Forms.Padding(5);
            this.lblCiclo1.Name = "lblCiclo1";
            this.lblCiclo1.Size = new System.Drawing.Size(61, 24);
            this.lblCiclo1.TabIndex = 0;
            this.lblCiclo1.Text = "Ciclo I";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Carrera:";
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(386, 16);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(299, 28);
            this.cmbCarrera.TabIndex = 6;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInactivo.Location = new System.Drawing.Point(415, 55);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(82, 24);
            this.rdbInactivo.TabIndex = 156;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Checked = true;
            this.rdbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbActivo.Location = new System.Drawing.Point(339, 54);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(70, 24);
            this.rdbActivo.TabIndex = 155;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 154;
            this.label6.Text = "Estado:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(977, 20);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 33);
            this.btnGuardar.TabIndex = 157;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(977, 62);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(147, 33);
            this.btnRegresar.TabIndex = 158;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panelCiclos
            // 
            this.panelCiclos.AutoScroll = true;
            this.panelCiclos.Controls.Add(this.lblCiclo1);
            this.panelCiclos.Controls.Add(this.panelCiclo1);
            this.panelCiclos.Location = new System.Drawing.Point(12, 101);
            this.panelCiclos.Name = "panelCiclos";
            this.panelCiclos.Size = new System.Drawing.Size(1112, 624);
            this.panelCiclos.TabIndex = 159;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // bntOptativas
            // 
            this.bntOptativas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bntOptativas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOptativas.Location = new System.Drawing.Point(750, 25);
            this.bntOptativas.Name = "bntOptativas";
            this.bntOptativas.Size = new System.Drawing.Size(168, 54);
            this.bntOptativas.TabIndex = 160;
            this.bntOptativas.Text = "Materias optativas";
            this.bntOptativas.UseVisualStyleBackColor = false;
            this.bntOptativas.Click += new System.EventHandler(this.bntOptativas_Click);
            // 
            // ModuloPensum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 737);
            this.Controls.Add(this.bntOptativas);
            this.Controls.Add(this.panelCiclos);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rdbInactivo);
            this.Controls.Add(this.rdbActivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCarrera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFin);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(50, -50);
            this.Name = "ModuloPensum";
            this.Text = "Creación de pensum";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModuloPensum_FormClosed);
            this.Load += new System.EventHandler(this.ModuloPensum_Load);
            this.panelCiclo1.ResumeLayout(false);
            this.panelCiclos.ResumeLayout(false);
            this.panelCiclos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.TextBox txtFin;
        private System.Windows.Forms.Panel panelCiclo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblCiclo1;
        private System.Windows.Forms.Button btnCiclo1;
        private System.Windows.Forms.Panel panelCiclos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button bntOptativas;
    }
}