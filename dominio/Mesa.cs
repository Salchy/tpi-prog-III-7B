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
        public enum estadoMesa
        {
            MesaLibre = 0,
            PlatilloEnPreparacion = 1,
            Comiendo = 2,
            Pagando = 3
        }

        public estadoMesa EstadoMesa;
        public int IdMesa { get; set; }
        public string NumeroMesa { get; set; }
        public int NumeroComensales { get; set; }
        public Usuario MeseroAsignado { get; set; }
        public bool Habilitado { get; set; } // Bool que controla que la mesa esté habilitada al publico o no
        //public List<MenuItem> PlatosConsumidos { get; set; } // Acá se van guardando los platos que va pidiendo la mesa (quizá no haga falta)

        public Mesa(int idMesa, string numeroMesa, estadoMesa estadoDeMesa, int numeroComensales, Usuario meseroAsignado)
        {
            IdMesa = idMesa;
            NumeroMesa = numeroMesa;
            EstadoMesa = estadoDeMesa;
            MeseroAsignado = meseroAsignado;
        }
    }
}