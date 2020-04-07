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
    public partial class MantenimientoTipoCarrera : Form
    {
        public MantenimientoTipoCarrera()
        {
            InitializeComponent();
        }

        
        private static TipoCarreraController tipoCarreraController = new TipoCarreraController();
        private List<tipo_carrera> carreras = new List<tipo_carrera>();
        private tipo_carrera selectedCarrera = null;

        private int[] columnsToHide = {4};
        private int[] columnsToChange = { 0, 1,2,3 };
        private string[] titlesforColumns = { "ID", "Nombre", "UV", "Estado" };

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void loadTable()
        {
            Operation<tipo_carrera> getCarreras = tipoCarreraController.getRecords();
            if (getCarreras.State)
            {
                carreras = getCarreras.Data;
                dgvTipoCarreras.DataSource = carreras;
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvTipoCarreras);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvTipoCarreras);
                return;
            }
            MessageBox.Show("Error al cargar los datos de carreras", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fillSelectedData(tipo_carrera currentCarr)
        {
            txtName.Text = currentCarr.nombre;
            txtUV.Text = currentCarr.minUv.ToString();
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
            tipo_carrera tempCarr = new tipo_carrera
            {
                nombre = txtName.Text,
                minUv = Convert.ToInt64(txtUV.Text),
                estado = rdbActivo.Checked
            };
            Operation<tipo_carrera> operation = tipoCarreraController.addRecord(tempCarr);
            if (operation.State)
            {
                MessageBox.Show("Tipo carrera agregado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        private void updateData(tipo_carrera currentCarr)
        {
            currentCarr.nombre = txtName.Text;
            currentCarr.minUv = Convert.ToInt64(txtUV.Text);
            currentCarr.estado = rdbActivo.Checked;

            Operation<tipo_carrera> operation = tipoCarreraController.updateRecord(currentCarr);
            if (operation.State)
            {
                MessageBox.Show("Tipo de carrera actualizado con éxito", "Éxito",
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
            string value = txtSearch.Text;
            if (!value.Equals(""))
            {
                List<tipo_carrera> tempCarreras = new List<tipo_carrera>();
                foreach (tipo_carrera f in carreras)
                {
                    if (f.nombre.ToLower().Contains(value))
                    {
                        tempCarreras.Add(f);
                    }
                }
                dgvTipoCarreras.DataSource = tempCarreras;
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
            button1.Text = "Agregar";
            selectedCarrera = null;
            errorProvider1.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls =
            {
                txtUV, txtName
            };
            return controls;
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtUV, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un UV" }),
                new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre para el tipo de carrera" })
            };
            return validators;
        }

        private void MantenimientoTipoCarrera_Load(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo la lista de validaciones para este form, y procediendo a validar
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                try
                {
                    if (!(int.Parse(txtUV.Text) >= 80 && int.Parse(txtUV.Text) <= 200))
                    {
                        if (errorProvider == null)
                        {
                            errorProvider = new List<ControlErrorProvider>();
                        }

                        errorProvider.Add(new ControlErrorProvider("Las UV solo pueden estar entre 8 y 200", txtUV));
                    }
                }
                catch { }

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

        private void Button3_Click(object sender, EventArgs e)
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

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MantenimientoTipoCarrera_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedCarrera = carreras[index];
                    button1.Text = "Modificar";
                    fillSelectedData(selectedCarrera);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
