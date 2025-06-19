using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class SubCategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCategoriaPadre { get; set; }
        public string NombreCategoriaPadre { get; set; }
        public bool Estado { get; set; }

        public SubCategoria(int idSubCategoria, string nombreSubCategoria, int idCategoriaPadre)
        {
            Id = idSubCategoria;
            Nombre = nombreSubCategoria;
            IdCategoriaPadre = idCategoriaPadre;
        }

        public SubCategoria()
        {

        }
    }
}
