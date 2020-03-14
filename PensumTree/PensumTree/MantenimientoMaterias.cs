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
    public partial class MantenimientoMaterias : Form
    {
        private static EscuelaController escuelaController = new EscuelaController();
        private static MateriaController materiaController = new MateriaController();
        private List<materia> materias = new List<materia>();
        private List<escuela> escuelas = new List<escuela>();

        private materia selectedMateria= null;

        private int[] columnsToChange = { 0, 1, 2, 3,4,5,6,7,13,14,16,18,20,22,23};
        private int[] columnsToHide = {8,9,10,11,12,15,17,19,21 };
        private string[] titlesforColumns = { "ID", "Nombre", "UV", "Código", "Ciclo Impar", "Ciclo Par", "Laboratorio", "Electiva","Estado", "Escuela", "Pre-requisito1", "Pre-requisito2", "Pre-requisito3", "Pre-requisito4", "Pensum" };
        public MantenimientoMaterias()
        {
            InitializeComponent();
        }

        //Obtiene la lista de facultades de la BD y la imprime en el datagrid
        private void loadTable()
        {
            Operation<materia> getMaterias = materiaController.getRecords();
            if (getMaterias.State)
            {
                materias = getMaterias.Data;
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
            Operation<materia> getMateriasOperation = materiaController.getActiveRecords();
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

            if (getMateriasOperation.State)
            {
                materias = getMateriasOperation.Data;
                cbxPreReq1.DataSource = materias;
                cbxPreReq2.DataSource = materias;
                cbxPreReq3.DataSource = materias;
                cbxPreReq4.DataSource = materias;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos de materias pre-requisitos", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Rellena los campos de la facultad que se seleccione del datagrid
        private void fillSelectedData(materia currentMat)
        {
            txtNombre.Text = currentMat.nombre;
            txtCodigo.Text = currentMat.codigo;
            txtUV.Text =Convert.ToString(currentMat.uv);
            cbxEscuela.SelectedItem = currentMat.escuela;
            cbxPreReq1.SelectedItem = currentMat.materia2;
            cbxPreReq2.SelectedItem = currentMat.materia3;
            cbxPreReq3.SelectedItem = currentMat.materia4;
            cbxPreReq4.SelectedItem = currentMat.materia5;

            if (currentMat.primerCiclo)
            {
                chImpar.Checked = true;
            }
            if (currentMat.segundoCiclo)
            {
                chPar.Checked = true;
            }
            if (currentMat.electiva)
            {
                chElectiva.Checked = true;
            }
            if (currentMat.lab)
            {
                chLab.Checked = true;
            }
            if (currentMat.estado)
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
            materia tempMat = new materia
            {
                nombre = txtNombre.Text,
                codigo= txtCodigo.Text,
                uv=Convert.ToInt64( txtUV.Text),
                primerCiclo= chImpar.Checked,
                segundoCiclo= chPar.Checked,
                lab= chLab.Checked,
                electiva= chElectiva.Checked,
                idEscuela=((materia) cbxEscuela.SelectedValue).idEscuela,
                idPrerreq1= ((materia)cbxPreReq1.SelectedValue).idPrerreq1,
                idPrerreq2= ((materia)cbxPreReq2.SelectedValue).idPrerreq2,
                idPrerreq3= ((materia)cbxPreReq3.SelectedValue).idPrerreq3,
                idPrerreq4= ((materia)cbxPreReq4.SelectedValue).idPrerreq4,
                estado = rdbActivo.Checked
            };
            Operation<materia> operation = materiaController.addRecord(tempMat);
            if (operation.State)
            {
                MessageBox.Show("Materia agregada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        //Actualiza la facultad seleccionada
        private void updateData(materia currentMat)
        {
            currentMat.nombre = txtNombre.Text;
            currentMat.uv =Convert.ToInt64( txtUV.Text);
            currentMat.codigo = txtCodigo.Text;
            currentMat.estado = rdbActivo.Checked;
            currentMat.idEscuela = ((materia)cbxEscuela.SelectedValue).idEscuela;
            currentMat.idPrerreq1 = ((materia)cbxPreReq1.SelectedValue).idPrerreq1;
            currentMat.idPrerreq2 = ((materia)cbxPreReq2.SelectedValue).idPrerreq2;
            currentMat.idPrerreq3 = ((materia)cbxPreReq3.SelectedValue).idPrerreq3;
            currentMat.idPrerreq4 = ((materia)cbxPreReq4.SelectedValue).idPrerreq4;
            currentMat.electiva = chElectiva.Checked;
            currentMat.lab = chLab.Checked;
            currentMat.primerCiclo = chImpar.Checked;
            currentMat.segundoCiclo = chPar.Checked;
            Operation<materia> operation = materiaController.updateRecord(currentMat);
            if (operation.State)
            {
                MessageBox.Show("Materia actualizada con éxito", "Éxito",
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
                List<materia> tempMateria = new List<materia>();
                foreach (materia m in materias)
                {
                    if (m.nombre.ToLower().Contains(value))
                    {
                        tempMateria.Add(m);
                    }
                }
                dgvMaterias.DataSource = tempMateria;
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
            selectedMateria = null;
            errorProvider.Clear();
            chPar.Checked = false;
            chImpar.Checked = false;
            chElectiva.Checked = false;
            chLab.Checked = false;
        }

        //Retorna la lista de textbox que contiene el formulario
        //Se usa para no tener que estar limpiando cada textbox uno por uno al llamar a cleanForm
        private Control[] textControls()
        {
            //Poner dentro de este array los nombres de todos los textbox que tenga el formulario
            Control[] controls =
            {
                txtNombre,
                txtCodigo,
                txtUV
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
                new string[] { "Ingrese un nombre para la materia" }),

                new ToValidate(txtCodigo, new ControlValidator[]{FormValidators.hasText },
                new string[]{ "Ingrese un codigo para la materia"}),

                new ToValidate(txtUV, new ControlValidator[]{ FormValidators.isNumber},
                new string[]{"Solo se aceptan datos numericos"}),

                new ToValidate(cbxEscuela, new ControlValidator[] {FormValidators.isSelected},
                new string[]{"Seleccione una escuela "}),

               // new ToValidate(cbxPreReq1, new ControlValidator[]{ FormValidators.isSelected},
                //new string[]{"Seleccione una materia pre-requisito"})
            };
            return validators;
        }

        private void button1_Click(object sender, EventArgs e)
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
                    if (selectedMateria == null)
                    {
                        saveData();
                    }
                    //Si se había seleccionado una facultad, se modifica dicho registro
                    else
                    {
                        updateData(selectedMateria);
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

        private void MantenimientoMaterias_Load(object sender, EventArgs e)
        {
            //Al cargarse el form, lo primero que debe hacer es cargar la lista de facultades
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
                    fillSelectedData(selectedMateria);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void MantenimientoMaterias_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
    }
}
