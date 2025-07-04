using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Validaciones
    {
        public int SoloNumeros(string str)
        {
            int aux = 0;
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return aux;
                }
            }
            aux = int.Parse(str);
            return aux;
        }

        public bool CampoVacio(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return true;
        }

        public string SoloLetras(string str)
        {
            string aux = "";
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                {
                    return aux;
                }
            }
            aux = str;
            return aux;

        }

        public string LetrasNumeros(string str)
        {
            string aux = "";
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return aux;
                }
            }
            aux = str;
            return aux;

        }

        public string SinCaracteresEspeciales(string str)
        {
            string aux = "";
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return aux;
                }
            }
            aux = str;
            return aux;

        }

        public bool BooleanSinCaracteresEspeciales(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && !char.IsDigit(c) && !char.IsWhiteSpace(c) && c != ',')
                {
                    return false;
                }
            }

            return true;

        }

        public bool BoolSoloNumeros(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }


        public bool validarTextos(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (BooleanSinCaracteresEspeciales(str) == false)
            {
                return false;
            }
            if (BoolSoloNumeros(str))
            {
                return false;
            }
            // DOBLE ESPACIO JUNTO
            if (str.Contains("  "))
            {
                return false;

            }

            return true;
        }
    }
}
