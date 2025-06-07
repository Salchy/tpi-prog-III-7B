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
        public int Id { get; }
        public string Dni { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public Perfil TipoUsuario { get; }

        // Métodos


        // Constructor
        public Usuario(int id, string dni, string nombre, string apellido, Perfil perfil)
        {
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            TipoUsuario = perfil;
        }
    }
}