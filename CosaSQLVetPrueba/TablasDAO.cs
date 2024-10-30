using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CosaSQLVetPrueba
{
    internal class TablasDAO
    {
        //Informacion de conecion para la base de datos
        string connectionString = "datasource=localhost;port=3306;username=root;database=vetprice;";

        public List<Cuentas> getAllCuentas()
        {
            List<Cuentas> returnThese = new List<Cuentas>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ventas_cuenta`", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cuentas a = new Cuentas
                    {
                        ID_Cuentas = reader.GetInt32(0),
                        Total = reader.GetFloat(1),
                        Fecha = reader.GetDateTime(2),
                        Forma_pago = reader.GetString(3)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }
        /*public List<Ventas> getVentasDetalle(int cuentaID)
        {
            List<Ventas> returnThese = new List<Ventas>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `ventas_detalle` WHERE Ventas_Cuenta_ID_Cuenta = @cuentaid";
            command.Parameters.AddWithValue("@cuentaid", cuentaID); //albumID viene de getVentasDetalle(int albumID)
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ventas b = new Ventas
                    {
                        ID = reader.GetInt32(0),
                    };
                    returnThese.Add(b);
                }
            }
            connection.Close();
            return returnThese;
        }
        */

        public List<JObject> getVentasDetalleJoin(int cuentaID)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT productos.Nombre_Producto, productos.Presentacion_Producto, ventas_detalle.Cantidad, ventas_detalle.Precio_Individual, ventas_detalle.Precio_Total, ventas_detalle.Descuento_Total\r\nFROM productos\r\n    INNER JOIN productos_has_ventas_detalle ON productos.ID_Productos = productos_has_ventas_detalle.productos_ID_Productos\r\n    INNER JOIN ventas_detalle ON productos_has_ventas_detalle.Ventas_Detalle_ID_Ven_Detalle  = ventas_detalle.ID_Ven_Detalle \r\nWHERE ventas_detalle.Ventas_Cuenta_ID_Cuenta = @cuentaid";
            command.Parameters.AddWithValue("@cuentaid", cuentaID); //albumID viene de getVentasDetalle(int albumID)
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newVenta = new JObject();
                    for (int i=0; i < reader.FieldCount; i++)
                    {
                        newVenta.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnThese.Add(newVenta);
                }
            }
            connection.Close();
            return returnThese;
        }
        public List<JObject> getInventarioJobject()
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `productos`";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newInventario = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        newInventario.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnThese.Add(newInventario);
                }
            }
            connection.Close();
            return returnThese;
        }

        public List<JObject> getProveedorJobject()
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `proveedores`";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newProveedor = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        newProveedor.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnThese.Add(newProveedor);
                }
            }
            connection.Close();
            return returnThese;
        }

        public List<ProveedoresMini> getProveedorIDNombre()
        {
            List<ProveedoresMini> returnThese = new List<ProveedoresMini>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `ID_Proveedores`,`Nombre_Proveedor` FROM `proveedores`", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProveedoresMini p = new ProveedoresMini
                    {
                        ID_Proveedores = reader.GetInt32(0),
                        Nombre_proveedor = reader.GetString(1)
                    };
                    returnThese.Add(p);
                }
            }
            connection.Close();
            return returnThese;
        }

        public List<JObject> getProductosProveedores(int ProveedorID)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Productos`, `Nombre_Producto`,  `Presentacion_Producto`, `Proveedor_Producto`, `Precio_Publico` , `Precio_Farmacia`, `Descuento_Porcentaje`, `Existencias`, `proveedores_ID_Proveedores` FROM `productos` JOIN proveedores ON proveedores.ID_Proveedores = productos.proveedores_ID_Proveedores WHERE proveedores.ID_Proveedores = @proveedorid";
            command.Parameters.AddWithValue("@proveedorid", ProveedorID); //albumID viene de getVentasDetalle(int albumID)
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newProducto = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        newProducto.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnThese.Add(newProducto);
                }
            }
            connection.Close();
            return returnThese;
        }

    }
}
