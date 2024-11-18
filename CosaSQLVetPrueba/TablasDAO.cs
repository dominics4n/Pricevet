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
using Mysqlx.Cursor;

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
                    for (int i = 0; i < reader.FieldCount; i++)
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

        public List<Productos_mini> buscarInventario(string searchterm)
        {
            List<Productos_mini> returnThese = new List<Productos_mini>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String searchWildPhrase = "%" + searchterm + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Productos`, `Nombre_Producto`, `Presentacion_Producto`, `Proveedor_Producto`, `Precio_Publico`, `Descuento_Porcentaje`, `Existencias` FROM `productos` WHERE Nombre_Producto LIKE @search";
            command.Parameters.AddWithValue("@search", searchWildPhrase);
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(5))
                    {
                        Productos_mini p = new Productos_mini
                        {
                            ID_Producto = reader.GetInt32(0),
                            Nombre_producto = reader.GetString(1),
                            Presentacion_producto = reader.GetString(2),
                            Proveedor_producto = reader.GetString(3),
                            Precio_publico = reader.GetFloat(4),
                            Descuento_Porcentaje = 0,
                            Existencias = reader.GetInt32(6)
                        };
                        returnThese.Add(p);
                    }
                    else
                    {
                        Productos_mini p = new Productos_mini
                        {
                            ID_Producto = reader.GetInt32(0),
                            Nombre_producto = reader.GetString(1),
                            Presentacion_producto = reader.GetString(2),
                            Proveedor_producto = reader.GetString(3),
                            Precio_publico = reader.GetFloat(4),
                            Descuento_Porcentaje = reader.GetInt32(5),
                            Existencias = reader.GetInt32(6)
                        };
                        returnThese.Add(p);
                    }

                }
            }
            connection.Close();
            return returnThese;
        }

        public List<Productos_preview> getProductoPreview(int ProductoID)
        {
            List<Productos_preview> returnThese = new List<Productos_preview>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Productos`, `Nombre_Producto`, `Presentacion_Producto`, `Precio_Publico`, `Descuento_Porcentaje`, `Existencias` FROM `productos` WHERE `ID_Productos` = @productoid";
            command.Parameters.AddWithValue("@productoid", ProductoID);
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(4))
                    {
                        Productos_preview p = new Productos_preview
                        {
                            ID_Producto = reader.GetInt32(0),
                            Nombre_producto = reader.GetString(1),
                            Presentacion_producto = reader.GetString(2),
                            Precio_publico = reader.GetFloat(3),
                            Descuento_Porcentaje = 0,
                            Existencias = reader.GetInt32(5)
                        };
                        returnThese.Add(p);
                    }
                    else
                    {
                        Productos_preview p = new Productos_preview
                        {
                            ID_Producto = reader.GetInt32(0),
                            Nombre_producto = reader.GetString(1),
                            Presentacion_producto = reader.GetString(2),
                            Precio_publico = reader.GetFloat(3),
                            Descuento_Porcentaje = reader.GetInt32(4),
                            Existencias = reader.GetInt32(5)
                        };
                        returnThese.Add(p);
                    }
                }
            }
            connection.Close();
            return returnThese;
        }

        public List<Cuentas> searchCuentas(string Cuentaid, string fecha)
        {
            List<Cuentas> returnThese = new List<Cuentas>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String IDWildPhrase = "%" + Cuentaid + "%";
            String FechaWildPhrase = "%" + fecha + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Cuenta`, `Total`, `Fecha`, `Forma_Pago` FROM `ventas_cuenta` WHERE `ID_Cuenta` LIKE @cuentaid AND `Fecha` LIKE @cuentafecha";
            command.Parameters.AddWithValue("@cuentaid", IDWildPhrase);
            command.Parameters.AddWithValue("@cuentafecha", FechaWildPhrase);
            command.Connection = connection;


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

        public List<JObject> searchInventarioJobject(string IDProd, string NombreProd, string ProveedorProd)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String IDWildPhrase = "%" + IDProd + "%";
            String NombreWildPhrase = "%" + NombreProd + "%";
            String ProveedorWildPhrase = "%" + ProveedorProd + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Productos`, `Nombre_Producto`, `Proveedor_Producto`, `Presentacion_Producto`, `Precio_Publico`, `Precio_Farmacia`, `Descuento_Porcentaje`, `Existencias`, `proveedores_ID_Proveedores` FROM `productos` WHERE `ID_Productos` LIKE @productoid AND `Nombre_Producto` LIKE @productoname AND `Proveedor_Producto` LIKE @productoprove";
            command.Parameters.AddWithValue("@productoid", IDWildPhrase);
            command.Parameters.AddWithValue("@productoname", NombreWildPhrase);
            command.Parameters.AddWithValue("@productoprove", ProveedorWildPhrase);
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

        public List<JObject> searchProveedorJobject(String nombreprov)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String NombreWildPhrase = "%" + nombreprov + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Proveedores`, `Nombre_Proveedor`, `Descripcion_Proveedor`, `Sitio_Web`, `Correo_Contacto`, `Telefono_Contacto` FROM `proveedores` WHERE `Nombre_Proveedor` LIKE @proveedorname";
            command.Parameters.AddWithValue("@proveedorname", NombreWildPhrase);
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

        public List<ProveedoresMini> searchProveedorIDNombre(String nombreprov)
        {
            List<ProveedoresMini> returnThese = new List<ProveedoresMini>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String NombreWildPhrase = "%" + nombreprov + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID_Proveedores`,`Nombre_Proveedor` FROM `proveedores` WHERE `Nombre_Proveedor` LIKE @proveedorname";
            command.Parameters.AddWithValue("@proveedorname", NombreWildPhrase);
            command.Connection = connection;

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

        public List<Cuentas> getUltimaCuenta()
        {
            List<Cuentas> returnThese = new List<Cuentas>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `ventas_cuenta` ORDER BY `ID_Cuenta` DESC LIMIT 1";
            command.Connection = connection;

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
        internal int updateUltimaCuenta(int IDCuenta, string MetodoPago)
        {
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "UPDATE `ventas_cuenta` SET `Forma_Pago`= @metodoPago WHERE `ID_Cuenta` = @ultimaID";
            command.Parameters.AddWithValue("@ultimaID", IDCuenta);
            command.Parameters.AddWithValue("@metodoPago", MetodoPago);
            command.Connection = connection;
            int updatecuentas = command.ExecuteNonQuery();

            connection.Close();
            return updatecuentas;
        }

        internal int updateUltimaVenta(string NameProducto,int IDCuenta, int Cantidad, float Precio, float Descuento, int IDProd)
        {

            float Subtotal = Precio * Cantidad;
            float Desctotal = Descuento / 100 * Precio * Cantidad;


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO `ventas_detalle`(`Producto`, `Cantidad`, `Precio_Individual`, `Precio_Total`, `Descuento_Total`, `Ventas_Cuenta_ID_Cuenta`, `ventas_Producto_ID_ventas`) VALUES (@productoname, @cantidad, @precioindi, @subtotal, @desctotal, @cuentaID, @productoID)";
            command.Parameters.AddWithValue("@productoname", NameProducto);
            command.Parameters.AddWithValue("@cantidad", Cantidad);
            command.Parameters.AddWithValue("@precioindi", Precio);
            command.Parameters.AddWithValue("@subtotal", Subtotal);
            command.Parameters.AddWithValue("@desctotal", Desctotal);
            command.Parameters.AddWithValue("@cuentaID", IDCuenta);
            command.Parameters.AddWithValue("@productoID", IDProd);
            command.Connection = connection;
            int updateventas = command.ExecuteNonQuery();

            connection.Close();
            return updateventas;
        }

        internal int updateventahascuenta(int IDVenta)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO `productos_has_ventas_detalle`(`productos_ID_Productos`, `Ventas_Detalle_ID_Ven_Detalle`) SELECT @ventaID AS `productos_ID_Productos`, ID_Ven_Detalle AS `Ventas_Detalle_ID_Ven_Detalle` FROM ventas_detalle ORDER BY `ID_Ven_Detalle` DESC LIMIT 1";
            command.Parameters.AddWithValue("@ventaID", IDVenta);
            command.Connection = connection;
            int updateventascuentas = command.ExecuteNonQuery();

            connection.Close();
            return updateventascuentas;
        }

        public List<JObject> getUltimaVenta()
        {
            int lastID = 1;
            List<JObject> returnThese = new List<JObject>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand lastid = new MySqlCommand();
            MySqlCommand command = new MySqlCommand();
            lastid.CommandText = "SELECT MAX(`ID_Cuenta`) FROM `ventas_cuenta`";
            lastid.Connection = connection;
            using (MySqlDataReader reader = lastid.ExecuteReader())
            {
                while (reader.Read())
                {
                    lastID = reader.GetInt32(0);
                }
            }

            command.CommandText = "SELECT productos.Nombre_Producto, productos.Presentacion_Producto, ventas_detalle.Cantidad, ventas_detalle.Precio_Individual, ventas_detalle.Precio_Total, ventas_detalle.Descuento_Total\r\nFROM productos\r\n INNER JOIN productos_has_ventas_detalle ON productos.ID_Productos = productos_has_ventas_detalle.productos_ID_Productos\r\n INNER JOIN ventas_detalle ON productos_has_ventas_detalle.Ventas_Detalle_ID_Ven_Detalle = ventas_detalle.ID_Ven_Detalle WHERE ventas_detalle.Ventas_Cuenta_ID_Cuenta = @last_id";
            command.Parameters.AddWithValue("@last_id", lastID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newVenta = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        newVenta.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnThese.Add(newVenta);
                }
            }
            connection.Close();
            return returnThese;
        }

        internal float updateTotal(string totals)
        {
            int lastID = 1;
            float totalIndiv, descuentoIndiv;
            float subtotal = 0, desctotal = 0, total = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand lastid = new MySqlCommand();
            lastid.CommandText = "SELECT MAX(`Ventas_Cuenta_ID_Cuenta`) FROM `ventas_detalle`";
            lastid.Connection = connection;
            using (MySqlDataReader reader = lastid.ExecuteReader())
            {
                while (reader.Read())
                {
                    lastID = reader.GetInt32(0);
                }
            }

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `Precio_Total`, `Descuento_Total` FROM `ventas_detalle`  WHERE `Ventas_Cuenta_ID_Cuenta` = @last_id";
            command.Parameters.AddWithValue("@last_id", lastID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    totalIndiv = reader.GetFloat(0);
                    descuentoIndiv = reader.GetFloat(1);
                    subtotal = subtotal + totalIndiv;
                    desctotal = desctotal + descuentoIndiv;
                }
            }
            total = subtotal - desctotal;

            MySqlCommand updatetotal  = new MySqlCommand();
            updatetotal.CommandText = "UPDATE `ventas_cuenta` SET  `Total`= @newtotal WHERE `ID_Cuenta` = @ultimaID";
            updatetotal.Parameters.AddWithValue("@newtotal", total);
            updatetotal.Parameters.AddWithValue("@ultimaID", lastID);
            updatetotal.Connection = connection;
            updatetotal.ExecuteNonQuery();
            connection.Close();
            if (totals == "subtotal")
            {
                return subtotal;
            }
            else {
                return total;
            }
            
        }

        internal int insertCuenta()
        {
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            
            MySqlCommand newCuenta = new MySqlCommand();
            newCuenta.CommandText = "INSERT INTO `ventas_cuenta` (`ID_Cuenta`, `Total`, `Fecha`, `Forma_Pago`) VALUES (NULL, '0', current_timestamp(), 'Efectivo')";
            newCuenta.Connection = connection;
            int insertcuenta = newCuenta.ExecuteNonQuery();
            connection.Close();
            return insertcuenta;
        }

        public List<MaxVentas> getMaxventas()
        {
            List<MaxVentas> returnThese = new List<MaxVentas>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `Producto`, SUM(`Cantidad`) AS 'Cantidad Vendida' FROM `ventas_detalle` GROUP BY `ventas_Producto_ID_ventas` ORDER BY SUM(`Cantidad`) DESC";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MaxVentas a = new MaxVentas
                    {
                        Producto = reader.GetString(0),
                        Cantidad_Ventas = reader.GetInt32(1)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }

        public List<MaxDineros> getMaxDineros()
        {
            List<MaxDineros> returnThese = new List<MaxDineros>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `Producto`, SUM(`Precio_Total`) AS 'Ingresos Totales' FROM `ventas_detalle` GROUP BY `ventas_Producto_ID_ventas` ORDER BY SUM(`Precio_Total`) DESC";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MaxDineros a = new MaxDineros
                    {
                        Producto = reader.GetString(0),
                        Cantidad_Ingresos = reader.GetFloat(1)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }



        public float DAOtotalingresosfl = 0;
        public string DAOmenosventas = "si";
        public string DAOmenosdineros = "no";


        public int getEstadisticas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            float total_ingresosfl = 0;
            int total_ventasint = 0;
            string prodmenosdineros = "si";
            string prodmenosventas = "si";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT SUM(`Precio_Total`), SUM(`Cantidad`)  FROM `ventas_detalle`";
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    total_ingresosfl = reader.GetFloat(0);
                    total_ventasint = reader.GetInt32(1);
                }
            }
            DAOtotalingresosfl = total_ingresosfl;

            MySqlCommand menosdineros = new MySqlCommand();
            menosdineros.CommandText = "SELECT `Producto` FROM `ventas_detalle` GROUP BY `ventas_Producto_ID_ventas` ORDER BY SUM(`Precio_Total`) LIMIT 1";
            menosdineros.Connection = connection;
            using (MySqlDataReader reader = menosdineros.ExecuteReader())
            {
                while (reader.Read())
                {
                    prodmenosdineros = reader.GetString(0);
                }
            }

            DAOmenosdineros = prodmenosdineros;

            MySqlCommand menosventas = new MySqlCommand();
            menosventas.CommandText = "SELECT `Producto` FROM `ventas_detalle` GROUP BY `ventas_Producto_ID_ventas` ORDER BY SUM(`Cantidad`) LIMIT 1";
            menosventas.Connection = connection;
            using (MySqlDataReader reader = menosventas.ExecuteReader())
            {
                while (reader.Read())
                {
                    prodmenosventas = reader.GetString(0);
                }
            }
            DAOmenosventas = prodmenosventas;

            connection.Close();
            return total_ventasint;
        }

        


    }
}
