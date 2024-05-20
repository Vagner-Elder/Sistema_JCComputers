using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class CD_Sucursal
    {
        public List<Sucursal> Listar()
        {
            List<Sucursal> lista = new List<Sucursal>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdSucursal, Nombre, Direccion, Estado FROM SUCURSAL;");
                    //query.AppendLine("SELECT Nombre FROM SUCURSAL;");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Sucursal()
                            {
                                IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Sucursal>();
                }
            }
            return lista;
        }

     //insertar datos
        public int Registrar(Sucursal obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("InsertarSucursal", oconexion);
                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_Direccion", obj.Direccion);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idgenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idgenerado = 0;
                Mensaje = ex.Message;
            }

            return idgenerado;
        }

        /* PARA EDITAR DATOS */
        public bool Editar(Sucursal obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("EditarSucursal", oconexion);
                    cmd.Parameters.AddWithValue("p_Id", obj.IdSucursal);
                    cmd.Parameters.AddWithValue("p_NuevoNombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_NuevaDireccion", obj.Direccion);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }


        /*ELIMINAR DATOS*/
        public bool Eliminar(Sucursal obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("EliminarSucursal", oconexion);
                    cmd.Parameters.AddWithValue("p_Id", obj.IdSucursal);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
