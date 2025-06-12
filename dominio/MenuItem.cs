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
        public bool Estado { get; set; }
        public string Descripcion { get; set; }

        public MenuItem(int idMenuItem, string nombre, string descripcion, decimal precio, int idCategoria, string nombreCategoria, int idSubCategoria, string subCategoriaNombre)
        {
            IdMenuItem = idMenuItem;
            Categoria = new Categoria(idCategoria, nombreCategoria);
            SubCategoria = new SubCategoria(idSubCategoria, subCategoriaNombre, idCategoria);
            Nombre = nombre;
            Precio = precio;
            Estado = true;
            Descripcion = descripcion;
        }


        public MenuItem()
        {
           
        }
    }
}
