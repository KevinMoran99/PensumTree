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
        materia mat;
        pensum matInscrita;
        MantenimientoPensum2 parent;

        public int corr;
        int X;
        int Y;

        public NetNode()
        {
            InitializeComponent();
        }

        //Constructor a usar cuando se esté agregando una nueva materia al pensum
        public NetNode(MantenimientoPensum2 parent, materia materia)
        {
            InitializeComponent();

            mat = materia;
            this.parent = parent;

            //TODO: Hacer código para determinar el correlativo y setearselo a lblCorr

            lblCodigo.Text = mat.codigo;
            lblNombre.Text = mat.nombre;
            lblUv.Text = mat.uv.ToString() + " UV";

            if (mat.nombre.Length <= 25)
            {
                lblNombre.Font = new Font("Sans Serif", 14);
            }
            if (mat.nombre.Length > 25 && mat.nombre.Length <=50)
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
                pcbCiclo2.Location = new Point(pcbCiclo2.Location.X - 36, pcbCiclo2.Location.Y);
                pcbLab.Location = new Point(pcbLab.Location.X - 36, pcbLab.Location.Y);
            }
            if (!materia.segundoCiclo)
            {
                this.Controls.Remove(pcbCiclo2);
                pcbLab.Location = new Point(pcbLab.Location.X - 36, pcbLab.Location.Y);
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                parent.current = parent.pensum.InEdge(this, 0).Source;
            }
            catch
            {
                parent.current = null;
            }

            List<NetNode> nodesToDelete = new List<NetNode>();

            deleteNodeAndChildren(this, ref nodesToDelete);

            foreach (NetNode node in nodesToDelete)
            {
                parent.Controls.Remove(node);
                parent.pensum.RemoveVertex(node);
            }
        }

        private void deleteNodeAndChildren(NetNode node, ref List<NetNode> nodesToDelete)
        {
            foreach (var ed in parent.pensum.OutEdges(node))
            {
                deleteNodeAndChildren(ed.Target, ref nodesToDelete);
            }
            nodesToDelete.Add(node);
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
