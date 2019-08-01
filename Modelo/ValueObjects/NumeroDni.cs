using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modelo.ValueObjects
{
    public class NumeroDni
    {
        public NumeroDni() { }
        public NumeroDni(long dni)
        {
           
            const string RegExForValidation = @"/^\d{8}(?:[-\s]\d{4})?$";
            
            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(dni.ToString());

            if (!match.Success)
            {
                throw new DniIncorrecto(string.Format("El dni {0} es incorrecto",dni.ToString()));
            }
        }
    }
}
