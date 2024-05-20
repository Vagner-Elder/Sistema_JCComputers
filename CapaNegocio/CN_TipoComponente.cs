using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_TipoComponente
    {
        private CD_TipoComponente objcd_TipoComponente = new CD_TipoComponente();

        public List<Tipo_Componente> Listar()
        {
            return objcd_TipoComponente.Listar();
        }

        public int Registrar(Tipo_Componente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar una Tipo de Componente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_TipoComponente.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Tipo_Componente obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Tipo de Componente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_TipoComponente.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Tipo_Componente obj, out string Mensaje)
        {
            return objcd_TipoComponente.Eliminar(obj, out Mensaje);
        }
    }
}
