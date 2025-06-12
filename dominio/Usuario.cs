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
        public bool Estado { get; }

        // Métodos


        // Constructor
        public Usuario(int id, string dni, string nombre, string apellido, int nivelUsuario, bool estado = true)
        {
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            NivelUsuario = nivelUsuario;
            Estado = estado;
        }
    }
}