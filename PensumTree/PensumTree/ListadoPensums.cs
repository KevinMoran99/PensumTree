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
    public partial class ListadoPensums : Form
    {
        private static PlanController planContoller = new PlanController();
        private List<plan> plans = new List<plan>();

        public ListadoPensums()
        {
            InitializeComponent();
        }

        private void loadTable()
        {
            int x = 0;
            int y = 0;

            Operation<plan> getPlans = planContoller.getRecords();
            if (getPlans.State)
            {
                plans = getPlans.Data;
                foreach (plan plan in plans)
                {
                    var control = new PensumControl(plan);
                    control.Location = new Point(x, y);
                    panel1.Controls.Add(control);
                    y += control.Height;
                    panel1.Height = panel1.Height + 90;

                }
                return;
            }
            MessageBox.Show("Error al cargar los datos de pensums", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void ListadoPensums_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void ListadoPensums_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdminAccess_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
