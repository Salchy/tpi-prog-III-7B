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
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Categoria(int idCategoria, string nombreCategoria)
        {
            Id = idCategoria;
            Nombre = nombreCategoria;
        }
    }
}
