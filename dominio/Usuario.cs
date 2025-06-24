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
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NivelUsuario { get; set; }
        public bool Estado { get; set; }

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

        public string getFullName()
        {
            return Nombre + " " + Apellido;
        }
    }
}