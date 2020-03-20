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
using PensumTree.Graphics;
using PensumTree.Models;
using PensumTree.Utils;
using QuickGraph;
using static PensumTree.Utils.FormValidators;

namespace PensumTree
{
    public partial class ModuloPensum : Form, IAgregarMateria
    {

        private static CarreraController carreraController = new CarreraController();
        private List<carrera> carreras = new List<carrera>();
        private static PlanController planController = new PlanController();
        private static PensumController pensumController = new PensumController();
        private List<pensum> pMaterias = new List<pensum>();

        plan selectedPensum = null;

        //variables de posicion para las materias
        public int[] arrayY = new int[10];

        //Estas variables fueron reemplazadas por arrayY
        /*private int y1 = 14;
        private int y2 = 14;
        private int y3 = 14;
        private int y4 = 14;
        private int y5 = 14;
        private int y6 = 14;
        private int y7 = 14;
        private int y8 = 14;
        private int y9 = 14;
        private int y10 = 14;*/

        //contadoras para el número máximo de materias por ciclo
        public int[] arrayCont = new int[10];

        //Estas variables fueron reemplazadas por arrayCont
        /*private int cont1 = 1;
        private int cont2 = 1;
        private int cont3 = 1;
        private int cont4 = 1;
        private int cont5 = 1;
        private int cont6 = 1;
        private int cont7 = 1;
        private int cont8 = 1;
        private int cont9 = 1;
        private int cont10 = 1;*/

        private int num_lbl = 2;     //Esta variable sirve como contadora para los labels de encabezado de ciclo que genera loadElements
        private int num_panel = 2;   //Esta variable sirve como contadora para los panels de ciclo que genera loadElements
        private int num_btn = 2;   //Esta variable sirve como contadora para los botones de ciclo que genera loadElements
        private int lbl_x = 364;     //variable x para la position de los labels
        private int panel_x = 293;   //variable x para la position de los panels
        private int btn_x = 364;     //variable x para la position de los botones

        private materia _mat = new materia();

        public BidirectionalGraph<NetNode, Edge<NetNode>> pensum;
        public NetNode[,] positionMatrix = new NetNode[10, 7]; //Matriz que organiza cada materia según su posición lógica en la malla

        public NetNode current = null;
        private int nodeX = 12;
        private int nodeY = 15;
        public ModuloPensum()
        {
            InitializeComponent();
        }
        public ModuloPensum(plan currentPensum)
        {
            InitializeComponent();

            selectedPensum = currentPensum;
        }

