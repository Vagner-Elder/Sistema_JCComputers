using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Producto
    {

        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"
                SELECT 
                    P.IdProducto, 
                    P.Codigo, 
                    TP.Nombre AS TipoProducto, 
                    M.Nombre AS Marca, 
                    Mo.Nombre AS Modelo, 
                    CT.Nombre AS CapacidadTamano, 
                    TC.Nombre AS TipoComponente, 
                    P.Stock, 
                    P.PrecioCompra, 
                    P.PrecioVenta, 
                    S.Nombre AS Sucursal, 
                    P.Estado, 
                    P.Descripcion, 
                    P.FechaRegistro
                FROM 
                    PRODUCTO AS P
                    LEFT JOIN Tipo_Producto AS TP ON P.Id_Tipo_Producto = TP.Id
                    LEFT JOIN Marca AS M ON P.Id_Marca = M.Id
                    LEFT JOIN Modelo AS Mo ON P.Id_Modelo = Mo.Id
                    LEFT JOIN Capacidad_Tamanio AS CT ON P.Id_Capacidad_Tamanio = CT.Id
                    LEFT JOIN Tipo_Componente AS TC ON P.Id_Tipo_Componente = TC.Id
                    LEFT JOIN SUCURSAL AS S ON P.Id_Sucursal = S.IdSucursal";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                TipoProducto = new Tipo_Producto { Nombre = dr["TipoProducto"].ToString() },
                                Marca = new Marca { Nombre = dr["Marca"].ToString() },
                                Modelo = new Modelo { Nombre = dr["Modelo"].ToString() },
                                CapacidadTamano = new Capacidad_Tamanio{Nombre = dr["CapacidadTamano"].ToString() },
                                TipoComponente = new Tipo_Componente{Nombre = dr["TipoComponente"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Sucursal = new Sucursal{Nombre = dr["Sucursal"].ToString() },
                                Estado = Convert.ToInt32(dr["Estado"]) == 1 ? true : false,
                                Descripcion = dr["Descripcion"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };

                            lista.Add(producto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }

            return lista;
        }

        // Registrar Productos
        public int RegistrarProducto(string codigo, int idTipoProducto, int idMarca, int idModelo, int idCapacidadTamano, int idTipoComponente, int stock, decimal precioCompra, decimal precioVenta, int idSucursal, int estado, string descripcion, out string Mensaje)
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("InsertarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_Codigo", codigo);
                    cmd.Parameters.AddWithValue("p_Id_Tipo_Producto", idTipoProducto);
                    cmd.Parameters.AddWithValue("p_Id_Marca", idMarca);
                    cmd.Parameters.AddWithValue("p_Id_Modelo", idModelo);
                    cmd.Parameters.AddWithValue("p_Id_Capacidad_Tamanio", idCapacidadTamano);
                    cmd.Parameters.AddWithValue("p_Id_Tipo_Componente", idTipoComponente);
                    cmd.Parameters.AddWithValue("p_Stock", stock);
                    cmd.Parameters.AddWithValue("p_PrecioCompra", precioCompra);
                    cmd.Parameters.AddWithValue("p_PrecioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("p_Id_Sucursal", idSucursal);
                    cmd.Parameters.AddWithValue("p_Estado", estado);
                    cmd.Parameters.AddWithValue("p_Descripcion", descripcion);

                    cmd.Parameters.Add(new MySqlParameter("p_Resultado", MySqlDbType.Int32));
                    cmd.Parameters["p_Resultado"].Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                }
                catch (Exception ex)
                {
                    idProductoGenerado = 0;
                    Mensaje = ex.Message;
                }
            }
            return idProductoGenerado;
        }


        public int EditarProducto(int idProducto, string codigo, int idTipoProducto, int idMarca, int idModelo, int idCapacidadTamano, int idTipoComponente, int stock, decimal precioCompra, decimal precioVenta, int idSucursal, int estado, string descripcion, out string Mensaje)
        {
            int resultado = 0;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("EditarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("p_Codigo", codigo);
                    cmd.Parameters.AddWithValue("p_Id_Tipo_Producto", idTipoProducto);
                    cmd.Parameters.AddWithValue("p_Id_Marca", idMarca);
                    cmd.Parameters.AddWithValue("p_Id_Modelo", idModelo);
                    cmd.Parameters.AddWithValue("p_Id_Capacidad_Tamanio", idCapacidadTamano);
                    cmd.Parameters.AddWithValue("p_Id_Tipo_Componente", idTipoComponente);
                    cmd.Parameters.AddWithValue("p_Stock", stock);
                    cmd.Parameters.AddWithValue("p_PrecioCompra", precioCompra);
                    cmd.Parameters.AddWithValue("p_PrecioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("p_Id_Sucursal", idSucursal);
                    cmd.Parameters.AddWithValue("p_Estado", estado);
                    cmd.Parameters.AddWithValue("p_Descripcion", descripcion);

                    cmd.Parameters.Add(new MySqlParameter("p_Resultado", MySqlDbType.Int32));
                    cmd.Parameters["p_Resultado"].Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                }
                catch (Exception ex)
                {

                    resultado = 0;
                    Mensaje = ex.Message;
                }
            }
            return resultado;
        }

        //public bool Eliminar(Producto obj, out string Mensaje)
        //{
        //    bool respuesta = false;
        //    Mensaje = string.Empty;

        //    try
        //    {

        //        using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
        //        {

        //            MySqlCommand cmd = new MySqlCommand("SP_EliminarProducto", oconexion);
        //            cmd.Parameters.AddWithValue("p_IdProducto", obj.IdProducto);
        //            cmd.Parameters.Add("p_Respuesta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oconexion.Open();

        //            cmd.ExecuteNonQuery();

        //            respuesta = Convert.ToBoolean(cmd.Parameters["p_Respuesta"].Value);
        //            Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta = false;
        //        Mensaje = ex.Message;
        //    }

        //    return respuesta;
        //}
    }
}
