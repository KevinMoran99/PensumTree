using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensumTree
{
    public partial class Form1 : Form
    {
        //Tutorial Setup EntityFramework: https://www.imaginaformacion.com/tutorial/como-conectar-entity-framework-con-mysql/

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MantenimientoCarrera frm = new MantenimientoCarrera();
            frm.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MantenimientoEscuela frm = new MantenimientoEscuela();
            frm.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MantenimientoFacultad frm = new MantenimientoFacultad();
            frm.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MantenimientoTipoCarrera frm = new MantenimientoTipoCarrera();
            frm.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MantenimientoMaterias frm = new MantenimientoMaterias();
            frm.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MantenimientoPensum frm = new MantenimientoPensum();
            frm.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ModuloPensum frm = new ModuloPensum();
            frm.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
