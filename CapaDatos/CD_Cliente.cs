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
    public class CD_Cliente
    {

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {

                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });

                        }

                    }


                }
                catch (Exception ex)
                {

                    lista = new List<Cliente>();
                }
            }

            return lista;

        }




        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarCliente", oconexion);
                    cmd.Parameters.AddWithValue("p_Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("p_NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("p_Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }



            return idClientegenerado;
        }



        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("sp_ModificarCliente", oconexion);
                    cmd.Parameters.AddWithValue("p_IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("p_Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("p_NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("p_Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
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


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    
                    MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCliente = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
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
