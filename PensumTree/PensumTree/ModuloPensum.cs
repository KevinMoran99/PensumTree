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
    public partial class ModuloPensum : Form
    {
        private int y = 66;
        private int cont = 0;
        public ModuloPensum()
        {
            InitializeComponent();
        }

        private void handlerComun_Click(object sender, EventArgs e) 
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cont < 7)
            {
                Button temp = new Button();

                temp.Height = 107;
                temp.Width = 210;
                temp.Location = new Point(10, y);
                y += 115;
                temp.Name = "btnBoton" + cont.ToString();
                temp.Text = "Materia" + cont.ToString(); 
                cont++;
                temp.Click += new EventHandler(handlerComun_Click);
                panelMaterias.Controls.Add(temp);

                button1.Location = new Point(84, y);
            }
            else
            {

            }
            
        }
    }
}
