using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class menuItemDatos
    {

        public List<MenuItem> listarMenu()
        {
           List<MenuItem> menuCompleto = new List<MenuItem> ();

            menuCompleto.Add(new MenuItem());
            menuCompleto.Add(new MenuItem());
            menuCompleto.Add(new MenuItem());

            menuCompleto[0].IdMenuItem = 1;
            menuCompleto[0].Categoria = new Categoria();
            menuCompleto[0].Categoria.IdCategoria = 1;
            menuCompleto[0].Nombre = "Arroz";
            menuCompleto[0].Precio = 5000;
            //menuCompleto[0].Estado = true;
            menuCompleto[0].Descripcion = "Arroz ..........";

            menuCompleto[1].IdMenuItem = 2;
            menuCompleto[1].Categoria = new Categoria();
            menuCompleto[1].Categoria.IdCategoria = 2;
            menuCompleto[1].Nombre = "Fideos";
            menuCompleto[1].Precio = 6500;
            //menuCompleto[1].Estado = true;
            menuCompleto[1].Descripcion = "Fideos ..........";

            menuCompleto[2].IdMenuItem = 3;
            menuCompleto[2].Categoria = new Categoria();
            menuCompleto[2].Categoria.IdCategoria = 2;
            menuCompleto[2].Nombre = "Ravioles";
            menuCompleto[2].Precio = 7000;
            //menuCompleto[2].Estado = true;
            menuCompleto[2].Descripcion = "Ravioles ..........";


            return menuCompleto;


        }


        
    }
}
