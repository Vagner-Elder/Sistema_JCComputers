using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Modelo
    {
        private CD_Modelo objcd_modelo = new CD_Modelo();

        public List<Modelo> Listar()
        {
            return objcd_modelo.Listar();
        }

        public int Registrar(Modelo obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar un Modelo\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_modelo.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Modelo obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Modelo\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_modelo.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Modelo obj, out string Mensaje)
        {
            return objcd_modelo.Eliminar(obj, out Mensaje);
        }
    }
}
