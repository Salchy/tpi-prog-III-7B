using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MesaDatos
    {
        Database db;
        
        public List<Mesa> getMesas()
        {
            List<Mesa> mesas = new List<Mesa>();

            // Hardcoding para modelo de dominio funcional

            return mesas;
        }

        public MesaDatos() {
            db = new Database();
        }
    }
}
