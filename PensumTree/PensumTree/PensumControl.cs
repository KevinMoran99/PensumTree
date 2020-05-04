using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PensumTree.Controllers;
using PensumTree.EntityFramework;
using PensumTree.Utils;

namespace PensumTree
{
    public partial class PensumControl : UserControl
    {
        plan sendPlan;
        public PensumControl()
        {
            InitializeComponent();
        }

        public PensumControl(plan plan): this()
        {
            sendPlan = plan;
            lblInicio.Text = plan.inicio.ToString();
            lblFin.Text = plan.fin.ToString();
            chbEstado.Checked = plan.estado;
            chbEstado.Text = plan.estado ? "Activo" : "Inactivo";
            lblCarrera.Text = plan.carrera.ToString();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            VistaPensum frm = new VistaPensum(sendPlan, false);
            this.Parent.Parent.Hide();
            frm.Show();
        }
    }
}
