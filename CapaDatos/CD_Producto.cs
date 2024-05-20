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

        //public List<Producto> Listar()
        //{
        //    List<Producto> lista = new List<Producto>();

        //    using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
        //    {
        //        try
        //        {
        //            string query = @"
        //        SELECT 
        //            P.IdProducto, 
        //            P.Codigo, 
        //            TP.Nombre AS TipoProducto, 
        //            M.Nombre AS Marca, 
        //            Mo.Nombre AS Modelo, 
        //            CT.Nombre AS CapacidadTamano, 
        //            TC.Nombre AS TipoComponente, 
        //            P.Stock, 
        //            P.PrecioCompra, 
        //            P.PrecioVenta, 
        //            S.Nombre AS Sucursal, 
        //            P.Estado, 
        //            P.Descripcion, 
        //            P.FechaRegistro
        //        FROM 
        //            PRODUCTO AS P
        //            LEFT JOIN Tipo_Producto AS TP ON P.Id_Tipo_Producto = TP.Id
        //            LEFT JOIN Marca AS M ON P.Id_Marca = M.Id
        //            LEFT JOIN Modelo AS Mo ON P.Id_Modelo = Mo.Id
        //            LEFT JOIN Capacidad_Tamanio AS CT ON P.Id_Capacidad_Tamanio = CT.Id
        //            LEFT JOIN Tipo_Componente AS TC ON P.Id_Tipo_Componente = TC.Id
        //            LEFT JOIN SUCURSAL AS S ON P.Id_Sucursal = S.IdSucursal";

        //            MySqlCommand cmd = new MySqlCommand(query, oconexion);
        //            cmd.CommandType = CommandType.Text;

        //            oconexion.Open();

        //            using (MySqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    Producto producto = new Producto
        //                    {
        //                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
        //                        Codigo = dr["Codigo"].ToString(),
        //                        TipoProducto = dr["TipoProducto"].ToString(),
        //                        Marca = dr["Marca"].ToString(),
        //                        Modelo = dr["Modelo"].ToString(),
        //                        CapacidadTamano = dr["CapacidadTamano"].ToString(),
        //                        TipoComponente = dr["TipoComponente"].ToString(),
        //                        Stock = Convert.ToInt32(dr["Stock"]),
        //                        PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
        //                        PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
        //                        Sucursal = dr["Sucursal"].ToString(),
        //                        Estado = Convert.ToInt32(dr["Estado"]) == 1 ? true : false,
        //                        Descripcion = dr["Descripcion"].ToString(),
        //                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
        //                    };

        //                    lista.Add(producto);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //           lista = new List<Producto>();
        //        }
        //    }

        //    return lista;
        //}

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

        //FALTA ADAPTAR ESTO CON LA TABLA PRODUCTO DE LA BD

        //public int Registrar(Producto obj, out string Mensaje)
        //{
        //    int idProductogenerado = 0;
        //    Mensaje = string.Empty;


        //    try
        //    {

        //        using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
        //        {

        //            MySqlCommand cmd = new MySqlCommand("sp_RegistrarProducto", oconexion);
        //            cmd.Parameters.AddWithValue("p_Codigo", obj.Codigo);
        //            cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
        //            cmd.Parameters.AddWithValue("p_Descripcion", obj.Descripcion);
        //            cmd.Parameters.AddWithValue("p_IdCategoria", obj.oCategoria.IdCategoria);
        //            cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
        //            cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oconexion.Open();

        //            cmd.ExecuteNonQuery();

        //            idProductogenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
        //            Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        idProductogenerado = 0;
        //        Mensaje = ex.Message;
        //    }



        //    return idProductogenerado;
        //}



        //public bool Editar(Producto obj, out string Mensaje)
        //{
        //    bool respuesta = false;
        //    Mensaje = string.Empty;


        //    try
        //    {

        //        using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
        //        {

        //            MySqlCommand cmd = new MySqlCommand("sp_ModificarProducto", oconexion);
        //            cmd.Parameters.AddWithValue("p_IdProducto", obj.IdProducto);
        //            cmd.Parameters.AddWithValue("p_Codigo", obj.Codigo);
        //            cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
        //            cmd.Parameters.AddWithValue("p_Descripcion", obj.Descripcion);
        //            cmd.Parameters.AddWithValue("p_IdCategoria", obj.oCategoria.IdCategoria);
        //            cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
        //            cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oconexion.Open();

        //            cmd.ExecuteNonQuery();

        //            respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
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
