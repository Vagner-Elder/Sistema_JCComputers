using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN__Producto
    {


        private CD_Producto objcd_Producto = new CD_Producto();


        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }

        public int RegistrarProducto(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones u otra lógica antes de registrar el producto
            // ...
            //if (obj.Codigo == "")
            //    //{
            //    //    Mensaje += "Es necesario el codigo del Producto\n";
            //    //}

            int resultado = objcd_Producto.RegistrarProducto(obj.Codigo, obj.TipoProducto.Id, obj.Marca.Id, obj.Modelo.Id, obj.CapacidadTamano.Id, obj.TipoComponente.Id, obj.Stock, obj.PrecioCompra, obj.PrecioVenta, obj.Sucursal.IdSucursal, obj.Estado ? 1 : 0, obj.Descripcion, out Mensaje);

            if (resultado > 0)
            {
                Mensaje = "Producto registrado correctamente.";
            }
            else
            {
                Mensaje = "Error al registrar el producto.";
            }

            return resultado;
        }



        //public bool Editar(Producto obj, out string Mensaje)
        //{

        //    Mensaje = string.Empty;


        //    if (obj.Codigo == "")
        //    {
        //        Mensaje += "Es necesario el codigo del Producto\n";
        //    }

        //    if (obj.Nombre == "")
        //    {
        //        Mensaje += "Es necesario el nombre del Producto\n";
        //    }

        //    if (obj.Descripcion == "")
        //    {
        //        Mensaje += "Es necesario la Descripcion del Producto\n";
        //    }

        //    if (Mensaje != string.Empty)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return objcd_Producto.Editar(obj, out Mensaje);
        //    }
        //}


        //public bool Eliminar(Producto obj, out string Mensaje)
        //{
        //    return objcd_Producto.Eliminar(obj, out Mensaje);
        //}
    }
}
