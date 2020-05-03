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
        public PensumControl()
        {
            InitializeComponent();
        }

        public PensumControl(plan plan): this()
        {
            lblInicio.Text = plan.inicio.ToString();
            lblFin.Text = plan.fin.ToString();
            chbEstado.Checked = plan.estado;
            chbEstado.Text = plan.estado ? "Activo" : "Inactivo";
            lblCarrera.Text = plan.carrera.ToString();
        }
    }
}
