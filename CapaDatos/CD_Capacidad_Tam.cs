using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CD_Capacidad_Tam
    {
        public List<Capacidad_Tamanio> Listar()
        {
            List<Capacidad_Tamanio> lista = new List<Capacidad_Tamanio>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Capacidad_Tamanio;");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Capacidad_Tamanio
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Capacidad_Tamanio>();
                }
            }

            return lista;
        }


        /*PARA REGISTRAR DATOS*/

        public int Registrar(Capacidad_Tamanio obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("InsertarCapacidad_Tamanio", oconexion);
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
        public bool Editar(Capacidad_Tamanio obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("EditarCapacidad_Tamanio", oconexion);
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
        public bool Eliminar(Capacidad_Tamanio obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("EliminarCapacidad_Tamanio", oconexion);
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

        public int ObtenerIdPorNombre(string nombre)
        {
            int id = 0;
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT Id FROM Capacidad_Tamanio WHERE Nombre = @Nombre";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);

                    oconexion.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return id;
        }

    }
}
