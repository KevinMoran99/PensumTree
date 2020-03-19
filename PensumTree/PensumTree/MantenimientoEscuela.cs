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
using static PensumTree.Utils.FormValidators;

namespace PensumTree
{
    public partial class MantenimientoEscuela : Form
    {
        private static EscuelaController escuelaController = new EscuelaController();
        private List<escuela> escuelas = new List<escuela>();

        private escuela selectedEscuela = null;

        private int[] columnsToChange = { 0, 1, 2 };
        private int[] columnsToHide = { 3 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo" };
        public MantenimientoEscuela()
        {
            InitializeComponent();
        }
        private void loadTable()
        {
            Operation<escuela> getEscuelas = escuelaController.getRecords();
            if (getEscuelas.State)
            {
                escuelas = getEscuelas.Data;
                dgvEscuelas.DataSource = escuelas;

                //Modificando propiedades del datagrid
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvEscuelas);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvEscuelas);
                return;
            }
            MessageBox.Show("Error al cargar los datos de las escuelas", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void fillSelectedData(escuela currentEsc)
        {

            txtNombre.Text = currentEsc.nombre;
            if (currentEsc.estado)
            {
                rdbActivo.Checked = true;
            }
            else
            {
                rdbInactivo.Checked = true;
            }
        }

        private void saveData()
        {
            escuela tempEsc = new escuela
            {
                nombre = txtNombre.Text,
                estado = rdbActivo.Checked
            };
            Operation<escuela> operation = escuelaController.addRecord(tempEsc);
            if (operation.State)
            {
                MessageBox.Show("Escuela agregada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }
        private void updateData(escuela currentEsc)
        {
            currentEsc.nombre = txtNombre.Text;
            currentEsc.estado = rdbActivo.Checked;

            Operation<escuela> operation = escuelaController.updateRecord(currentEsc);
            if (operation.State)
            {
                MessageBox.Show("Escuela actualizada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void filterData()
        {
            string value = txtBuscar.Text;
            if (!value.Equals(""))
            {
                List<escuela> tempEscuelas = new List<escuela>();
                foreach (escuela es in escuelas)
                {
                    if (es.nombre.ToLower().Contains(value))
                    {
                        tempEscuelas.Add(es);
                    }
                }
                dgvEscuelas.DataSource = tempEscuelas;
            }
            else
            {
                loadTable();
            }
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            rdbActivo.Checked = true;
            rdbInactivo.Checked = false;
            btnAgregar.Text = "Agregar";
            selectedEscuela = null;
            errorProvider.Clear();
        }
        private Control[] textControls()
        {
            //Poner dentro de este array los nombres de todos los textbox que tenga el formulario
            Control[] controls =
            {
                txtNombre,
                txtBuscar
            };
            return controls;
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtNombre, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre para la escuela" })
            };
            return validators;
        }

        private void MantenimientoEscuela_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MantenimientoEscuela_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo la lista de validaciones para este form, y procediendo a validar
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                //Si se pasan todas las validaciones, se procede a guardar la información
                if (isValid)
                {
                    //Si no se ha seleccionado ninguna facultad, se crea un nuevo registro
                    if (selectedEscuela == null)
                    {
                        saveData();
                    }
                    //Si se había seleccionado una facultad, se modifica dicho registro
                    else
                    {
                        updateData(selectedEscuela);
                    }
                }
                else
                {
                    //Si no se pasan las validaciones, se muestran los mensajes de error
                    this.errorProvider.Clear();
                    MessageBox.Show("Algunos datos ingresados son inválidos.\n" +
                        "Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "Error al ingresar datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    foreach (ControlErrorProvider controlErrorProvider in errorProvider)
                    {
                        this.errorProvider.SetError(controlErrorProvider.ControlName,
                            controlErrorProvider.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                cleanForm();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
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

        private void dgvEscuelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedEscuela = escuelas[index];
                    btnAgregar.Text = "Modificar";
                    fillSelectedData(selectedEscuela);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
