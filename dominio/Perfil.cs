using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Perfil
    {
        public int IdPermiso { get; }
        public int Nivel { get; }
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

        public Perfil(int idPermiso, string nombrePermiso) // Sólo para que no se me rompa por ahora
        {
            IdPermiso = idPermiso;
            NombrePermiso = nombrePermiso;
            Nivel = 0;
        }

        public Perfil(int idPermiso, string nombrePermiso, int nivel)
        {
            IdPermiso = idPermiso;
            NombrePermiso = nombrePermiso;
            Nivel = nivel;
        }
    }
}
