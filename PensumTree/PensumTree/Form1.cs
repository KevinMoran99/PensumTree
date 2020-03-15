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
        //Tutotial Setup EntityFramework: https://www.imaginaformacion.com/tutorial/como-conectar-entity-framework-con-mysql/

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
    }
}
