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
        private static MateriaController materiaController = new MateriaController();
        private List<materia> materias = new List<materia>();

        private facultad selectedMateria= null;
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
                //FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvFacultades);
                //FormUtils.hideColumnsForDgv(columnsToHide, dgvFacultades);
                return;
            }
            MessageBox.Show("Error al cargar los datos de materias", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Rellena los campos de la facultad que se seleccione del datagrid
        private void fillSelectedData(materia currentMat)
        {
            txtNombre.Text = currentMat.nombre;
            txtCodigo.Text = currentMat.codigo;
            txtUV.Text =Convert.ToString(currentMat.uv);
            cbxEscuela.SelectedItem = currentMat.idEscuela;
            cbxPreReq1.SelectedItem = currentMat.idPrerreq1;
            cbxPreReq2.SelectedItem = currentMat.idPrerreq2;
            cbxPreReq3.SelectedItem = currentMat.idPrerreq3;
            cbxPreReq4.SelectedItem = currentMat.idPrerreq4;

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

                new ToValidate(cbxPreReq1, new ControlValidator[]{ FormValidators.isSelected},
                new string[]{"Seleccione una materia pre-requisito"})
            };
            return validators;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
