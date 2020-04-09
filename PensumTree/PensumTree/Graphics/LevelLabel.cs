using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensumTree.Graphics
{
    public partial class LevelLabel : UserControl
    {
        public LevelLabel()
        {
            InitializeComponent();
        }

        public LevelLabel(int level)
        {
            InitializeComponent();
            lblLevel.Text = "NIVEL" + level.ToString();
        }
    }
}