        private void loadCbx()
        {
            Operation<carrera> getCarreras = carreraController.getActiveRecords();

            if (getCarreras.State)
            {
                carreras = getCarreras.Data;
                cmbCarrera.DataSource = carreras;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos de las carreras", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadPensumList()
        {
            Operation<pensum> getPensum = pensumController.getRecordsByPlan(selectedPensum.id);

            if (getPensum.State)
            {
                pMaterias = getPensum.Data;
            }
            else
            {
                MessageBox.Show("Error al las materias del pensum", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Este handler se agrega a los botones "+" para poder agregar materias
        //Lo escribi en el codigo ya que estos botones de generan y por lo tanto se tiene que agregar manualmente sus handlers
        private void handlerComun_Click(object sender, EventArgs e)
        {
            int cont = 0;
            int y = 0;
            buscarMateria();

            //Variables de posición lógica de las materias
            int matrixX = Convert.ToInt32(((Button)sender).Name.ToString().Replace("btnCiclo", "")) - 1;
            int matrixY = arrayCont[matrixX] - 1;


            //Verificando que la materia haya sido ingresada en un ciclo en el que esté disponible
            if ((matrixX + 1) % 2 != 0)
            {
                if (!_mat.primerCiclo)
                {
                    MessageBox.Show("La materia seleccionada no está disponible en ciclos impares.");
                    return;
                }
            }
            else
            {
                if (!_mat.segundoCiclo)
                {
                    MessageBox.Show("La materia seleccionada no está disponible en ciclos pares.");
                    return;
                }
            }


            //Verificando que los prerrequisitos de la materia seleccionada existan en el grafo
            bool preOk = true;

            bool preOk1 = (_mat.idPrerreq1 == null);
            bool preOk2 = (_mat.idPrerreq2 == null);
            bool preOk3 = (_mat.idPrerreq3 == null);
            bool preOk4 = (_mat.idPrerreq4 == null);

            NetNode pre1 = null;
            NetNode pre2 = null;
            NetNode pre3 = null;
            NetNode pre4 = null;

            foreach (NetNode n in pensum.Vertices)
            {
                if(n.Mat == _mat) //Si la materia está repetida
                {
                    MessageBox.Show("Esta materia ya existe en el pensum");
                    return;
                }

                if(_mat.idPrerreq1 != null)
                {
                    if (n.Mat == _mat.materia2)
                    {
                        preOk1 = true;
                        pre1 = n;
                    }
                }
                if (_mat.idPrerreq2 != null)
                {
                    if (n.Mat == _mat.materia3)
                    {
                        preOk2 = true;
                        pre2 = n;
                    }
                }
                if (_mat.idPrerreq3 != null)
                {
                    if (n.Mat == _mat.materia4)
                    {
                        preOk3 = true;
                        pre3 = n;
                    }
                }
                if (_mat.idPrerreq4 != null)
                {
                    if (n.Mat == _mat.materia5)
                    {
                        preOk4 = true;
                        pre4 = n;
                    }
                }

                preOk = preOk1 && preOk2 && preOk3 && preOk4;
            }
            

            if (!preOk)
            {
                string prerreqs = "";

                if (_mat.materia2 != null)
                {
                    prerreqs += "\n - " + _mat.materia2.nombre;
                }
                if (_mat.materia3 != null)
                {
                    prerreqs += "\n - " + _mat.materia3.nombre;
                }
                if (_mat.materia4 != null)
                {
                    prerreqs += "\n - " + _mat.materia4.nombre;
                }
                if (_mat.materia5 != null)
                {
                    prerreqs += "\n - " + _mat.materia5.nombre;
                }

                MessageBox.Show("Para añadir esta materia al pensum, hace falta añadir con anterioridad los siguientes prerrequisitos:" + prerreqs);
                return;
            }

            //Verificando que los prerrequisitos de la materia estén posicionados en ciclos anteriores al ciclo en el que se está poniendo la nueva materia
            bool posOk = true;
            if(pre1 != null)
            {
                posOk &= !(pre1.X >= matrixX);
            }
            if (pre2 != null)
            {
                posOk &= !(pre2.X >= matrixX);
            }
            if (pre3 != null)
            {
                posOk &= !(pre3.X >= matrixX);
            }
            if (pre4 != null)
            {
                posOk &= !(pre4.X >= matrixX);
            }

            if (!posOk)
            {
                MessageBox.Show("Los prerrequisitos de la materia deben estar ubicados en ciclos anteriores al seleccionado.");
                return;
            }



            cont = arrayCont[matrixX];
            y = arrayY[matrixX];
            arrayCont[matrixX]++;
            arrayY[matrixX] += 115;

            //Al usar arrays en vez de las variables, se puede reemplazar el switch por las cuatro líneas de arriba
            /*switch (((Button)sender).Name.ToString())  //Este switch registra a que ciclo se tiene que agregar la materia
            {                                          //Segun el ciclo busca las coordenadas y el número de materias que ya tiene ese ciclo
                case "btnCiclo1":
                    cont = cont1;
                    y = y1;
                    cont1++;
                    y1 += 115;
                    break;
                case "btnCiclo2":
                    cont = cont2;
                    y = y2;
                    cont2++;
                    y2 += 115;
                    break;
                case "btnCiclo3":
                    cont = cont3;
                    y = y3;
                    cont3++;
                    y3 += 115;
                    break;
                case "btnCiclo4":
                    cont = cont4;
                    y = y4;
                    cont4++;
                    y4 += 115;
                    break;
                case "btnCiclo5":
                    cont = cont5;
                    y = y5;
                    cont5++;
                    y5 += 115;
                    break;
                case "btnCiclo6":
                    cont = cont6;
                    y = y6;
                    cont6++;
                    y6 += 115;
                    break;
                case "btnCiclo7":
                    cont = cont7;
                    y = y7;
                    cont7++;
                    y7 += 115;
                    break;
                case "btnCiclo8":
                    cont = cont8;
                    y = y8;
                    cont8++;
                    y8 += 115;
                    break;
                case "btnCiclo9":
                    cont = cont9;
                    y = y9;
                    cont9++;
                    y9 += 115;
                    break;
                case "btnCiclo10":
                    cont = cont10;
                    y = y10;
                    cont10++;
                    y10 += 115;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

            matrixY = cont - 1;*/

            if (cont < 6)                   //Este if controla que no se sobrepase mas de 5 materias por ciclo
            {
                NetNode nodo = new NetNode(this, _mat, matrixX, matrixY);
                nodo.Left = 15;
                nodo.Top = y;
                y += 115;
                cont++;
                Panel padre = (Panel)((Button)sender).Parent;
                padre.Controls.Add(nodo);
                ((Button)sender).Location = new Point(84, y);

                //Añadiendo materia al grafo
                pensum.AddVertex(nodo);

                //Añadiendo materia a matriz
                positionMatrix[matrixX, matrixY] = nodo;

                //Convirtiendo relaciones de prerrequisitos en aristas del grafo
                if(pre1 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre1, nodo);
                    pensum.AddEdge(edge);
                }
                if (pre2 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre2, nodo);
                    pensum.AddEdge(edge);
                }
                if (pre3 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre3, nodo);
                    pensum.AddEdge(edge);
                }
                if (pre4 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre4, nodo);
                    pensum.AddEdge(edge);
                }

                //Actualizando correlativos
                actualizarCorr();

                if (cont == 6)
                {
                    ((Button)sender).Visible = false;
                }
            }
            else
            {
                ((Button)sender).Visible = false;
            }


        }

        private void generatePensumFromList()
        {
            foreach(pensum mat in pMaterias)
            {
                int cont = arrayCont[mat.ciclo - 1];
                int y = arrayY[mat.ciclo - 1];
                arrayCont[mat.ciclo - 1]++;
                arrayY[mat.ciclo - 1] += 115;


                Panel padre = (Panel)(this.Controls.Find("panelCiclo" + (mat.ciclo), true)[0]);
                Button currentButton = ((Button)(padre.Controls.Find("btnCiclo" + (mat.ciclo), true)[0]));


                if (cont < 6)                   //Este if controla que no se sobrepase mas de 5 materias por ciclo
                {
                    NetNode nodo = new NetNode(this, mat.materia, (int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2);
                    nodo.Left = 15;
                    nodo.Top = y;
                    y += 115;
                    cont++;
                    padre.Controls.Add(nodo);

                    currentButton.Location = new Point(84, y);

                    //Añadiendo materia al grafo
                    pensum.AddVertex(nodo);

                    //Añadiendo materia a matriz
                    positionMatrix[(int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2] = nodo;

                    bool preFound1 = mat.materia.idPrerreq1 == null;
                    bool preFound2 = mat.materia.idPrerreq2 == null;
                    bool preFound3 = mat.materia.idPrerreq3 == null;
                    bool preFound4 = mat.materia.idPrerreq4 == null;
                    NetNode pre1 = null;
                    NetNode pre2 = null;
                    NetNode pre3 = null;
                    NetNode pre4 = null;

                    foreach (NetNode n in pensum.Vertices)
                    {
                        if (mat.materia.idPrerreq1 != null)
                        {
                            if (n.Mat == mat.materia.materia2)
                            {
                                preFound1 = true;
                                pre1 = n;
                            }
                        }
                        if (mat.materia.idPrerreq2 != null)
                        {
                            if (n.Mat == mat.materia.materia3)
                            {
                                preFound2 = true;
                                pre2 = n;
                            }
                        }
                        if (mat.materia.idPrerreq3 != null)
                        {
                            if (n.Mat == mat.materia.materia4)
                            {
                                preFound3 = true;
                                pre3 = n;
                            }
                        }
                        if (mat.materia.idPrerreq4 != null)
                        {
                            if (n.Mat == mat.materia.materia5)
                            {
                                preFound4 = true;
                                pre4 = n;
                            }
                        }

                        if(preFound1 && preFound2 && preFound3 && preFound4)
                        {
                            break;
                        }
                    }

                    //Convirtiendo relaciones de prerrequisitos en aristas del grafo
                    if (mat.materia.idPrerreq1 != null)
                    {
                        Edge<NetNode> edge = new Edge<NetNode>(pre1, nodo);
                        pensum.AddEdge(edge);
                    }
                    if (mat.materia.idPrerreq2 != null)
                    {
                        Edge<NetNode> edge = new Edge<NetNode>(pre2, nodo);
                        pensum.AddEdge(edge);
                    }
                    if (mat.materia.idPrerreq3 != null)
                    {
                        Edge<NetNode> edge = new Edge<NetNode>(pre3, nodo);
                        pensum.AddEdge(edge);
                    }
                    if (mat.materia.idPrerreq4 != null)
                    {
                        Edge<NetNode> edge = new Edge<NetNode>(pre4, nodo);
                        pensum.AddEdge(edge);
                    }

                    

                    if (cont == 6)
                    {
                        currentButton.Visible = false;
                    }
                }
                else
                {
                    currentButton.Visible = false;
                }
            }

            //Actualizando correlativos
            actualizarCorr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (cont1 < 6)
            {

                Button temp = new Button();

                temp.Height = 107;
                temp.Width = 210;
                temp.Location = new Point(10, y1);
                y1 += 115;
                temp.Name = "btnBoton" + cont1.ToString();
                temp.Text = "Materia" + cont1.ToString();
                cont1++;
                temp.Click += new EventHandler(agregarMateria_Click);
                panelCiclo1.Controls.Add(temp);

                button1.Location = new Point(84, y1);
                if (cont1 == 6)
                {
                    button1.Visible = false;
                }
            }
            else
            {
                button1.Visible = false;
            }*/

        }

        //loadElements es una variable que genera los labels y panels para los ciclos 
        //(los genero así por el espacio que utilizan y asi poder activar el scroll)
        private void loadElements()
        {

            for (int i = 1; i < 10; i++)      //Este for genera los labels
            {
                Label temp = new Label();
                temp.Width = 80;
                temp.Height = 24;
                temp.Location = new Point(lbl_x, 5);
                lbl_x += 269;
                temp.Name = "lblCiclo" + num_lbl.ToString();
                temp.Text = "Ciclo " + num_lbl.ToString();
                temp.BackColor = SystemColors.GradientActiveCaption;
                temp.Font = lblCiclo1.Font;
                num_lbl++;
                panelCiclos.Controls.Add(temp);
            }

            for (int i = 1; i < 10; i++)    //Este for genera los paneles
            {
                Panel temp = new Panel();
                temp.Width = 253;
                temp.Height = 567;
                temp.AutoScroll = true;
                temp.Location = new Point(panel_x, 37);
                panel_x += 269;
                temp.Name = "panelCiclo" + num_panel.ToString();
                num_panel++;
                Button btemp = new Button();
                btemp.Width = 56;
                btemp.Height = 47;
                btemp.Location = new Point(87, 14);
                btemp.Name = "btnCiclo" + num_btn.ToString();
                btemp.Text = "+";
                btemp.Font = btnCiclo1.Font;
                btemp.Click += new EventHandler(handlerComun_Click);
                num_btn++;
                temp.Controls.Add(btemp);
                panelCiclos.Controls.Add(temp);
            }
        }

        //Interfaz donde seleccionaremos la materia que queremos agregar
        private void buscarMateria()
        {
            AddMateria buscarm = new AddMateria(this);
            buscarm.ShowDialog();
        }

        #region IAgregarMateria members
        public void Selected(materia mat)
        {
            _mat = mat;
        }

        #endregion

        private void agregarMateria_Click(object sender, EventArgs e)
        {
            buscarMateria();
        }

        private void ModuloPensum_Load(object sender, EventArgs e)
        {
            loadElements();             //Esta funcion carga los labels y panels de cada ciclo
            loadCbx();

            pensum = new BidirectionalGraph<NetNode, Edge<NetNode>>();

            arrayY[0] = 14;
            arrayY[1] = 14;
            arrayY[2] = 14;
            arrayY[3] = 14;
            arrayY[4] = 14;
            arrayY[5] = 14;
            arrayY[6] = 14;
            arrayY[7] = 14;
            arrayY[8] = 14;
            arrayY[9] = 14;

            arrayCont[0] = 1;
            arrayCont[1] = 1;
            arrayCont[2] = 1;
            arrayCont[3] = 1;
            arrayCont[4] = 1;
            arrayCont[5] = 1;
            arrayCont[6] = 1;
            arrayCont[7] = 1;
            arrayCont[8] = 1;
            arrayCont[9] = 1;

            if (selectedPensum != null)
            {
                txtInicio.Text = selectedPensum.inicio.ToString();
                txtFin.Text = selectedPensum.fin.ToString();
                cmbCarrera.SelectedItem = selectedPensum.carrera;

                if (selectedPensum.estado)
                {
                    rdbActivo.Checked = true;
                }
                else
                {
                    rdbInactivo.Checked = true;
                }

                loadPensumList();
                generatePensumFromList();
            }
        }

        public void actualizarCorr()
        {
            int corr = 1;

            //Recorriendo matriz posición
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 7; y++)
                {
                    //Si la posición actual contiene una materia
                    if(positionMatrix[x,y] != null)
                    {
                        //Si el correlativo de la materia ha cambiado
                        if (positionMatrix[x, y].Corr != corr)
                        {
                            //Obteniendo correlativos de los prerrequisitos de la materia
                            string prerreqCorrs = "";
                            foreach (Edge<NetNode> edge in pensum.InEdges(positionMatrix[x, y]))
                            {
                                prerreqCorrs += edge.Source.Corr + ",";
                            }
                            if (!prerreqCorrs.Equals(""))
                            {
                                prerreqCorrs = prerreqCorrs.Substring(0, prerreqCorrs.Length - 1); //Eliminando coma del final
                            }

                            positionMatrix[x, y].setCorr(corr, prerreqCorrs); //Actualizando correlativos del nodo
                        }


                        corr++;
                    }
                }
            }
        }

        private bool checkPlanRange()
        {
            int idCarrera = Convert.ToInt32(((carrera)cmbCarrera.SelectedItem).id);
            int inicio = Convert.ToInt32(txtInicio.Text);
            int fin = Convert.ToInt32(txtInicio.Text);

            Operation<plan> getPlans = planController.getActiveRecordsByCareer(idCarrera);

            if (getPlans.State)
            {

                foreach(plan p in getPlans.Data)
                {
                    if(inicio <= p.fin && p.inicio <= fin)
                    {
                        if(selectedPensum != null)
                        {
                            if(selectedPensum.id != p.id)
                            {
                                MessageBox.Show("El rango de años seleccionado tiene conflicto con el de otro plan creado para esta carrera.");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El rango de años seleccionado tiene conflicto con el de otro plan creado para esta carrera.");
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Error al verificar el rango del plan.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool savePlan()
        {
            plan tempPlan = new plan
            {
                idCarrera = ((carrera)cmbCarrera.SelectedItem).id,
                inicio = Convert.ToInt64(txtInicio.Text),
                fin = Convert.ToInt64(txtFin.Text),
                estado = rdbActivo.Checked
            };
            Operation<plan> operation = planController.addRecord(tempPlan);
            if (operation.State)
            {
                operation = planController.getLatestRecord();
                selectedPensum = (plan)operation.Value;
                return true;
            }
            else
            {
                MessageBox.Show(operation.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool updatePlan(plan currentPlan)
        {
            currentPlan.inicio = Convert.ToInt64(txtInicio.Text);
            currentPlan.fin = Convert.ToInt64(txtFin.Text);
            currentPlan.estado = rdbActivo.Checked;
            currentPlan.idCarrera = ((carrera)cmbCarrera.SelectedValue).id;

            Operation<plan> operation = planController.updateRecord(currentPlan);
            if (operation.State)
            {
                return true;
            }
            else
            {
                MessageBox.Show(operation.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool savePensum()
        {
            int corr = 1;
            //Recorriendo matriz posición
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    //Si la posición actual contiene una materia
                    if (positionMatrix[x, y] != null)
                    {
                        pensum tempPensum = new pensum
                        {
                            idPlan = selectedPensum.id,
                            idMateria = positionMatrix[x, y].Mat.id,
                            corr = positionMatrix[x, y].Corr,
                            ciclo = positionMatrix[x, y].X + 1,
                            estado = true
                        };
                        Operation<pensum> operation = pensumController.addOrUpdateRecord(tempPensum);
                        if (operation.State)
                        {
                            corr++;
                        }
                        else
                        {
                            MessageBox.Show(operation.Error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            
            //Si se guardaron menos materias de las que se tenía inicialmente, las sobrantes deben ser eliminadas de la BD
            if (pMaterias.Count > 0)
            {
                while (corr <= pMaterias.Count)
                {
                    Operation<pensum> operation = pensumController.deleteRecord(selectedPensum.id, corr);
                    if (operation.State)
                    {
                        corr++;
                    }
                    else
                    {
                        MessageBox.Show(operation.Error, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            

            return true;
        }

            private Control[] textControls()
        {
            //Poner dentro de este array los nombres de todos los textbox que tenga el formulario
            Control[] controls =
            {
                txtInicio,
                txtFin
            };
            return controls;
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtInicio, new ControlValidator[]{FormValidators.isNumber },
                new string[]{ "Solo se aceptan datos numéricos"}),

                new ToValidate(txtFin, new ControlValidator[]{ FormValidators.isNumber},
                new string[]{"Solo se aceptan datos numéricos"}),

                new ToValidate(cmbCarrera, new ControlValidator[] {FormValidators.isSelected},
                new string[]{"Seleccione una carrera"})
            };
            return validators;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                //Obteniendo la lista de validaciones para este form, y procediendo a validar
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                //Validación de
                try
                {
                    if (FormValidators.isGreaterOrEqualThan(txtInicio, txtFin))
                    {
                        if (errorProvider == null)
                        {
                            errorProvider = new List<ControlErrorProvider>();
                        }

                        errorProvider.Add(new ControlErrorProvider("El año de inicio debe ser menor al de final", txtInicio));
                    }
                    if (Convert.ToInt32(txtInicio.Text) < 1900 || Convert.ToInt32(txtInicio.Text) > 3000)
                    {
                        if (errorProvider == null)
                        {
                            errorProvider = new List<ControlErrorProvider>();
                        }

                        errorProvider.Add(new ControlErrorProvider("El año de inicio no se encuentra en un rango aceptable", txtInicio));
                    }
                    if (Convert.ToInt32(txtFin.Text) < 1900 || Convert.ToInt32(txtFin.Text) > 3000)
                    {
                        if (errorProvider == null)
                        {
                            errorProvider = new List<ControlErrorProvider>();
                        }

                        errorProvider.Add(new ControlErrorProvider("El año de fin no se encuentra en un rango aceptable", txtFin));
                    }
                }
                catch { }
                bool isValid = errorProvider == null;
                //Si se pasan todas las validaciones, se procede a guardar la información
                if (isValid)
                {
                    //Si el rango de años tiene conflicto con el de otro plan de la misma carrera, aborta
                    if (!checkPlanRange())
                    {
                        return;
                    }

                    bool success = false;

                    //Si no se ha seleccionado ninguna facultad, se crea un nuevo registro
                    if (selectedPensum == null)
                    {
                        success = savePlan();
                    }
                    //Si se había seleccionado una facultad, se modifica dicho registro
                    else
                    {
                        success = updatePlan(selectedPensum);
                    }

                    if (success)
                    {
                        if (savePensum())
                        {
                            MessageBox.Show("Los cambios fueron guardados exitosamente.", "Pensum guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        loadPensumList();
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MantenimientoPensum frm = new MantenimientoPensum();
            frm.Show();
            this.Hide();
        }

        private void ModuloPensum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
