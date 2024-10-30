using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaSQLVetPrueba
{
    internal class Cuentas
    {
        public int ID_Cuentas { get; set; }
        public float Total { get; set; }
        public DateTime Fecha {  get; set; } 
        public string Forma_pago { get; set; }
    }
}
