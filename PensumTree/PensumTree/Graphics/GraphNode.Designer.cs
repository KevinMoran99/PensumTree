namespace PensumTree.Graphics
{
    partial class GraphNode
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorr = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPrerreq = new System.Windows.Forms.Label();
            this.lblUv = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pcbLab = new System.Windows.Forms.PictureBox();
            this.pcbCiclo2 = new System.Windows.Forms.PictureBox();
            this.pcbCiclo1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCiclo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCiclo1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(0, 21);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(210, 45);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Administración e Implementación de Servicios de Red con Sistemas Operativos Propi" +
    "etarios";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNombre.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblCorr
            // 
            this.lblCorr.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblCorr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorr.ForeColor = System.Drawing.Color.White;
            this.lblCorr.Location = new System.Drawing.Point(0, 0);
            this.lblCorr.Name = "lblCorr";
            this.lblCorr.Size = new System.Drawing.Size(105, 20);
            this.lblCorr.TabIndex = 4;
            this.lblCorr.Text = "40";
            this.lblCorr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCorr, "Correlativo");
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(106, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(105, 20);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "ASR104";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCodigo, "Código");
            // 
            // lblPrerreq
            // 
            this.lblPrerreq.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblPrerreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrerreq.ForeColor = System.Drawing.Color.White;
            this.lblPrerreq.Location = new System.Drawing.Point(0, 87);
            this.lblPrerreq.Name = "lblPrerreq";
            this.lblPrerreq.Size = new System.Drawing.Size(105, 20);
            this.lblPrerreq.TabIndex = 4;
            this.lblPrerreq.Text = "28,32";
            this.lblPrerreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUv
            // 
            this.lblUv.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblUv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUv.ForeColor = System.Drawing.Color.White;
            this.lblUv.Location = new System.Drawing.Point(106, 87);
            this.lblUv.Name = "lblUv";
            this.lblUv.Size = new System.Drawing.Size(105, 20);
            this.lblUv.TabIndex = 5;
            this.lblUv.Text = "4 UV";
            this.lblUv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblUv, "Unidades Valorativas");
            // 
            // pcbLab
            // 
            this.pcbLab.Image = global::PensumTree.Properties.Resources.beaker;
            this.pcbLab.Location = new System.Drawing.Point(55, 67);
            this.pcbLab.Name = "pcbLab";
            this.pcbLab.Size = new System.Drawing.Size(20, 20);
            this.pcbLab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLab.TabIndex = 8;
            this.pcbLab.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbLab, "Posee Laboratorio");
            this.pcbLab.Click += new System.EventHandler(this.pcbLab_Click);
            // 
            // pcbCiclo2
            // 
            this.pcbCiclo2.Image = global::PensumTree.Properties.Resources.Roman_2;
            this.pcbCiclo2.Location = new System.Drawing.Point(30, 67);
            this.pcbCiclo2.Name = "pcbCiclo2";
            this.pcbCiclo2.Size = new System.Drawing.Size(20, 20);
            this.pcbCiclo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCiclo2.TabIndex = 7;
            this.pcbCiclo2.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbCiclo2, "Disponible en ciclo Par");
            this.pcbCiclo2.Click += new System.EventHandler(this.pcbCiclo2_Click);
            // 
            // pcbCiclo1
            // 
            this.pcbCiclo1.Image = global::PensumTree.Properties.Resources.Roman_11;
            this.pcbCiclo1.Location = new System.Drawing.Point(4, 67);
            this.pcbCiclo1.Name = "pcbCiclo1";
            this.pcbCiclo1.Size = new System.Drawing.Size(20, 20);
            this.pcbCiclo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCiclo1.TabIndex = 6;
            this.pcbCiclo1.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbCiclo1, "Disponible en ciclo Impar");
            this.pcbCiclo1.Click += new System.EventHandler(this.pcbCiclo1_Click);
            // 
            // TreeNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pcbLab);
            this.Controls.Add(this.pcbCiclo2);
            this.Controls.Add(this.pcbCiclo1);
            this.Controls.Add(this.lblUv);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblCorr);
            this.Controls.Add(this.lblPrerreq);
            this.Controls.Add(this.lblNombre);
            this.Name = "TreeNode";
            this.Size = new System.Drawing.Size(210, 107);
            this.Click += new System.EventHandler(this.TreeNode_Click);
            this.DoubleClick += new System.EventHandler(this.TreeNode_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCiclo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCiclo1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorr;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPrerreq;
        private System.Windows.Forms.Label lblUv;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pcbCiclo1;
        private System.Windows.Forms.PictureBox pcbCiclo2;
        private System.Windows.Forms.PictureBox pcbLab;
    }
}
