﻿using System;
using System.Collections;
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
using System.IO;

namespace PensumTree
{
    public partial class VistaPensum : Form
    {

        private static PlanController planController = new PlanController();
        private static PensumController pensumController = new PensumController();
        private List<pensum> pMaterias = new List<pensum>();
        public ModuloOptativa ventanaOptativas;

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
        bool isLoggedAdmin;
        public GraphNode[,] positionMatrix = new GraphNode[10, 7]; //Matriz que organiza cada materia según su posición lógica en la malla

        public GraphNode current = null;
        private int nodeX = 12;
        private int nodeY = 15;

        private GraphNode electiva1, electiva2;

        public VistaPensum()
        {
            InitializeComponent();
        }
        public VistaPensum(plan currentPensum, bool isLogged)
        {
            InitializeComponent();

            selectedPensum = currentPensum;
            isLoggedAdmin = isLogged;

            ventanaOptativas = new ModuloOptativa();
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
            foreach (pensum mat in pMaterias)
            {
                int cont, y;
                bool isSelective = mat.materia.electiva;



                if (!isSelective)
                {
                    y = arrayY[mat.ciclo - 1];
                    arrayY[mat.ciclo - 1] += 115;
                    cont = arrayCont[mat.ciclo - 1];
                    arrayCont[mat.ciclo - 1]++;
                }
                else
                {
                    y = ventanaOptativas.arrayY[mat.ciclo - 9];
                    ventanaOptativas.arrayY[mat.ciclo - 9] += 115;
                    cont = ventanaOptativas.arrayCont[mat.ciclo - 9];
                    ventanaOptativas.arrayCont[mat.ciclo - 9]++;
                }

                Panel padre;

                if (!isSelective)
                {
                    padre = (Panel)(this.Controls.Find("panelCiclo" + (mat.ciclo), true)[0]);
                }
                else
                {
                    padre = (Panel)(this.ventanaOptativas.Controls.Find("panelCiclo" + (mat.ciclo - 8), true)[0]);
                }


                GraphNode nodo;
                if (!isSelective)
                {
                    nodo = new GraphNode(this, mat.materia, (int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2);
                }
                else
                {
                    nodo = new GraphNode(this, mat.materia, (int)mat.ciclo - 9, ventanaOptativas.arrayCont[mat.ciclo - 9] - 1);
                }
                nodo.Left = 15;
                nodo.Top = y;
                y += 115;
                cont++;
                padre.Controls.Add(nodo);


                //Añadiendo materia al grafo
                pensum.AddVertex(nodo);

                //Añadiendo materia a matriz
                if (!isSelective)
                {
                    positionMatrix[(int)mat.ciclo - 1, arrayCont[mat.ciclo - 1] - 2] = nodo;
                }
                else
                {
                    ventanaOptativas.positionMatrixGraphNode[(int)mat.ciclo - 9, ventanaOptativas.arrayCont[mat.ciclo - 9] - 1] = nodo;
                }

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

                    if (preFound1 && preFound2 && preFound3 && preFound4)
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

                //Agregando nodos simbólicos de técnicas electivas
                if (isSelective)
                {
                    padre = (Panel)(this.Controls.Find("panelCiclo" + (mat.ciclo), true)[0]);
                    if (mat.ciclo == 9)
                    {
                        if (!padre.Controls.Contains(electiva1))
                        {
                            electiva1 = new GraphNode(this, "Técnica Electiva 1", 8, arrayCont[8] - 2);
                            electiva1.Left = 15;
                            electiva1.Top = arrayY[8];
                            padre.Controls.Add(electiva1);
                        }
                    }
                    else
                    {
                        if (!padre.Controls.Contains(electiva2))
                        {
                            electiva2 = new GraphNode(this, "Técnica Electiva 2", 9, arrayCont[9] - 2);
                            electiva2.Left = 15;
                            electiva2.Top = arrayY[9];
                            padre.Controls.Add(electiva2);
                        }
                    }
                }

            }

            //Actualizando correlativos
            actualizarCorr();
        }

        private int getNodeLevel(GraphNode node)
        {
            int level = 1;
            foreach (Edge<GraphNode> edge in pensum.InEdges(node))
            {
                level = getNodeLevel(edge.Source);
                level++;
            }
            return level;
        }

        //Ésta variable determina hasta qué valor lógico en X se han renderizado nodos.
        //Los siguientes nodos a renderizar deberan hacerlo en valores de X superiores a este máximo
        //Los valores lógicos de esta variable se van incrementando de dos en dos
        private int currentMaxX = -2;

        private int addNodeToGraphView(GraphNode node, int currentY)
        {
            if (!panelGrafo.Contains(node.Sub))
            {
                //Agregando el nodo al panel
                panelGrafo.Controls.Add(node.Sub);

                //Determinando la posición lógica del nodo en función de la posición de los nodos que ya fueron renderizados
                node.Sub.X = currentMaxX + 2;
                node.Sub.Y = currentY + 1;

                //Helper que nos ayuda a determinar si el nodo actual tiene más hijos pendientes de renderizar
                int childrenToDisplayCount = 0;

                //Estas variables servirán para recalcular el valor lógico de X para que quede centrado en relación a sus hijos
                int leftLimit = -2;
                int rightLimit = 0;

                //Iterando entre los hijos del nodo
                foreach (Edge<GraphNode> child in pensum.OutEdges(node))
                {
                    //Las operaciones se llevarán a cabo solamente si el nodo en cuestión no ha sido renderizado aún
                    if (!panelGrafo.Contains(child.Target.Sub))
                    {
                        //Agregando a los hijos del nodo recursivamente. La función nos devuelve la posición X del hijo.
                        int childX = addNodeToGraphView(child.Target, currentY + 1);
                        childrenToDisplayCount++;

                        //Almacenando la posición X del primer y último hijo del nodo actual para luego recalcular la posición X de éste
                        if(leftLimit == -2)
                        {
                            leftLimit = childX;
                        }
                        rightLimit = childX;
                    }
                }
                //Si el nodo actual no tenía hijos pendientes de renderizar, la variable currentMaxX debe incrementar
                if (childrenToDisplayCount == 0)
                {
                    currentMaxX++;
                    currentMaxX++;
                }
                else
                {
                    //Si el nodo actual tenía hijos pendientes de renderizar (los cuales en este punto ya fueron renderizados),
                    //recalculamos su posición lógica en X para que esté centrada en relación a sus hijos
                    node.Sub.X = (leftLimit + rightLimit) / 2;
                }
            }

            //Dándole al nodo su posición real en base a su posición lógica
            node.Sub.Location = new Point(50 + 125 * node.Sub.X, 30 + 150 * node.Sub.Y);

            //Devolviendo la posición X del nodo
            return node.Sub.X;
        }

        private void generateGraphVisualization()
        {
            int maxLevel = 1;

            //Calculando cantidad de niveles del grafo
            foreach(GraphNode node in pensum.Vertices)
            {
                if(pensum.OutDegree(node) == 0)
                {
                    int level = getNodeLevel(node);
                    
                    if (level > maxLevel)
                    {
                        maxLevel = level;
                    }
                }
            }

            //Renderizando un identificador lateral para cada label
            int levelY = 10;
            for(int i = 1; i <= maxLevel; i++)
            {
                LevelLabel lbl = new LevelLabel(i);
                lbl.Location = new Point(10, levelY);
                panelGrafo.Controls.Add(lbl);

                levelY += 151;
            }

            //Renderizando primero los vertices que no tienen hijos
            /*foreach (GraphNode node in pensum.Vertices)
            {
                if (pensum.OutDegree(node) == 0 && pensum.InDegree(node) == 0)
                {
                    panelGrafo.Controls.Add(node.Sub);
                    node.Sub.X = currentMaxX + 2;
                    node.Sub.Y = 0;
                    currentMaxX++;
                    currentMaxX++;
                    node.Sub.Location = new Point(50 + 125 * node.Sub.X, 30 + 150 * node.Sub.Y);
                }
            }*/

            //Renderizando los vértices del grafo
            foreach (GraphNode node in pensum.Vertices)
            {
                addNodeToGraphView(node, -1);
            }

            //Llamando a refresh para renderizar las aristas del grafo
            panelGrafo.Refresh();
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
                generateGraphVisualization();
            }
        }

