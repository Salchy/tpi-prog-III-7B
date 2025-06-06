﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public Mesero MeseroAsignado { get; set; }
        public int numeroComensales { get; set; }
        public bool Disponibilidad { get; set; } // true: Libre, false: Ocupado
        public string Estado { get; set; } // Puede ser: "Eligiendo orden",  "Pedido tomado", "Comiendo", "Pagando"
        //public List<MenuItem> PlatosConsumidos { get; set; }
    }
}