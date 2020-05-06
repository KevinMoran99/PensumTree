using PensumTree.EntityFramework;
using PensumTree.Graphics;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensumTree
{
    public partial class ModuloOptativa : Form, IAgregarMateria
    {
        //variables de posicion para las materias
        public int[] arrayY = new int[2];

        //contadoras para el número máximo de materias por ciclo
        public int[] arrayCont = new int[2];

        private materia _mat = new materia();
        public NetNode[,] positionMatrix = new NetNode[2, 4];
        //La matriz teóricamente debería ser [2,3], pero por la manera en la que está construido el método de eliminar nodo,
        //se necesita que tenga un espacio más en y

        //Versión de la matriz anterior específica para ser usada en el form VistaPensum
        public GraphNode[,] positionMatrixGraphNode = new GraphNode[2, 4];

        private ModuloPensum parent;

        //Contructor que es llamado en el form VistaPensum
        public ModuloOptativa()
        {
            InitializeComponent();

            arrayY[0] = 14;
            arrayY[1] = 14;

            arrayCont[0] = 0;
            arrayCont[1] = 0;

            btnCiclo1.Visible = false;
            btnCiclo2.Visible = false;
            btnCiclo1.Enabled = false;
            btnCiclo2.Enabled = false;
        }

        //Constructor que es llamado en el form ModuloPensum
        public ModuloOptativa(ModuloPensum parent)
        {
            InitializeComponent();
            this.parent = parent;

            arrayY[0] = 14;
            arrayY[1] = 14;

            arrayCont[0] = 0;
            arrayCont[1] = 0;
        }

        private void buscarMateria()
        {
            AddMateria buscarm = new AddMateria(this, true);
            buscarm.ShowDialog();
        }

        #region IAgregarMateria members
        public void Selected(materia mat)
        {
            _mat = mat;
        }
        #endregion
        private void handlerComun_Click(object sender, EventArgs e)
        {
            int cont = 0;
            int y = 0;
            buscarMateria();

            //Variables de posición lógica de las materias
            int matrixX = Convert.ToInt32(((Button)sender).Name.ToString().Replace("btnCiclo", "")) - 1;
            int matrixY = arrayCont[matrixX];


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

            foreach (NetNode n in parent.pensum.Vertices)
            {
                if (n.Mat == _mat) //Si la materia está repetida
                {
                    MessageBox.Show("Esta materia ya existe en el pensum");
                    return;
                }

                if (_mat.idPrerreq1 != null)
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

            //Validación que verifica que la primera materia agregada a un pensum no tenga prerrequisitos
            if (preOk)
            {
                preOk = !(parent.pensum.VertexCount == 0 && (_mat.materia2 != null || _mat.materia3 != null || _mat.materia4 != null || _mat.materia5 != null));
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
            if (pre1 != null)
            {
                posOk &= !(pre1.X >= matrixX + 8); //Se suman 4 porque este form inicia en el ciclo 9
            }
            if (pre2 != null)
            {
                posOk &= !(pre2.X >= matrixX + 8);
            }
            if (pre3 != null)
            {
                posOk &= !(pre3.X >= matrixX + 8);
            }
            if (pre4 != null)
            {
                posOk &= !(pre4.X >= matrixX + 8);
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

            if (cont < 4)                   //Este if controla que no se sobrepase mas de 3 materias por ciclo
            {
                NetNode nodo = new NetNode(parent, _mat, matrixX, matrixY);
                nodo.Left = 15;
                nodo.Top = y;
                y += 115;
                cont++;
                Panel padre = (Panel)((Button)sender).Parent;
                padre.Controls.Add(nodo);
                ((Button)sender).Location = new Point(84, y);

                //Añadiendo materia al grafo
                parent.pensum.AddVertex(nodo);

                //Añadiendo materia a matriz
                positionMatrix[matrixX, matrixY] = nodo;

                //Convirtiendo relaciones de prerrequisitos en aristas del grafo
                if (pre1 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre1, nodo);
                    parent.pensum.AddEdge(edge);
                }
                if (pre2 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre2, nodo);
                    parent.pensum.AddEdge(edge);
                }
                if (pre3 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre3, nodo);
                    parent.pensum.AddEdge(edge);
                }
                if (pre4 != null)
                {
                    Edge<NetNode> edge = new Edge<NetNode>(pre4, nodo);
                    parent.pensum.AddEdge(edge);
                }

                //Actualizando correlativos
                parent.actualizarCorr();

                if (cont >= 3)
                {
                    ((Button)sender).Visible = false;
                }
            }
            else
            {
                ((Button)sender).Visible = false;
            }
        }

        private void ModuloOptativa_Load(object sender, EventArgs e)
        {
            //pensum = new BidirectionalGraph<NetNode, Edge<NetNode>>();

            

        }
    }
    
}
