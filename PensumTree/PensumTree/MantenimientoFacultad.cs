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
        public MantenimientoFacultad()
        {
            InitializeComponent();
        }

        //Antes de comenzar con el código aquí, asegúrense de haberle dado nombre a todos los componentes
        //del form que se vayan a usar (ej. txtNombre para textbox, rdbActivo para radiobuttons,
        //btnLimpiar para botones, dgvFacultades para datagrids, etc). También agréguenle al
        //form un errorprovider con BlinkStyle = NeverBlink, y creen la clase controlador que usarán
        //(Más detalles al respecto en la línea 43)



        /*------------------------------------------------------------------------------*/
        //A partir de aquí, se declaran variables y métodos que serán usados en los eventos
        //del form que están más abajito. A partir de aquí, van a ir copiando y pegando
        //todito a sus formularios, y van a ir reemplazando todo lo que sea referente a 
        //facultades por lo que estén haciendo (ejemplo, para Escuela, en la siguiente 
        //línea diría EscuelaController escuelaController = new EscuelaController), y 
        //también van a tener que ir acoplando cosas específicas según la estructra del
        //objeto con el que estén trabajando.


        //Controlador que manejará todas las operaciones de la base de datos.
        //Este controlador deberán crearlo ustedes mismos en la carpeta Controllers, tomando
        //como base el FacultadController que está ahí. Ahí, literalmente, solo copian toda la clase
        //y reemplazan todo lo que diga facultad por el nombre del objeto que estén trabajando.
        private static FacultadController facultadController = new FacultadController();

        //Lista que contendrá todas las facultades existentes en la BD
        private List<facultad> facultades = new List<facultad>();

        //Facultad seleccionada al darle click a un registro en el DataGrid, se inicializa con null
        private facultad selectedFacultad = null;


        //En el datagridview, abrán algunas columnas que querrán ocultar porque contienen información
        //que no le importa al usuario (como las llaves foráneas), y abran otras columnas cuyo
        //encabezado deberá ser cambiado por un nombre más user friendly (ejemplo, cambiar
        //'primerCiclo' por 'Primer Ciclo'). Para dichos casos, los siguientes 3 array les servirán
        //de helpers para un método que se ejecuta en loadTable(). En el primero incluyen los index 
        //de todas las columnas a ocultar, en el segundo los index de las columnas cuyos nombres serán
        //cambiados, y en el tercero se incluyen dichos nombres.

        //Array que contiene todas las columna
        private int[] columnsToHide = { 3 };
        private int[] columnsToChange = {0, 1, 2};
        private string[] titlesforColumns = { "ID", "Nombre", "Activo" };
        

        //Obtiene la lista de facultades de la BD y la imprime en el datagrid
        private void loadTable()
        {
            //Obteniendo lista de facultades
            Operation<facultad> getFacultades = facultadController.getRecords();
            //Si la operación fue exitosa
            if (getFacultades.State)
            {
                //Estableciendo lista como el datasource del datagrid
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
            //Aquí deberán settearle a cada campo del formulario el valor que posea el registro seleccionado
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
            //Creando nuevo objeto facultad con la sintaxis de Entity
            facultad tempFac = new facultad
            {
                nombre = txtNombre.Text,
                estado = rdbActivo.Checked
            };
            //Guardando la facultad
            Operation<facultad> operation = facultadController.addRecord(tempFac);
            //Si la operación fue exitosa
            if (operation.State)
            {
                MessageBox.Show("Facultad agregada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        //Actualiza la facultad seleccionada (toma como parámetro dicha facultad)
        private void updateData(facultad currentFac)
        {
            //Pasándole a la facultad a modificar sus nuevos valores
            currentFac.nombre = txtNombre.Text;
            currentFac.estado = rdbActivo.Checked;

            //Modificando la facultad
            Operation<facultad> operation = facultadController.updateRecord(currentFac);
            //Si la operación fue exitosa
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
                List<facultad> tempFacultades = new List<facultad>();
                foreach (facultad f in facultades)
                {
                    if (f.nombre.ToLower().Contains(value))
                    {
                        tempFacultades.Add(f);
                    }
                }
                dgvFacultades.DataSource = tempFacultades;
            }
            else
            {
                loadTable();
            }
        }

        //Revierte el form entero a su estado original, limpia todos los campos
        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls()); //Este método limpia todos los textbox del formulario que se hayan especificado en el mismo, que está 10 líneas bajo esta
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


        //Aquí termina lo que deben copiar y pegar de pijazo. A partir de aquí comienzan los métodos
        //del form, los cuales deberán primero activar desde el designer y después copiar su contenido
        //de aquí, pegarlos en los suyos y acoplarlos a sus mantenimientos.
        //No olviden que el código de cada uno de los eventos debe estar dentro de un bloque trycatch
        //tal y como lo están estos, esto para evitar que alguna excepción controlada nos haga 
        //crashear a nuestro niño :C
        /*--------------------------------------------------------------------------------------------*/


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
                    //Hace que selectedFacultad tome el valor del registro seleccionado en el datagrid
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
