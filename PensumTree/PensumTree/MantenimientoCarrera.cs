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
    public partial class MantenimientoCarrera : Form
    {
        public MantenimientoCarrera()
        {
            InitializeComponent();
        }

        private static CarreraController carreraController = new CarreraController();
        private static FacultadController facultadController = new FacultadController();
        private static TipoCarreraController tipoCarreraController = new TipoCarreraController();
        
        private List<facultad> facultades = new List<facultad>();
        private List<carrera> carreras = new List<carrera>();
        private List<tipo_carrera> tipo_carreras = new List<tipo_carrera>();

        private carrera selectedCarrera = null;

        private int[] columnsToHide = { 2, 3, 7  };
        private int[] columnsToChange = { 0, 1, 5,6, 4};
        private string[] titlesforColumns = { "ID", "Nombre", "Facultad", "Tipo Carrera", "Estado" };


        private void loadTable()
        {
            Operation<carrera> getCarreras = carreraController.getRecords();
            if (getCarreras.State)
            {
                carreras = getCarreras.Data;
                dgvCarreras.DataSource = carreras;
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvCarreras);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvCarreras);
                return;
            }
            MessageBox.Show("Error al cargar los datos de carreras", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadCbx()
        {
            Operation<facultad> getFacultades = facultadController.getActiveRecords();
            Operation<tipo_carrera> getTipoCarreras = tipoCarreraController.getActiveRecords();


            if (getFacultades.State)
            {
                facultades = getFacultades.Data;
                cmbFacultades.DataSource = facultades;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos de las facultades", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (getTipoCarreras.State)
            {
                tipo_carreras = getTipoCarreras.Data;
                cmbTipos.DataSource = tipo_carreras;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos de los tipos de carrera", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillSelectedData(carrera currentCarr)
        {
            txtNombre.Text = currentCarr.nombre;
            cmbFacultades.SelectedItem = currentCarr.facultad;
            cmbTipos.SelectedItem = currentCarr.tipo_carrera;
            if (currentCarr.estado)
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
            carrera tempCarr = new carrera
            {
                nombre = txtNombre.Text,
                idFacultad = ((facultad)cmbFacultades.SelectedValue).id,
                idTipo = ((tipo_carrera)cmbTipos.SelectedValue).id,
                estado = rdbActivo.Checked
            };
            Operation<carrera> operation =  carreraController.addRecord(tempCarr);
            if (operation.State)
            {
                MessageBox.Show("Carrera agregada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        private void updateData(carrera currentCarr)
        {
            currentCarr.nombre = txtNombre.Text;
            currentCarr.idFacultad = ((facultad)cmbFacultades.SelectedValue).id;
            currentCarr.idTipo = ((tipo_carrera)cmbTipos.SelectedValue).id;
            currentCarr.estado = rdbActivo.Checked;

            Operation<carrera> operation = carreraController.updateRecord(currentCarr);
            if (operation.State)
            {
                MessageBox.Show("Carrera actualizada con éxito", "Éxito",
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
                List<carrera> tempCarreras = new List<carrera>();
                foreach (carrera f in carreras)
                {
                    if (f.nombre.ToLower().Contains(value))
                    {
                        tempCarreras.Add(f);
                    }
                }
                dgvCarreras.DataSource = tempCarreras;
                carreras = tempCarreras;
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
            selectedCarrera = null;
            errorProvider1.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls =
            {
                txtNombre
            };
            return controls;
        }
       
        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtNombre, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre para la carrera" }),

                new ToValidate(cmbFacultades, new ControlValidator[] {FormValidators.isSelected},
                new string[]{"Seleccione una facultad "}),
            };
            return validators;
        }

        private void MantenimientoCarrera_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MantenimientoCarrera_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
                loadCbx();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
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
                    if (selectedCarrera == null)
                    {
                        saveData();
                    }
                    //Si se había seleccionado una facultad, se modifica dicho registro
                    else
                    {
                        updateData(selectedCarrera);
                    }
                }
                else
                {
                    //Si no se pasan las validaciones, se muestran los mensajes de error
                    this.errorProvider1.Clear();
                    MessageBox.Show("Algunos datos ingresados son inválidos.\n" +
                        "Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "Error al ingresar datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    foreach (ControlErrorProvider controlErrorProvider in errorProvider)
                    {
                        this.errorProvider1.SetError(controlErrorProvider.ControlName,
                            controlErrorProvider.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
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

        private void BntEliminar_Click(object sender, EventArgs e)
        {

        }

        private void DgvCarreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedCarrera = carreras[index];
                    btnAgregar.Text = "Modificar";
                    fillSelectedData(selectedCarrera);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
