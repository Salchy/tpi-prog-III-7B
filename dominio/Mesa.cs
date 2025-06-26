using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static dominio.Mesa;

namespace dominio
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public string NumeroMesa { get; set; }
        public int NumeroComensales { get; set; }
        public Usuario MeseroAsignado { get; set; }
        public bool Habilitado { get; set; } // Bool que controla que la mesa esté habilitada al publico o no
        public Mesa(int idMesa, string numeroMesa, int numeroComensales, Usuario meseroAsignado, bool habilitado)
        {
            IdMesa = idMesa;
            NumeroMesa = numeroMesa;
            NumeroComensales = numeroComensales;
            MeseroAsignado = meseroAsignado;
            Habilitado = habilitado;
        }
    }
}