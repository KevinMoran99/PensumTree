using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PensumTree.Utils;
using static PensumTree.Utils.FormValidators;

namespace PensumTree.Models
{
    class ToValidate
    {
        private Control control;
        private ControlValidator[] controlValidators;
        private string[] errorMessages;

        public ToValidate(Control control, ControlValidator[] controlValidators, string[] errorMessages)
        {
            this.control = control;
            this.controlValidators = controlValidators;
            this.errorMessages = errorMessages;
        }

        public Control Control { get => control; }
        public string[] ErrorMessages { get => errorMessages; }
        internal ControlValidator[] ControlValidators { get => controlValidators; }
    }
}
