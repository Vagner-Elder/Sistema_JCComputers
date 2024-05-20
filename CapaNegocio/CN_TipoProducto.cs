using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_TipoProducto
    {
        private CD_TipoProducto objcd_tipoproducto = new CD_TipoProducto(); 

        public List<Tipo_Producto> Listar()
        {
            return objcd_tipoproducto.Listar();
        }

        public int Registrar(Tipo_Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if(obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar un Tipo de Producto\n";
            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_tipoproducto.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Tipo_Producto obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_tipoproducto.Editar(obj, out Mensaje);
            }


        }


        public bool Eliminar(Tipo_Producto obj, out string Mensaje)
        {
            return objcd_tipoproducto.Eliminar(obj, out Mensaje);
        }
    }
}
