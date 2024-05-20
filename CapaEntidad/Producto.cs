using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public Tipo_Producto TipoProducto { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public Capacidad_Tamanio CapacidadTamano { get; set; }
        public Tipo_Componente TipoComponente { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public Sucursal Sucursal { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }


        //public int IdProducto { get; set; }
        //public string Codigo { get; set; }
        //public string TipoProducto { get; set; }
        //public string Marca { get; set; }
        //public string Modelo { get; set; }
        //public string CapacidadTamano { get; set; }
        //public string TipoComponente { get; set; }
        //public int Stock { get; set; }
        //public decimal PrecioCompra { get; set; }
        //public decimal PrecioVenta { get; set; }
        //public string Sucursal { get; set; }
        //public bool Estado { get; set; }
        //public string Descripcion { get; set; }
        //public DateTime FechaRegistro { get; set; }
    }
}
