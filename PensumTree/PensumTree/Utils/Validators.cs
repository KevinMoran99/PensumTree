
using System.Text.RegularExpressions;


namespace PensumTree.Utils
{
    static class Validators
    {
        public static bool isNumber(string value)
        {
            return Regex.Match(value, RegularExpression.isNumber).Success;
        }
        public static bool isParticularPhone(string value)
        {
            return Regex.Match(value, RegularExpression.isParticularPhone).Success;
        }
        public static bool isPhoneWithExtension(string value)
        {
            return Regex.Match(value, RegularExpression.isPhoneWithExtension).Success;
        }
        public static bool isMobilePhone(string value)
        {
            return Regex.Match(value, RegularExpression.isMobilePhone).Success;
        }
        public static bool isPostalCode(string value)
        {
            return Regex.Match(value, RegularExpression.isPostalCode).Success;
        }
        public static bool isCurrency(string value)
        {
            return Regex.Match(value, RegularExpression.isCurrency).Success;
        }
    }
}
