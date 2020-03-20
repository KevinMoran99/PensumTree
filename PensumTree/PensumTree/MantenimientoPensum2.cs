using PensumTree.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickGraph;
using PensumTree.EntityFramework;

namespace PensumTree
{
    public partial class MantenimientoPensum2 : Form
    {
        public BidirectionalGraph<NetNode, Edge<NetNode>> pensum = new BidirectionalGraph<NetNode, Edge<NetNode>>();

        public NetNode current = null;

        public MantenimientoPensum2()
        {
            InitializeComponent();
        }

        private void MantenimientoPensum2_Click(object sender, EventArgs e)
        {
            /*materia mat = new materia
            {
                nombre = "Calculo Integral",
                uv = 4,
                codigo = "ASR104",
                primerCiclo = true,
                segundoCiclo = true,
                lab = true,
                electiva = false,
                materia2 = new materia { nombre = "Diseño de Redes de Datos" },
                materia3 = new materia { nombre = "Interconexión de Redes de Datos" }
            };

            NetNode node = new NetNode(this, mat);
            NetNode node1 = new NetNode(this, mat);
            NetNode node2 = new NetNode(this, mat);
            NetNode node3 = new NetNode(this, mat);
            NetNode node4 = new NetNode(this, mat);
            Controls.Add(node);
            Controls.Add(node1);
            Controls.Add(node2);
            Controls.Add(node3);
            Controls.Add(node4);

            //node.Left = MousePosition.X;
            //node.Top = MousePosition.Y;
            node.Left = 100;
            node.Top = 5;
            node1.Left = 100;
            node1.Top = 130;
            node2.Left = 100;
            node2.Top = 255;
            node3.Left = 100;
            node3.Top = 380;
            node4.Left = 100;
            node4.Top = 505;

            pensum.AddVertex(node);

            if (current != null) {
                Edge<NetNode> edge = new Edge<NetNode>(current, node);
                pensum.AddEdge(edge);
            }

            current = node;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
