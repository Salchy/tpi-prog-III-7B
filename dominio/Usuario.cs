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

        public string Dni { get; }
        public string Nombre;
        public string Apellido;
        private Perfil TipoUsuario;

        // Gets y Sets
        public Perfil GetPerfil()
        {
            return TipoUsuario;
        }
        public bool setPerfil(Perfil tipoUsuario)
        {
            if (tipoUsuario != null)
            {
                TipoUsuario = tipoUsuario;
                return true;
            }
            return false;
        }

        // Métodos


        // Constructor
        public Usuario(string dni, string nombre, string apellido, Perfil perfil)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            TipoUsuario = perfil;
        }
    }
}