namespace CosaSQLVetPrueba
{
    internal class Ventas
    {
        public int ID_Ventas { get; set; }
        public string Producto_detalle { get; set; }
        public int Cantidad_detalle { get; set; }
        public float precio_individual { get; set; }
        public float precio_total { get; set; }
        public float descuento_total { get; set; }
        public int ID_Cuentas_FK { get; set; }
    }
}