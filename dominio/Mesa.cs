using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Mesa
    {
        public int Id {  get; set; }    
        public string Numero { get; set; }
       public Usuario Usuario { get; set; }
        public string Comensales { get; set; }
        public bool Estado { get; set; }


    }
}
