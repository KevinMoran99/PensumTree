﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PensumTree.EntityFramework;

namespace PensumTree.Graphics
{
    public partial class GraphNode : UserControl
    {
        
        pensum matInscrita;
        VistaPensum parent;

        private materia mat;
        private int corr;
        private int x;
        private int y;
        private GraphNode main = null;
        private GraphNode sub = null;

        public materia Mat { get => mat; set => mat = value; }
        public int Corr { get => corr; set => corr = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public GraphNode Sub { get => sub; set => sub = value; }
        public GraphNode Main { get => main; set => main = value; }

        public GraphNode()
        {
            InitializeComponent();
        }

        private void constructor(VistaPensum parent, materia materia, int X, int Y)
        {
            InitializeComponent();

            Mat = materia;
            this.parent = parent;
            this.X = X;
            this.Y = Y;

            //TODO: Hacer código para determinar el correlativo y setearselo a lblCorr

            lblCodigo.Text = Mat.codigo;
            lblNombre.Text = Mat.nombre;
            lblUv.Text = Mat.uv.ToString() + " UV";

            if (mat.materia2 == null) //Si la materia no tiene prerrequisitos
            {
                lblPrerreq.Text = "Bachillerato";
            }

            if (Mat.nombre.Length <= 23)
            {
                lblNombre.Font = new Font("Sans Serif", 14);
            }
            if (Mat.nombre.Length > 23 && Mat.nombre.Length <= 50)
            {
                lblNombre.Font = new Font("Sans Serif", 11);
            }

            //TOOD: Hacer código para setear los correlativos de los prerrequisitos a lblPrerreq

            string prerr = "";

            string prerrTooltip = "Prerrequisitos:";

            if (materia.materia2 != null)
            {
                prerrTooltip += "\n - " + materia.materia2.nombre;
            }
            if (materia.materia3 != null)
            {
                prerrTooltip += "\n - " + materia.materia3.nombre;
            }
            if (materia.materia4 != null)
            {
                prerrTooltip += "\n - " + materia.materia4.nombre;
            }
            if (materia.materia5 != null)
            {
                prerrTooltip += "\n - " + materia.materia5.nombre;
            }

            if (prerrTooltip.Equals("Prerrequisitos:"))
            {
                prerrTooltip = "Prerrequisitos: \n - Bachillerato";
            }

            if (!materia.electiva)
            {
                toolTip1.SetToolTip(lblPrerreq, prerrTooltip);
            }


            if (!materia.primerCiclo)
            {
                this.Controls.Remove(pcbCiclo1);
                pcbCiclo2.Location = new Point(pcbCiclo2.Location.X - 26, pcbCiclo2.Location.Y);
                pcbLab.Location = new Point(pcbLab.Location.X - 26, pcbLab.Location.Y);
                pcbSelective.Location = new Point(pcbSelective.Location.X - 26, pcbSelective.Location.Y);
            }
            if (!materia.segundoCiclo)
            {
                this.Controls.Remove(pcbCiclo2);
                pcbLab.Location = new Point(pcbLab.Location.X - 26, pcbLab.Location.Y);
                pcbSelective.Location = new Point(pcbSelective.Location.X - 26, pcbSelective.Location.Y);
            }
            if (!materia.lab)
            {
                this.Controls.Remove(pcbLab);
                pcbSelective.Location = new Point(pcbSelective.Location.X - 26, pcbSelective.Location.Y);
            }
            if (!materia.electiva)
            {
                this.Controls.Remove(pcbSelective);
            }
        }


        //Al crear un nodo, internamente se crean dos nodos idénticos: El main, que será el que será agregado al TAD grafo
        //y que será mostrado en la vista de malla, y el sub, que será mostrado en la vista de grafo pero no estará directamente
        //enlazado al TAD grafo. En su lugar, cada main y sub estarán estrechamente relacionados para que ambos funcionen como si de
        //uno solo se tratase.

        //Constructor para nodo main
        public GraphNode(VistaPensum parent, materia materia, int X, int Y)
        {
            constructor(parent, materia, X, Y);

            Sub = new GraphNode(parent, materia, -2, -1, this);
            
        }

        //Constructor para nodo sub
        public GraphNode(VistaPensum parent, materia materia, int X, int Y, GraphNode mainNode)
        {
            constructor(parent, materia, X, Y);

            Main = mainNode;

        }

        //Constructor para nodos sin objeto materia
        public GraphNode(VistaPensum parent, string materia, int X, int Y)
        {
            InitializeComponent();

            this.parent = parent;
            lblNombre.Text = materia;
            lblPrerreq.Text = "*";
            lblCodigo.Text = "*";
            lblUv.Text = "*";
            lblCorr.Text = "*";
            this.x = X;
            this.y = Y;
            sub = new GraphNode();
            Controls.Remove(pcbCiclo1);
            Controls.Remove(pcbCiclo2);
            Controls.Remove(pcbLab);
            pcbSelective.Location = new Point(4, 67);
            lblNombre.Font = new Font("Sans Serif", 14);
        }

        private void TreeNode_Click(object sender, EventArgs e)
        {
            //Si no es optativa
            if (lblCodigo.Text != "*")
            {

                if (this.BackColor == Color.White)
                {
                    this.BackColor = Color.Khaki;
                    if (sub != null)
                    {
                        this.sub.BackColor = Color.Khaki;
                    }
                    else
                    {
                        this.main.BackColor = Color.Khaki;
                    }
                }
                else
                {
                    this.BackColor = Color.White;
                    if (sub != null)
                    {
                        this.sub.BackColor = Color.White;
                    }
                    else
                    {
                        this.main.BackColor = Color.White;
                    }
                }
            }

            //MessageBox.Show("[" + X + "," + Y + "]");
        }

        private void TreeNode_DoubleClick(object sender, EventArgs e)
        {
            //Si no es optativa
            if (lblCodigo.Text != "*")
            {
                Color color = Color.White;
                if (this.BackColor == Color.White)
                {
                    color = Color.Khaki;
                }
                else
                {
                    color = Color.White;
                }
                if (sub != null)
                {
                    paintNodeAndParents(this, color);
                }
                else
                {
                    paintNodeAndParents(main, color);
                }
            }
        }

        private void paintNodeAndParents(GraphNode node, Color color)
        {
            node.BackColor = color;
            if (node.sub != null)
            {
                node.sub.BackColor = color;
            }
            else
            {
                node.main.BackColor = color;
            }

            foreach (var ed in parent.pensum.InEdges(node))
            {
                paintNodeAndParents(ed.Source, color);
            }
        }

        public void setCorr(int corr, string prerreqCors)
        {
            this.corr = corr;
            lblCorr.Text = corr.ToString();
            if (!prerreqCors.Equals(""))
            {
                lblPrerreq.Text = prerreqCors;
            }
            //Si es main
            if(sub != null)
            {
                //Duplicando correlativos a sub
                sub.setCorr(corr, prerreqCors);
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void pcbCiclo1_Click(object sender, EventArgs e)
        {

        }

        private void pcbCiclo2_Click(object sender, EventArgs e)
        {

        }

        private void pcbLab_Click(object sender, EventArgs e)
        {

        }
    }
}
