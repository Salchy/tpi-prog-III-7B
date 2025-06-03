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
        private int IdMenuItem { get; set; }
        private Categoria Categoria { get; set; }
        private string Nombre { get; set; }
        private decimal Precio { get; set; }
        
    }
}
