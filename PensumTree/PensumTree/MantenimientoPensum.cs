using PensumTree.Controllers;
using PensumTree.EntityFramework;
using PensumTree.Utils;
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
    public partial class MantenimientoPensum : Form
    {
        private static PlanController planContoller = new PlanController();
        private List<plan> plans = new List<plan>();

        public MantenimientoPensum()
        {
            InitializeComponent();
        }

        private int[] columnsToChange = { 0,2,3,4,5 };
        private int[] columnsToHide = { 1,6 };
        private string[] titlesforColumns = { "ID", "Año de inicio", "Año de fin", "Estado", "Carrera" };

        private void loadTable()
        {
            Operation<plan> getPlans = planContoller.getRecords();
            if (getPlans.State)
            {
                plans = getPlans.Data;
                dgvPensum.DataSource = plans;

                //Modificando propiedades del datagrid
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvPensum);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvPensum);
                return;
            }
            MessageBox.Show("Error al cargar los datos de pensums", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ModuloPensum frm = new ModuloPensum();
            frm.Show();
            this.Hide();
        }

        private void MantenimientoPensum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MantenimientoPensum_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void dgvPensum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    VistaPensum frm = new VistaPensum(plans[index]);
                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }

            
        }
    }
}
