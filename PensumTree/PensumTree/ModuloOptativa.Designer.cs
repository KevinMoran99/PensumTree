namespace PensumTree
{
    partial class ModuloOptativa
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
            this.lblCiclo1 = new System.Windows.Forms.Label();
            this.panelCiclo1 = new System.Windows.Forms.Panel();
            this.btnCiclo1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCiclo2 = new System.Windows.Forms.Panel();
            this.btnCiclo2 = new System.Windows.Forms.Button();
            this.panelCiclo1.SuspendLayout();
            this.panelCiclo2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCiclo1
            // 
            this.lblCiclo1.AutoSize = true;
            this.lblCiclo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCiclo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiclo1.Location = new System.Drawing.Point(93, 14);
            this.lblCiclo1.Margin = new System.Windows.Forms.Padding(5);
            this.lblCiclo1.Name = "lblCiclo1";
            this.lblCiclo1.Size = new System.Drawing.Size(67, 24);
            this.lblCiclo1.TabIndex = 5;
            this.lblCiclo1.Text = "Ciclo 9";
            // 
            // panelCiclo1
            // 
            this.panelCiclo1.AutoScroll = true;
            this.panelCiclo1.Controls.Add(this.btnCiclo1);
            this.panelCiclo1.Location = new System.Drawing.Point(13, 46);
            this.panelCiclo1.Name = "panelCiclo1";
            this.panelCiclo1.Size = new System.Drawing.Size(253, 385);
            this.panelCiclo1.TabIndex = 6;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(355, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ciclo 10";
            // 
            // panelCiclo2
            // 
            this.panelCiclo2.AutoScroll = true;
            this.panelCiclo2.Controls.Add(this.btnCiclo2);
            this.panelCiclo2.Location = new System.Drawing.Point(275, 46);
            this.panelCiclo2.Name = "panelCiclo2";
            this.panelCiclo2.Size = new System.Drawing.Size(253, 385);
            this.panelCiclo2.TabIndex = 8;
            // 
            // btnCiclo2
            // 
            this.btnCiclo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCiclo2.Location = new System.Drawing.Point(85, 14);
            this.btnCiclo2.Name = "btnCiclo2";
            this.btnCiclo2.Size = new System.Drawing.Size(56, 47);
            this.btnCiclo2.TabIndex = 1;
            this.btnCiclo2.Text = "+";
            this.btnCiclo2.UseVisualStyleBackColor = true;
            this.btnCiclo2.Click += new System.EventHandler(this.handlerComun_Click);
            // 
            // ModuloOptativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelCiclo2);
            this.Controls.Add(this.lblCiclo1);
            this.Controls.Add(this.panelCiclo1);
            this.Name = "ModuloOptativa";
            this.Text = "Materias optativas";
            this.Load += new System.EventHandler(this.ModuloOptativa_Load);
            this.panelCiclo1.ResumeLayout(false);
            this.panelCiclo2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCiclo1;
        private System.Windows.Forms.Panel panelCiclo1;
        private System.Windows.Forms.Button btnCiclo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCiclo2;
        private System.Windows.Forms.Button btnCiclo2;
    }
}