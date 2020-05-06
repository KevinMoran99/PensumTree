using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PensumTree.Controllers;
using PensumTree.EntityFramework;
using PensumTree.Models;
using PensumTree.Utils;

namespace PensumTree
{
    public partial class AddMateria : Form
    {

        private IAgregarMateria caller;
        
        private static EscuelaController escuelaController = new EscuelaController();
        private static MateriaController materiaController = new MateriaController();
        private List<materia> materias = new List<materia>();
        private List<escuela> escuelas = new List<escuela>();
        private bool selective;

        private materia selectedMateria = null;

        private int[] columnsToChange = { 0, 1, 2, 3, 4, 5, 6, 7, 13, 14, 16, 18, 20, 22, 23 };
        private int[] columnsToHide = { 8, 9, 10, 11, 12, 15, 17, 19, 21 };
        private string[] titlesforColumns = { "ID", "Nombre", "UV", "Código", "Ciclo Impar", "Ciclo Par", "Laboratorio", "Electiva", "Estado", "Escuela", "Pre-requisito1", "Pre-requisito2", "Pre-requisito3", "Pre-requisito4", "Pensum" };
        public AddMateria(IAgregarMateria padre, bool selective)
        {
            InitializeComponent();
            caller = padre;
            this.selective = selective;
        }

        private void loadTable()
        {
            Operation<materia> getMaterias = materiaController.getActiveRecords(selective);
            if (getMaterias.State)
            {
                materias = getMaterias.Data;
                dgvMaterias.DataSource = null;
                dgvMaterias.DataSource = materias;

                //Modificando propiedades del datagrid
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvMaterias);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvMaterias);
                return;
            }
            MessageBox.Show("Error al cargar los datos de materias", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadCbx()
        {
            Operation<escuela> getEscuelasOperation = escuelaController.getActiveRecords();

            if (getEscuelasOperation.State)
            {
                escuelas = getEscuelasOperation.Data;
                cbxEscuela.DataSource = escuelas;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos de las escuelas", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void filterData()
        {
            string value = txtBuscar.Text;
            

            List<materia> tempMateria;

            if (cbxEscuela.SelectedIndex != -1)
            {
                escuela filtro = (escuela)cbxEscuela.SelectedItem;
                long id = filtro.id;
                tempMateria = new List<materia>();
                foreach (materia m in materias)
                {
                    if (m.idEscuela == id)
                    {
                        tempMateria.Add(m);
                    }
                }
                dgvMaterias.DataSource = tempMateria;
                materias = tempMateria;
            }

            if (!value.Equals(""))
            {
                tempMateria = new List<materia>();
                foreach (materia m in materias)
                {
                    if (m.nombre.ToLower().Contains(value))
                    {
                        tempMateria.Add(m);
                    }
                }
                dgvMaterias.DataSource = tempMateria;
                materias = tempMateria;
            }

            if(cbxEscuela.SelectedIndex == -1 && value.Equals(""))
            {
                loadTable();
            }
        }

        private void AddMateria_Load(object sender, EventArgs e)
        {
            try
            {
                loadCbx();
                cbxEscuela.SelectedIndex = -1;
                //El loadtable se dispara cuando el index de cbxEscuela cambia
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                filterData();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedMateria = materias[index];
                    caller.Selected(selectedMateria);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void cbxEscuela_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            caller.Selected(selectedMateria);
            this.Dispose();
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxEscuela_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadTable();
                filterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar carrera");
            }
        }
    }
}
