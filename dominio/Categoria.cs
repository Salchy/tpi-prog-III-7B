using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    // Podría ser como las categorías del menú
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } // Supongo que podría ser Bebidas, tipo de plato (Pastas, Carnes), postre, etc.
    }
}
