using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dominio
{
    public class Mesa
    {
        public enum EstadoMesa
        {
            MesaLibre = 0,
            PlatilloEnPreparacion = 2,
            Comiendo = 3,
            Pagando = 4
        }
        public EstadoMesa estadoMesa;
        public int IdMesa { get; set; }
        public Usuario MeseroAsignado { get; set; }
        public int numeroComensales { get; set; }
        public bool Disponibilidad { get; set; } // true: Libre, false: Ocupado
        public List<MenuItem> PlatosConsumidos { get; set; }
    }
}