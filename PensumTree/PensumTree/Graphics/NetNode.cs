using System;
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
    public partial class NetNode : UserControl
    {
        
        pensum matInscrita;
        ModuloPensum parent;

        private materia mat;
        private int corr;
        private int x;
        private int y;

        public materia Mat { get => mat; set => mat = value; }
        public int Corr { get => corr; set => corr = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public NetNode()
        {
            InitializeComponent();
        }

        //Constructor a usar cuando se esté agregando una nueva materia al pensum
        public NetNode(ModuloPensum parent, materia materia, int X, int Y)
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

            if(mat.materia2 == null) //Si la materia no tiene prerrequisitos
            {
                lblPrerreq.Text = "Bachillerato";
            }

            if (Mat.nombre.Length <= 23)
            {
                lblNombre.Font = new Font("Sans Serif", 14);
            }
            if (Mat.nombre.Length > 23 && Mat.nombre.Length <=50)
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
            }
            if (!materia.segundoCiclo)
            {
                this.Controls.Remove(pcbCiclo2);
                pcbLab.Location = new Point(pcbLab.Location.X - 26, pcbLab.Location.Y);
            }
            if (!materia.lab)
            {
                this.Controls.Remove(pcbLab);
            }
        }

        private void NetNode_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White)
            {
                this.BackColor = Color.Khaki;
            }
            else
            {
                this.BackColor = Color.White;
            }

            //MessageBox.Show("[" + X + "," + Y + "]");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            /*try
            {
                parent.current = parent.pensum.InEdge(this, 0).Source;
            }
            catch
            {
                parent.current = null;
            }*/
            DialogResult dialogResult = MessageBox.Show("¿Desea eliminar esta materia del pensum? Si lo hace, todas las materias que dependan de ella también serán eliminadas.", "Eliminar materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {

                List<NetNode> nodesToDelete = new List<NetNode>();

                deleteNodeAndChildren(this, ref nodesToDelete);

                //Eliminando la materia y todas las materias que dependían de ella
                foreach (NetNode node in nodesToDelete)
                {
                    //Si la materia no es electiva
                    if (!node.mat.electiva)
                    {

                        //Obteniendo el nombre del panel padre del nodo actual
                        Panel parentPanel = (Panel)(parent.Controls.Find("panelCiclo" + (node.X + 1), true)[0]);

                        //Reubicando los controles que estaban bajo el nodo que será eliminado
                        foreach (Control c in parentPanel.Controls)
                        {
                            if (c.Location.Y > node.Location.Y)
                            {
                                c.Location = new Point(c.Location.X, c.Location.Y - 115);
                            }

                        }

                        //Reubicando la posición lógica de las materias en la matriz posición
                        for (int y = node.y; y < 7; y++)
                        {
                            try
                            {
                                parent.positionMatrix[node.x, y] = parent.positionMatrix[node.x, y + 1];
                                parent.positionMatrix[node.x, y].Y = y;
                            }
                            catch (Exception ex) { if (true) { } }
                        }

                        //Disminuyendo las variables helper del método que agrega materias
                        parent.arrayCont[node.X]--;
                        parent.arrayY[node.X] -= 115;
                        //Haciendo visible al botón del panel en caso de que sea invisible
                        ((Button)(parentPanel.Controls.Find("btnCiclo" + (node.x + 1), true)[0])).Visible = true;

                        //Removiendo la materia del form y del grafo
                        parentPanel.Controls.Remove(node);
                        parent.pensum.RemoveVertex(node);
                    }
                    //Si la materia es optativa
                    else
                    {
                        //Obteniendo el nombre del panel padre del nodo actual
                        Panel parentPanel = (Panel)(parent.ventanaOptativas.Controls.Find("panelCiclo" + (node.X + 1), true)[0]);

                        //Reubicando los controles que estaban bajo el nodo que será eliminado
                        foreach (Control c in parentPanel.Controls)
                        {
                            if (c.Location.Y > node.Location.Y)
                            {
                                c.Location = new Point(c.Location.X, c.Location.Y - 115);
                            }

                        }

                        //Reubicando la posición lógica de las materias en la matriz posición
                        for (int y = node.y; y < 5; y++)
                        {
                            try
                            {
                                parent.ventanaOptativas.positionMatrix[node.x, y] = parent.ventanaOptativas.positionMatrix[node.x, y + 1];
                                parent.ventanaOptativas.positionMatrix[node.x, y].Y = y;
                            }
                            catch (Exception ex) { if (true) { } }
                        }

                        //Disminuyendo las variables helper del método que agrega materias
                        parent.ventanaOptativas.arrayCont[node.X]--;
                        parent.ventanaOptativas.arrayY[node.X] -= 115;
                        //Haciendo visible al botón del panel en caso de que sea invisible
                        ((Button)(parentPanel.Controls.Find("btnCiclo" + (node.x + 1), true)[0])).Visible = true;

                        //Removiendo la materia del form y del grafo
                        parentPanel.Controls.Remove(node);
                        parent.pensum.RemoveVertex(node);
                    }

                }

                //Actualizando los correlativos de todas las materias
                parent.actualizarCorr();
            }
        }

        private void deleteNodeAndChildren(NetNode node, ref List<NetNode> nodesToDelete)
        {
            foreach (var ed in parent.pensum.OutEdges(node))
            {
                deleteNodeAndChildren(ed.Target, ref nodesToDelete);
            }

            if(!nodesToDelete.Contains(node))
            {
                nodesToDelete.Add(node);
            }
        }

        private void NetNode_DoubleClick(object sender, EventArgs e)
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
            paintNodeAndParents(this, color);
        }

        private void paintNodeAndParents(NetNode node, Color color)
        {
            node.BackColor = color;

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