        public void actualizarCorr()
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

            //Recorriendo matriz posición de materias optativas
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    //Si la posición actual contiene una materia
                    if (ventanaOptativas.positionMatrixGraphNode[x, y] != null)
                    {
                        //Si el correlativo de la materia ha cambiado
                        if (ventanaOptativas.positionMatrixGraphNode[x, y].Corr != corr)
                        {
                            //Obteniendo correlativos de los prerrequisitos de la materia
                            string prerreqCorrs = "";
                            foreach (Edge<GraphNode> edge in pensum.InEdges(ventanaOptativas.positionMatrixGraphNode[x, y]))
                            {
                                prerreqCorrs += edge.Source.Corr + ",";
                            }
                            if (!prerreqCorrs.Equals(""))
                            {
                                prerreqCorrs = prerreqCorrs.Substring(0, prerreqCorrs.Length - 1); //Eliminando coma del final
                            }

                            ventanaOptativas.positionMatrixGraphNode[x, y].setCorr(corr, prerreqCorrs); //Actualizando correlativos del nodo
                        }


                        corr++;
                    }
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (isLoggedAdmin)
            {
            MantenimientoPensum frm = new MantenimientoPensum(true);
            frm.Show();
            this.Hide();
            }
            else
            {
                ListadoPensums frm = new ListadoPensums();
                frm.Show();
                this.Hide();
            }
        }

