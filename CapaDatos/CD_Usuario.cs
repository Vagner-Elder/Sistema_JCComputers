using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {

        public List<Usuario> Listar() {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena)) {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario,u.Documento,u.Nombres,u.Apellidos,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u");
                    query.AppendLine("inner join ROL r on r.IdRol = u.IdRol");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) ,Descripcion = dr["Descripcion"].ToString() }
                            });

                        }

                    }


                }
                catch (Exception ex) {

                    lista = new List<Usuario>();
                }
            }

            return lista;

        }




        public int Registrar(Usuario obj ,out string Mensaje) {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;


            try {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena)) {

                    MySqlCommand cmd = new MySqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_Documento",obj.Documento);
                    cmd.Parameters.AddWithValue("p_Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("p_Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("p_Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("p_IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
                    cmd.Parameters.Add("p_IdUsuarioResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["p_IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex) {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }



            return idusuariogenerado;
        }



        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    MySqlCommand cmd = new MySqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("p_Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("p_Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("p_Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("p_Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("p_IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("p_Estado", obj.Estado);
                    cmd.Parameters.Add("p_Respuesta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["p_Respuesta"].Value);
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


        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {


                    MySqlCommand cmd = new MySqlCommand("SP_ELIMINARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_IdUsuario", obj.IdUsuario);
                    cmd.Parameters.Add("p_Respuesta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["p_Respuesta"].Value);
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
