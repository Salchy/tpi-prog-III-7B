using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    // Esta clase, es cada uno de los ítem que representa un menú en la aplicación.
    // Puede ser una bebida, un plato, un postre, etc.
    // Esto va a ser otra tabla
    public class MenuItem
    {
        public int IdMenuItem { get; set; }
        public Categoria Categoria { get; set; }
        public SubCategoria SubCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        //public bool Estado { get; set; } // Estado no hace falta, al momento de leer de la base de datos, si en el row del query está con estado falso (Eliminado) no hace falta representar la entidad en C#
        public string Descripcion { get; set; }

    }
}