        private void VistaPensum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Tabla hash que servirá de helper para mostrar los tooltips de los círculos de salto
        //Key: Rectangle que representa la posición que debe tener el mouse para que se muestre el tooltip (osea, la ubicación del círculo)
        //Value: El nombre de la materia que representa el círculo, la cual será mostrada en el tooltip
        Hashtable tooltips = new Hashtable();

        private void panelGrafo_Paint(object sender, PaintEventArgs e)
        {
            //Vaciando la tabla de tooltips
            tooltips.Clear();

            //Lista que contiene todos los "circulos de salto" que ya han sido renderizados (esto para evitar que dos circulos se rendericen uno encima de otro)
            //(De hecho no los contiene a todos, solamente contiene a los que se renderizan sobre los vértices, porque con los que se renderizan bajo ellos no hay problemas de colisión)
            List<Rectangle> occupiedSpaces = new List<Rectangle>();

            //Color y anchura de las aristas
            Pen pen = new Pen(Color.Gray, 1.5f);

            //Recorriendo todos los vértices
            foreach (GraphNode node in pensum.Vertices)
            {
                //Coordenadas en las que inician la aristas para este vértice
                float x1 = node.Sub.Location.X + 105;
                float y1 = node.Sub.Location.Y + 107;

                //Coordenada x que tendrá la arista si esta finaliza un "circulo de salto"
                float x1Far = x1 + 20;

                //Recorriendo los hijos del vértice
                foreach (Edge<GraphNode> child in pensum.OutEdges(node))
                {
                    //Coordenadas en las que termina la arista para este hijo
                    float x2 = child.Target.Sub.Location.X + 105;
                    float y2 = child.Target.Sub.Location.Y;

                    //Coordenada x que tendrá la arista si esta inicia un "circulo de salto"
                    float x2Far = x2 - 20;

                    //Determinando la longitud de la arista
                    double module = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                    if (module < 1000)
                    {
                        //Si la arista es corta, simplemente se dibuja como una línea recta
                        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                    }
                    else
                    {
                        //Si la arista es larga, se dibujará usando "círculos de salto"

                        //Dibujando el círculo de salto que sale del padre
                        Rectangle rect = new Rectangle((int)x1Far - 12, (int)y1 + 10, 25, 25);

                        //Añadiendo este círculo a la tabla de tooltips
                        tooltips.Add(rect, child.Target.Mat.nombre);

                        e.Graphics.DrawLine(pen, x1Far, y1, x1Far, y1 + 10);
                        e.Graphics.FillEllipse(Brushes.ForestGreen, rect);

                        float x1String;
                        //Este if sirve para centrar el contenido del círculo en función de si tiene uno o dos dígitos
                        if (child.Target.Corr.ToString().Length == 1)
                        {
                            x1String = x1Far - 7;
                        }
                        else
                        {
                            x1String = x1Far - 12;
                        }
                        e.Graphics.DrawString(child.Target.Corr.ToString(), lblImLazy.Font, Brushes.White, x1String, y1 + 13);
                        x1Far += 30;


                        //Dibujando el círculo de salto que entra al hijo

                        //Comparando con los círculos que ya han sido dibujados, para ver si el círculo que se dibujará
                        //no colisiona con uno que ya esté
                        foreach (Rectangle currRect in occupiedSpaces)
                        {
                            //En caso de colisión, el nuevo círculo se colocará a la izquierda de el que ya estaba
                            if (currRect.Contains(new Point((int)x2Far - 12, (int)y2 - 35)))
                            {
                                x2Far -= 30;
                            }
                        }

                        //Añadiendo el nuevo círculo a la lista de círculos dibujados
                        rect = new Rectangle((int)x2Far - 12, (int)y2 - 35, 25, 25);
                        occupiedSpaces.Add(rect);

                        //Añadiendo este círculo a la tabla de tooltips
                        tooltips.Add(rect, node.Mat.nombre);

                        //Finalmente, se dibuja el círculo
                        e.Graphics.DrawLine(pen, x2Far, y2 - 10, x2Far, y2);
                        e.Graphics.FillEllipse(Brushes.YellowGreen, rect);

                        float x2String;
                        if (node.Corr.ToString().Length == 1)
                        {
                            x2String = x2Far - 7;
                        }
                        else
                        {
                            x2String = x2Far - 12;
                        }
                        e.Graphics.DrawString(node.Corr.ToString(), lblImLazy.Font, Brushes.White, x2String, y2 - 33);

                    }
                }
            }

        }

