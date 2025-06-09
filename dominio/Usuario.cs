using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        // Astributos
        public int Id { get; set;}
        public string Dni { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public int NivelUsuario { get; }

        // Métodos


        // Constructor
        public Usuario(int id, string dni, string nombre, string apellido, int nivelUsuario)
        {
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            NivelUsuario = nivelUsuario;
        }
    }
}