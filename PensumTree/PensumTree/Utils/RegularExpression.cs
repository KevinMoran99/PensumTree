using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensumTree.Utils
{
    static class RegularExpression
    {
        public static readonly string isNumber = "^[0-9]+$";

        public static readonly string isParticularPhone = "^[2]{1}[0-9]{7}$";

        public static readonly string isPhoneWithExtension = "^[2]{1}[0-9]{7}([\\s]{1}[0-9]{4})*$";

        public static readonly string isMobilePhone = "^[67]{1}[0-9]{7}$";

        public static readonly string isPostalCode = "^[0-9]{4}$";

        public static readonly string isCurrency = "^[0-9]+.[0-9]{2}$";
    }
}
