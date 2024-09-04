using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using Newtonsoft.Json;



namespace CapaDatos
{
    public class CD_Venta
    {


        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM VENTA");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }



        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET Stock = Stock - @cantidad WHERE IdProducto = @idproducto");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    //respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }


        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET Stock = Stock + @cantidad WHERE IdProducto = @idproducto");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }



        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros de la venta
                    cmd.Parameters.AddWithValue("p_IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("p_TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("p_NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("p_DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("p_NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("p_MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("p_MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("p_MontoTotal", obj.MontoTotal);

                    // Convertir el DataTable a JSON
                    string detalleVentaJson = JsonConvert.SerializeObject(DetalleVenta);
                    cmd.Parameters.AddWithValue("p_DetalleVenta", detalleVentaJson);

                    // Parámetros de salida
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    // Ejecutar el procedimiento almacenado
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    Respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }


        public Venta ObtenerVenta(string numero) {

            Venta obj = new Venta();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena)) {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT v.IdVenta,u.Nombres,");
                    query.AppendLine("v.DocumentoCliente,v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento,v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago,v.MontoCambio,v.MontoTotal,");
                    query.AppendLine("DATE_FORMAT(v.FechaRegistro, '%d/%m/%Y') AS FechaRegistro");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN USUARIO u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("WHERE v.NumeroDocumento = @numero");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader()) {

                        while (dr.Read()) {
                            obj = new Venta()
                            {
                                IdVenta = int.Parse(dr["IdVenta"].ToString()),
                                oUsuario = new Usuario() { Nombres = dr["Nombres"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }

                }
                catch {
                    obj = new Venta();
                }

            }
            return obj;

        }


        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT tp.Nombre AS TipoProductoNombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal");
                    query.AppendLine("FROM DETALLE_VENTA dv");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine("INNER JOIN Tipo_Producto tp ON p.Id_Tipo_Producto = tp.Id");
                    query.AppendLine("WHERE dv.IdVenta = @idventa");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto()
                                {
                                    TipoProducto = new Tipo_Producto()
                                    {                                       
                                        Nombre = dr["TipoProductoNombre"].ToString()
                                    }
                                },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                            });
                        }
                    }               

                }
                catch
                {
                    oLista = new List<Detalle_Venta>();
                }
            }
            return oLista;
        }
    }
}
