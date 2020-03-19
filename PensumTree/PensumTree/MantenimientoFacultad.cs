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
    public partial class MantenimientoFacultad : Form
    {

        private static FacultadController facultadController = new FacultadController();
        private List<facultad> facultades = new List<facultad>();

        private facultad selectedFacultad = null;

        //Headers del datagrid cuyo display será modificado
        private int[] columnsToChange = {0, 1, 2};
        private int[] columnsToHide = { 3 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo" };
        public MantenimientoFacultad()
        {
            InitializeComponent();
        }

        //Obtiene la lista de facultades de la BD y la imprime en el datagrid
        private void loadTable()
        {
            Operation<facultad> getFacultades = facultadController.getRecords();
            if (getFacultades.State)
            {
                facultades = getFacultades.Data;
                dgvFacultades.DataSource = facultades;

                //Modificando propiedades del datagrid
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvFacultades);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvFacultades);
                return;
            }
            MessageBox.Show("Error al cargar los datos de facultades", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Rellena los campos de la facultad que se seleccione del datagrid
        private void fillSelectedData(facultad currentFac)
        {
            
            txtNombre.Text = currentFac.nombre;
            if (currentFac.estado)
            {
                rdbActivo.Checked = true;
            }
            else
            {
                rdbInactivo.Checked = true;
            }
        }

        //Guarda una facultad en la BD
        private void saveData()
        {
            facultad tempFac = new facultad
            {
                nombre = txtNombre.Text,
                estado = rdbActivo.Checked
            };
            Operation<facultad> operation = facultadController.addRecord(tempFac);
            if (operation.State)
            {
                MessageBox.Show("Facultad agregada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        //Actualiza la facultad seleccionada
        private void updateData(facultad currentFac)
        {
            currentFac.nombre = txtNombre.Text;
            currentFac.estado = rdbActivo.Checked;

            Operation<facultad> operation = facultadController.updateRecord(currentFac);
            if (operation.State)
            {
                MessageBox.Show("Facultad actualizada con éxito", "Éxito",
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

        //Filtra el datagrid por nombre
        private void filterData()
        {
            string value = txtBuscar.Text;
            if (!value.Equals(""))
            {
                List<facultad> tempDepartments = new List<facultad>();
                foreach (facultad f in facultades)
                {
                    if (f.nombre.ToLower().Contains(value))
                    {
                        tempDepartments.Add(f);
                    }
                }
                dgvFacultades.DataSource = tempDepartments;
            }
            else
            {
                loadTable();
            }
        }

        //Revierte el form entero a su estado original
        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            rdbActivo.Checked = true;
            rdbInactivo.Checked = false;
            btnAgregar.Text = "Agregar";
            selectedFacultad = null;
            errorProvider.Clear();
        }

        //Retorna la lista de textbox que contiene el formulario
        //Se usa para no tener que estar limpiando cada textbox uno por uno al llamar a cleanForm
        private Control[] textControls()
        {
            //Poner dentro de este array los nombres de todos los textbox que tenga el formulario
            Control[] controls =
            {
                txtNombre
            };
            return controls;
        }

        //Array que contiene todas las validaciones básicas por las que debe pasar un objeto antes
        //de ser guardado/modificado, por ejemplo, que los campos no estén vacíos, que no se ingresen
        //letras en campos numéricos, etc.

        //Cada elemento del Array es un objeto ToValidate cuyos parámetros son los siguientes:
        //1- El control sobre el que se realizará la validación
        //2- Un objeto ControlValidator[] que contiene la validación a realizar
        //3- El mensaje de error que se mostrará al no cumplir la validación
        //  Las validaciones del 2do parámetro están definidas en la clase Utils.FormValidators
        //  Pueden revisar esa clase para ver qué validaciones básicas estan disponibles
        //  Si necesitasen de una validación que no esté disponible en la clase, pueden agregarla a la misma,
        //  o si se tratase de una validación no tan básica, deben handlearla desde el código del botón guardar
        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtNombre, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre para la facultad" })
            };
            return validators;
        }

        private void MantenimientoFacultad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MantenimientoFacultad_Load(object sender, EventArgs e)
        {
            //Al cargarse el form, lo primero que debe hacer es cargar la lista de facultades
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

        //Se usa un mismo botón para agregar y para modificar, según sea el caso
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
                    if (selectedFacultad == null)
                    {
                        saveData();
                    }
                    //Si se había seleccionado una facultad, se modifica dicho registro
                    else
                    {
                        updateData(selectedFacultad);
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

        //Al hacer click en un registro del datagrid
        private void dgvFacultades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedFacultad = facultades[index];
                    btnAgregar.Text = "Modificar";
                    fillSelectedData(selectedFacultad);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
