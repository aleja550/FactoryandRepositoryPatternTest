using System.Text.RegularExpressions;

namespace LogicLayer
{
    public class Checks
    {
        public bool Name(string stringToVerify)
        {
            return Regex.IsMatch(stringToVerify, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$");
        }

        public bool Numeric(string Valor)
        {
            return Regex.IsMatch(Valor, @"^[+-]?\d+(\.\d+)?$");

        }

        public bool Fecha(string Valor)
        {
            return Regex.IsMatch(Valor, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$");
        }

        public bool Mail(string Valor)
        {
            return Regex.IsMatch(Valor, @"\A(\w+\.?\w*\@\w+\.)(com)\Z");
        }
    }
}
