using PensumTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensumTree.Utils
{
    static class FormValidators
    {
        public delegate bool ControlValidator (Control value);

        /// <summary>
        ///  Return an error message if any control is invalid
        /// </summary>
        /// <param name="validators"></param>
        /// <returns>string</returns>
        public static ControlErrorProvider validForm(ToValidate[] validators)
        {
            string errorMessage = null;
            Control control = null;
            foreach (ToValidate validator in validators)
            {
                errorMessage = FormValidators.validControl(validator.Control, validator.ControlValidators, validator.ErrorMessages);
                control = validator.Control;
                if (!(errorMessage == null)) break;
            }
            return errorMessage == null ? null : new ControlErrorProvider(errorMessage, control);
        }

        public static List<ControlErrorProvider> validFormTest(ToValidate[] validators)
        {
            List<ControlErrorProvider> errors = new List<ControlErrorProvider>();

            string errorMessage = null;
            Control control = null;
            bool hasErrors = false;
            foreach (ToValidate validator in validators)
            {
                errorMessage = FormValidators.validControl(validator.Control, validator.ControlValidators, validator.ErrorMessages);
                if (errorMessage != null) hasErrors = true;
                control = validator.Control;
                errors.Add(new ControlErrorProvider(errorMessage, control));
            }
            return !hasErrors ? null : errors;
        }

        public static string validControl(Control control, ControlValidator[] validators, string[] errorMessages )
        {
            if(validators.Length == errorMessages.Length)
            {
                for (int i = 0; i < validators.Length; i++)
                {
                    bool isValid = validators[i](control);
                    if (!isValid) return errorMessages[i];
                }
            }
            return null;
        }

        // Validators

        public static bool hasText(Control control)
        {   
            if(control is TextBox)
                return control.Text.Trim().Length > 0;
            throw new Exception("Invalid control for isEmpty Method");
        }

        public static bool oneHasText(Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    if (control.Text.Trim().Length > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("Invalid control for oneHasText Method");
                }
            }
            return false;
        }

        public static bool isSelected(Control control)
        {
            if (control is ComboBox)
                return ((ComboBox)control).SelectedIndex >= 0;
            
            throw new Exception("Invalid control for isSelected Method");
        }

        public static bool isNumber(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isNumber(control.Text);
            return false;
        }
        public static bool isCurrency(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isCurrency(control.Text);
            return false;
        }
        public static bool isPhone(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isParticularPhone(control.Text) 
                    || Validators.isMobilePhone(control.Text);
            return false;
        }
        public static bool isPhoneOrNull(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isParticularPhone(control.Text)
                    || Validators.isMobilePhone(control.Text);
            return true;
        }
        public static bool isParticularPhone(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isParticularPhone(control.Text);
            return false;
        }
        public static bool isPhoneWithExtension(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isPhoneWithExtension(control.Text);
            return false;
        }
        public static bool isPhoneWithExtensionOrNull(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isPhoneWithExtension(control.Text);
            return true;
        }
        public static bool isMobilePhone(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isMobilePhone(control.Text);
            return false;
        }
        public static bool isMobilePhoneOrNull(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isMobilePhone(control.Text);
            return true;
        }
        public static bool isPostalCode(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isPostalCode(control.Text);
            return false;
        }
        public static bool isEmail(Control control)
        {
            if (FormValidators.hasText(control))
            {
                try
                {
                    MailAddress m = new MailAddress(control.Text);

                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// The date is valid if is less or equals than now 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool isValidDate(Control control)
        {
            if (control is DateTimePicker || control is DateTimePicker)
                return DateTime.Compare(((DateTimePicker)control).Value, DateTime.Now) == -1;
            throw new Exception("Invalid control for isValidDate Method");
        }

        public static bool hasImageLocation(Control control)
        {
            if (control is PictureBox)
                return ((PictureBox)control).ImageLocation != null;
            throw new Exception("Invalid control for hasImageLocation Method");
        }

        public static bool isGreaterThan(Control higher, Control minor)
        {
            if(isNumber(higher) && isNumber(minor))
            {
                return Int32.Parse(higher.Text) > Int32.Parse(minor.Text);
            }
            else
            {
                return false;
            }
        }

        public static bool isGreaterOrEqualThan(Control higher, Control minor)
        {
            if (isNumber(higher) && isNumber(minor))
            {
                return Int32.Parse(higher.Text) >= Int32.Parse(minor.Text);
            }
            else
            {
                return false;
            }
        }
    }
}
