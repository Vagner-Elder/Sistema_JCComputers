using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEntidad;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol,Descripcion from ROL");
      
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Rol>();
                }
            }

            return lista;

        }


    }
}
