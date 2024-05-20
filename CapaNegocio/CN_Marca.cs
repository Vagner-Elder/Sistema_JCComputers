using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Marca
    {
        private CD_Marca objcd_marca = new CD_Marca();

        public List<Marca> Listar()
        {
            return objcd_marca.Listar();
        }

        public int Registrar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar una Marca\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_marca.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Marca obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre de la Marca\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_marca.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Marca obj, out string Mensaje)
        {
            return objcd_marca.Eliminar(obj, out Mensaje);
        }
    }
}
