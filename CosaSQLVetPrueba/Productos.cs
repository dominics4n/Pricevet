﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaSQLVetPrueba
{
    internal class Productos
    {
        public int ID_Producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Presentacion_producto { get; set; }
        public string Proveedor_producto { get; set; }
        public float Precio_publico { get; set; }
        public float Precio_farmacia { get; set; }
        public float Descuento_Porcentaje { get; set; }
        public int Existencias { get; set; }
    }
    internal class Productos_mini
    {
        public int ID_Producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Presentacion_producto { get; set; }
        public string Proveedor_producto { get; set; }
        public float Precio_publico { get; set; }
        public int Descuento_Porcentaje { get; set; }
        public int Existencias { get; set; }
    }

    internal class Productos_preview

    { 
        public int ID_Producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Presentacion_producto { get; set; }
        public float Precio_publico { get; set; }
        public int Descuento_Porcentaje { get; set; }
        public int Existencias { get; set; }
    }

    internal class Productos_select

    {
        public int ID_Producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Presentacion_producto { get; set; }
        public float Precio_publico { get; set; }
        public float Precio_farmacia { get; set; }
        public int Descuento_Porcentaje { get; set; }
        public int Existencias { get; set; }
    }
}
