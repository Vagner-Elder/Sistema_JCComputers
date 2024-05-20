using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class CN_CapacidadTamanio
    {
        private CD_Capacidad_Tam objcd_capacidadTam = new CD_Capacidad_Tam();

        public List<Capacidad_Tamanio> Listar()
        {
            return objcd_capacidadTam.Listar();
        }

        public int Registrar(Capacidad_Tamanio obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario ingresar una Capacidad\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_capacidadTam.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Capacidad_Tamanio obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre de la Capacidad\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_capacidadTam.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Capacidad_Tamanio obj, out string Mensaje)
        {
            return objcd_capacidadTam.Eliminar(obj, out Mensaje);
        }
    }
}
