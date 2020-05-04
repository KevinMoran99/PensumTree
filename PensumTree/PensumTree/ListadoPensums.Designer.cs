namespace PensumTree
{
    partial class ListadoPensums
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdminAccess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(320, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 29);
            this.lblTitulo.TabIndex = 83;
            this.lblTitulo.Text = "Lista de pensums";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 137);
            this.panel1.TabIndex = 84;
            // 
            // btnAdminAccess
            // 
            this.btnAdminAccess.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminAccess.Location = new System.Drawing.Point(576, 7);
            this.btnAdminAccess.Name = "btnAdminAccess";
            this.btnAdminAccess.Size = new System.Drawing.Size(194, 40);
            this.btnAdminAccess.TabIndex = 85;
            this.btnAdminAccess.Text = "Entrar como administrador";
            this.btnAdminAccess.UseVisualStyleBackColor = true;
            this.btnAdminAccess.Click += new System.EventHandler(this.BtnAdminAccess_Click);
            // 
            // ListadoPensums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdminAccess);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ListadoPensums";
            this.Text = "ListadoPensums";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoPensums_FormClosing);
            this.Load += new System.EventHandler(this.ListadoPensums_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdminAccess;
    }
}