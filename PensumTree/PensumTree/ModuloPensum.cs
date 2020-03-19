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

namespace PensumTree
{
    public partial class ModuloPensum : Form, IAgregarMateria
    {
        //variables de posicion para las materias
        private int y1 = 14;
        private int y2 = 14;
        private int y3 = 14;
        private int y4 = 14;
        private int y5 = 14;
        private int y6 = 14;
        private int y7 = 14;
        private int y8 = 14;
        private int y9 = 14;
        private int y10 = 14;
        //contadoras para el número máximo de materias por ciclo
        private int cont1 = 1;
        private int cont2 = 1;
        private int cont3 = 1;
        private int cont4 = 1;
        private int cont5 = 1;
        private int cont6 = 1;
        private int cont7 = 1;
        private int cont8 = 1;
        private int cont9 = 1;
        private int cont10 = 1;

        private int num_lbl = 2;     //Esta variable sirve como contadora para los labels de encabezado de ciclo que genera loadElements
        private int num_panel = 2;   //Esta variable sirve como contadora para los panels de ciclo que genera loadElements
        private int num_btn = 2;   //Esta variable sirve como contadora para los botones de ciclo que genera loadElements
        private int lbl_x = 364;     //variable x para la position de los labels
        private int panel_x = 293;   //variable x para la position de los panels
        private int btn_x = 364;     //variable x para la position de los botones

        private materia _mat = new materia();

        public BidirectionalGraph<NetNode, Edge<NetNode>> pensum = new BidirectionalGraph<NetNode, Edge<NetNode>>();

        public NetNode current = null;
        private int nodeX = 12;
        private int nodeY = 15;
        public ModuloPensum()
        {
            InitializeComponent();
            loadElements();             //Esta funcion carga los labels y panels de cada ciclo
        }

        //Este handler se agrega a los botones "+" para poder agregar materias
        //Lo escribi en el codigo ya que estos botones de generan y por lo tanto se tiene que agregar manualmente sus handlers
        private void handlerComun_Click(object sender, EventArgs e)
        {
            int cont = 0;
            int y = 0;
            buscarMateria();
            switch (((Button)sender).Name.ToString())  //Este switch registra a que ciclo se tiene que agregar la materia
            {                                          //Segun el ciclo busca las coordenadas y el número de materias que ya tiene ese ciclo
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

            if (cont < 6)                   //Este if controla que no se sobrepase mas de 5 materias por ciclo
            {
                NetNode nodo = new NetNode(this, _mat);
                nodo.Left = 15;
                nodo.Top = y;
                y += 115;
                cont++;
                Panel padre = (Panel)((Button)sender).Parent;
                padre.Controls.Add(nodo);
                ((Button)sender).Location = new Point(84, y);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cont1 < 6)
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
            }

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
                btemp.Font = button1.Font;
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
    }
}
