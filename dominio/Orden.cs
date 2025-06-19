using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Orden
    {
        public int id { get; set; }
        public MenuItem Menu { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
        public Pedido Pedido { get; set; }
    }
}
