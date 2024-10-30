using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaSQLVetPrueba
{
    internal class Proveedores
    {
        public int ID_Proveedores { get; set; }
        public string Nombre_proveedor { get; set; }
        public string Descripcion_proveedor { get; set; }
        public string Sitio_Web { get; set; }
        public float email_proveedor { get; set; }
        public float Telefono_contacto { get; set; }
    }
    internal class ProveedoresMini
    {
        public int ID_Proveedores { get; set; }
        public string Nombre_proveedor { get; set; }
    }
}
