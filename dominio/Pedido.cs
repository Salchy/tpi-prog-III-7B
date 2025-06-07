using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public Mesa mesa { get; set; }
        public bool Estado { get; set; }
        public float Importe { get; set; }


    }
}
