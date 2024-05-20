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
    public class CD_Marca
    {
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Marca;");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Marca
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Marca>();
                }
            }

            return lista;
        }


        /*PARA REGISTRAR DATOS*/

        public int Registrar(Marca obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("InsertarMarca", oconexion);
                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
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
        public bool Editar(Marca obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("EditarMarca", oconexion);
                    cmd.Parameters.AddWithValue("p_Id", obj.Id);
                    cmd.Parameters.AddWithValue("p_NuevoNombre", obj.Nombre);
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
        public bool Eliminar(Marca obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("EliminarMarca", oconexion);
                    cmd.Parameters.AddWithValue("p_Id", obj.Id);
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
