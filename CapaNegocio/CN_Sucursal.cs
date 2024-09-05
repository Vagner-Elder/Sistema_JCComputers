using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Sucursal
    {
        private CD_Sucursal objcd_Sucursal = new CD_Sucursal();

        public List<Sucursal> Listar()
        {
            return objcd_Sucursal.Listar();
        }

        public int Registrar(Sucursal obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar una Sucursal\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Sucursal.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Sucursal obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre de la Sucursal\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Sucursal.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Sucursal obj, out string Mensaje)
        {
            return objcd_Sucursal.Eliminar(obj, out Mensaje);
        }

        public List<Sucursal> ListarActivos()
        {
            return objcd_Sucursal.Listar().Where(s => s.Estado).ToList();
        }

    }
}
