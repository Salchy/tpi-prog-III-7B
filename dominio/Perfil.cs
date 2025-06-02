using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Perfil
    {
        public int idPermiso { get; }
        public string NombrePermiso;
        public string getNombrePermiso()
        {
            return NombrePermiso;
        }

        public bool setNombrePermiso(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                NombrePermiso = value;
                return true;
            }
            return false;
        }

        public Perfil(int idPermiso, string nombrePermiso)
        {
            idPermiso = idPermiso;
            NombrePermiso = nombrePermiso;
        }
    }
}
