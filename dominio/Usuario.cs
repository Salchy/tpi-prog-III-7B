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
        private string Nombre;
        private Perfil TipoUsuario;

        // Gets y Sets
        public string GetNombre()
        {
            return Nombre;
        }
        public bool SetNombre(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                Nombre = nombre;
                return true;
            }
            return false;
        }

        public Perfil GetPerfil()
        {
            return TipoUsuario;
        }
        public bool setPerfil(Perfil tipoUsuario)
        {
            if (tipoUsuario != null)
            {
                TipoUsuario = TipoUsuario;
                return true;
            }
            return false;
        }

        // Métodos


        // Constructor
        public Usuario(string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
            //TipoUsuario = new Perfil();
        }
    }
}