namespace PensumTree
{
    partial class VistaPensum
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
            this.panelCiclo1 = new System.Windows.Forms.Panel();
            this.lblCiclo1 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panelCiclos = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelGrafo = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblImLazy = new System.Windows.Forms.Label();
            this.Archivotxt = new System.Windows.Forms.OpenFileDialog();
            this.panelCiclos.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCiclo1
            // 
            this.panelCiclo1.AutoScroll = true;
            this.panelCiclo1.Location = new System.Drawing.Point(15, 37);
            this.panelCiclo1.Name = "panelCiclo1";
            this.panelCiclo1.Size = new System.Drawing.Size(253, 520);
            this.panelCiclo1.TabIndex = 4;
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
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(994, 53);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(130, 30);
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
            this.panelCiclos.Location = new System.Drawing.Point(6, 3);
            this.panelCiclos.Name = "panelCiclos";
            this.panelCiclos.Size = new System.Drawing.Size(1076, 564);
            this.panelCiclos.TabIndex = 159;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1116, 39);
            this.lblTitle.TabIndex = 160;
            this.lblTitle.Text = "Título";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1112, 599);
            this.tabControl1.TabIndex = 161;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panelCiclos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1104, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vista de malla";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelGrafo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1104, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vista de grafo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelGrafo
            // 
            this.panelGrafo.AutoScroll = true;
            this.panelGrafo.Location = new System.Drawing.Point(6, 6);
            this.panelGrafo.Name = "panelGrafo";
            this.panelGrafo.Size = new System.Drawing.Size(1092, 560);
            this.panelGrafo.TabIndex = 0;
            this.panelGrafo.Click += new System.EventHandler(this.panelGrafo_Click);
            this.panelGrafo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafo_Paint);
            this.panelGrafo.MouseEnter += new System.EventHandler(this.panelGrafo_MouseEnter);
            this.panelGrafo.MouseHover += new System.EventHandler(this.panelGrafo_MouseHover);
            this.panelGrafo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGrafo_MouseMove);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(12, 53);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(204, 30);
            this.btnExport.TabIndex = 162;
            this.btnExport.Text = "Exportar progreso a txt";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(222, 53);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(185, 30);
            this.btnCargar.TabIndex = 163;
            this.btnCargar.Text = "Cargar progreso de txt";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblImLazy
            // 
            this.lblImLazy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImLazy.Location = new System.Drawing.Point(516, 54);
            this.lblImLazy.Name = "lblImLazy";
            this.lblImLazy.Size = new System.Drawing.Size(58, 32);
            this.lblImLazy.TabIndex = 164;
            this.lblImLazy.Text = "Título";
            this.lblImLazy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImLazy.Visible = false;
            // 
            // VistaPensum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 691);
            this.Controls.Add(this.lblImLazy);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRegresar);
            this.Location = new System.Drawing.Point(50, -50);
            this.Name = "VistaPensum";
            this.Text = "Visualización de pensum";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VistaPensum_FormClosed);
            this.Load += new System.EventHandler(this.VistaPensum_Load);
            this.panelCiclos.ResumeLayout(false);
            this.panelCiclos.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCiclo1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblCiclo1;
        private System.Windows.Forms.Panel panelCiclos;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelGrafo;
        private System.Windows.Forms.Label lblImLazy;
        private System.Windows.Forms.OpenFileDialog Archivotxt;
    }
}