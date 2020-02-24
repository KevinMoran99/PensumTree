using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensumTree.Models
{
    class ControlErrorProvider
    {
        private string errorMessage= null;
        private Control control = null;

        public ControlErrorProvider(string errorMessage, Control control)
        {
            this.errorMessage = errorMessage;
            this.control = control;
        }

        public string ErrorMessage { get => errorMessage;  }
        public Control ControlName { get => control;  }
    }
}
