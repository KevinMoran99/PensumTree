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
    public partial class VistaPensum : Form
    {

        private static PlanController planController = new PlanController();
        private static PensumController pensumController = new PensumController();
        private List<pensum> pMaterias = new List<pensum>();

        plan selectedPensum = null;

        //variables de posicion para las materias
        public int[] arrayY = new int[10];

        //contadoras para el número máximo de materias por ciclo
        public int[] arrayCont = new int[10];

        private int num_lbl = 2;     //Esta variable sirve como contadora para los labels de encabezado de ciclo que genera loadElements
        private int num_panel = 2;   //Esta variable sirve como contadora para los panels de ciclo que genera loadElements
        private int num_btn = 2;   //Esta variable sirve como contadora para los botones de ciclo que genera loadElements
        private int lbl_x = 364;     //variable x para la position de los labels
        private int panel_x = 293;   //variable x para la position de los panels
        private int btn_x = 364;     //variable x para la position de los botones

        private materia _mat = new materia();

        public BidirectionalGraph<GraphNode, Edge<GraphNode>> pensum;
        public GraphNode[,] positionMatrix = new GraphNode[10, 7]; //Matriz que organiza cada materia según su posición lógica en la malla

        public GraphNode current = null;
        private int nodeX = 12;
        private int nodeY = 15;
        public VistaPensum()
        {
            InitializeComponent();
        }
        public VistaPensum(plan currentPensum)
        {
            InitializeComponent();

            selectedPensum = currentPensum;
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

        private void generatePensumFromList()
        {
            foreach(pensum mat in pMaterias)
            {
                int cont = arrayCont[mat.ciclo - 1];
                int y = arrayY[mat.ciclo - 1];
                arrayCont[mat.ciclo - 1]++;
                arrayY[mat.ciclo - 1] += 115;


                Panel padre = (Panel)(this.Controls.Find("panelCiclo" + (mat.ciclo), true)[0]);


                
                GraphNode nodo = new GraphNode(this, mat.materia, (int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2);
                nodo.Left = 15;
                nodo.Top = y;
                y += 115;
                cont++;
                padre.Controls.Add(nodo);

                //Añadiendo materia al grafo
                pensum.AddVertex(nodo);

                //Añadiendo materia a matriz
                positionMatrix[(int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2] = nodo;

                bool preFound1 = mat.materia.idPrerreq1 == null;
                bool preFound2 = mat.materia.idPrerreq2 == null;
                bool preFound3 = mat.materia.idPrerreq3 == null;
                bool preFound4 = mat.materia.idPrerreq4 == null;
                GraphNode pre1 = null;
                GraphNode pre2 = null;
                GraphNode pre3 = null;
                GraphNode pre4 = null;

                foreach (GraphNode n in pensum.Vertices)
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
                    Edge<GraphNode> edge = new Edge<GraphNode>(pre1, nodo);
                    pensum.AddEdge(edge);
                }
                if (mat.materia.idPrerreq2 != null)
                {
                    Edge<GraphNode> edge = new Edge<GraphNode>(pre2, nodo);
                    pensum.AddEdge(edge);
                }
                if (mat.materia.idPrerreq3 != null)
                {
                    Edge<GraphNode> edge = new Edge<GraphNode>(pre3, nodo);
                    pensum.AddEdge(edge);
                }
                if (mat.materia.idPrerreq4 != null)
                {
                    Edge<GraphNode> edge = new Edge<GraphNode>(pre4, nodo);
                    pensum.AddEdge(edge);
                }

            }

            //Actualizando correlativos
            actualizarCorr();
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
                temp.Height = 600;
                temp.Location = new Point(panel_x, 37);
                panel_x += 269;
                temp.Name = "panelCiclo" + num_panel.ToString();
                num_panel++;
                panelCiclos.Controls.Add(temp);
            }
        }


        private void VistaPensum_Load(object sender, EventArgs e)
        {
            loadElements();             //Esta funcion carga los labels y panels de cada ciclo
            

            pensum = new BidirectionalGraph<GraphNode, Edge<GraphNode>>();

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
                lblTitle.Text = selectedPensum.carrera.nombre + " [Plan " + selectedPensum.inicio + " - " + selectedPensum.fin + "]";

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
                            foreach (Edge<GraphNode> edge in pensum.InEdges(positionMatrix[x, y]))
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MantenimientoPensum frm = new MantenimientoPensum();
            frm.Show();
            this.Hide();
        }

        private void VistaPensum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
