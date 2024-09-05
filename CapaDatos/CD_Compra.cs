using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace CapaDatos
{
    public class CD_Compra
    {
        public int ObtenerCorrelativo() {
            int idcorrelativo = 0;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");
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


        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje) 
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    // Convertir el DataTable de DetalleCompra a JSON usando Newtonsoft.Json
                    string detalleCompraJson = JsonConvert.SerializeObject(DetalleCompra);

                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarCompra", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("p_IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("p_IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("p_TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("p_NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("p_MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", detalleCompraJson); // Pasar el JSON generado

                    // Parámetros de salida
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener los valores de los parámetros de salida
                    Respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;
        }


        public Compra ObtenerCompra(string numero) {
            Compra obj = new Compra();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT c.IdCompra,");
                    query.AppendLine("u.Nombres,"); // Cambié de NombreCompleto a Nombres para consistencia
                    query.AppendLine("pr.Documento, pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal,");
                    query.AppendLine("DATE_FORMAT(c.FechaRegistro, '%d/%m/%Y') AS FechaRegistro"); // Cambio para formato de fecha en MySQL
                    query.AppendLine("FROM COMPRA c");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario");
                    query.AppendLine("INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("WHERE c.NumeroDocumento = @numero");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() { Nombres = dr["Nombres"].ToString() },
                                oProveedor = new Proveedor()
                                {
                                    Documento = dr["Documento"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString()
                                },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    obj = new Compra();
                }
            }
            return obj;
        }


        public List<Detalle_Compra> ObtenerDetalleCompra(int idCompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT tp.Nombre AS TipoProductoNombre, dc.PrecioCompra, dc.PrecioVenta, dc.Cantidad, dc.MontoTotal");
                    query.AppendLine("FROM DETALLE_COMPRA dc");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto");
                    query.AppendLine("INNER JOIN Tipo_Producto tp ON p.Id_Tipo_Producto = tp.Id");
                    query.AppendLine("WHERE dc.IdCompra = @idcompra");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idcompra", idCompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto()
                                {
                                    TipoProducto = new Tipo_Producto()
                                    {
                                        Nombre = dr["TipoProductoNombre"].ToString()
                                    }
                                },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                            });
                        }
                    }
                }
                catch
                {
                    oLista = new List<Detalle_Compra>();
                }
            }
            return oLista;
        }



    }
}