        private void panelGrafo_Click(object sender, EventArgs e)
        {
            
        }

        //Tooltip para los círculos de salto
        ToolTip tt = new ToolTip();
        private void panelGrafo_MouseMove(object sender, MouseEventArgs e)
        {

            ICollection rectangles = tooltips.Keys;
            //Por defecto, el tooltip se desactiva
            tt.Active = false;

            //Iterando entre las posiciones de todos los círculos de salto
            foreach (Rectangle rect in rectangles)
            {
                //Si el puntero del mouse se encuentra sobre uno de los círculos de salto, debe mostrarse un tooltip con el nombre de la materia que ese círculo representa
                if (e.Location.X > rect.X && e.Location.X < rect.X + rect.Width && e.Location.Y > rect.Y  && e.Location.Y < rect.Y + rect.Height)
                {
                    tt.Active = true;
                    tt.IsBalloon = true;
                    tt.Show(tooltips[rect].ToString(), panelGrafo, e.Location, 1000);
                }
            }

        }

        private void panelGrafo_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panelGrafo_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
          
            try
            {
                GArchivotxt.InitialDirectory = "C:\\";
                if  (GArchivotxt.ShowDialog() == DialogResult.OK)
                {                   
                    string cadena = GArchivotxt.FileName;
                    StreamWriter writer = new StreamWriter(cadena);

                    writer.WriteLine("Pensum Id: " + selectedPensum.id.ToString());
                    writer.WriteLine("Id de Materias:");

                    foreach (GraphNode node in pensum.Vertices)
                    {
                        if (node.BackColor == Color.Khaki)
                        {
                            writer.WriteLine(node.Mat.id.ToString());
                        }
                    }
                    writer.Close();
                    MessageBox.Show("Progreso guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                              
            }
            catch 
            {
                MessageBox.Show("Error al guardar progreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> materias = new List<long>();
                Archivotxt.InitialDirectory = "C:\\";
                Archivotxt.Filter = "txt files (*.txt)|*.txt";
                if (Archivotxt.ShowDialog() == DialogResult.OK)
                {
                    string cadena = Archivotxt.FileName;
                    StreamReader reader = new StreamReader(cadena);
                    string all = reader.ReadToEnd();
                    string[] lineas = all.Split('\n');
                    if (VerificarFormato(all))
                    {
                        int id = int.Parse(all.Substring(11, 1));
                        if (id == selectedPensum.id)
                        {
                            for (int i = 2; i < lineas.Count() - 1; i++)
                            {
                                //MessageBox.Show(lineas[i]);
                                long mat = long.Parse(lineas[i]);
                                materias.Add(mat);

                                foreach (GraphNode node in pensum.Vertices)
                                {
                                    if (materias.Contains(node.Mat.id))
                                    {
                                        node.BackColor = Color.Khaki;
                                        node.Sub.BackColor = Color.Khaki;
                                    }
                                    else
                                    {
                                        node.BackColor = Color.White;
                                        node.Sub.BackColor = Color.White;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El archivo seleccionado no corresponde" +
                                "\na este pensum", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El formato del txt seleccionado no es el correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch
            {
                MessageBox.Show("El formato del txt seleccionado no es el correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool VerificarFormato(string texto)
        {
            if (texto.StartsWith("Pensum Id: ") && texto.Contains("Id de Materias:"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bntOptativas_Click(object sender, EventArgs e)
        {
            ventanaOptativas.ShowDialog();
        }
    }
}
