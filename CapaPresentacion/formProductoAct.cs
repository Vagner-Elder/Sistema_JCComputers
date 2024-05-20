using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class formProductoAct : Form
    {
        public formProductoAct()
        {
            InitializeComponent();
        }

        private void formProductoAct_Load(object sender, EventArgs e)
        {



            //MOSTRAR TODOS LOS PRODUCTOS

            List<Producto> lista = new CN__Producto().Listar();
            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[]
                {
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.TipoProducto.Nombre,
                    item.Marca.Nombre,
                    item.Modelo.Nombre,
                    item.CapacidadTamano.Nombre,
                    item.TipoComponente.Nombre,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Sucursal.Nombre,
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Descripcion,
                    item.FechaRegistro
                });
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

    

        private void dgvdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //{
            //    int idProducto = (int)dgvdata.Rows[e.RowIndex].Cells["Id"].Value;
            //    string codigo = dgvdata.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
            //    string tipoProducto = dgvdata.Rows[e.RowIndex].Cells["NomProducto"].Value.ToString();
            //    string marca = dgvdata.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            //    string modelo = dgvdata.Rows[e.RowIndex].Cells["Modelo"].Value.ToString();
            //    string capacidadTamano = dgvdata.Rows[e.RowIndex].Cells["Capacidad"].Value.ToString();
            //    string tipoComponente = dgvdata.Rows[e.RowIndex].Cells["TipoComponente"].Value.ToString();
            //    string stock = dgvdata.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
            //    string precioCompra = dgvdata.Rows[e.RowIndex].Cells["PrecioCompra"].Value.ToString();
            //    string precioVenta = dgvdata.Rows[e.RowIndex].Cells["PrecioVenta"].Value.ToString();
            //    string sucursal = dgvdata.Rows[e.RowIndex].Cells["Sucursal"].Value.ToString();
            //    string estado = dgvdata.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
            //    string descripcion = dgvdata.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            //    string fechaRegistro = dgvdata.Rows[e.RowIndex].Cells["FechaRegistro"].Value.ToString();

            //    mdAct_Insert_Producto form = new mdAct_Insert_Producto();
            //    form.SetDatos(idProducto, codigo, tipoProducto, marca, modelo, capacidadTamano, tipoComponente, stock, precioCompra, precioVenta, sucursal, estado, descripcion, fechaRegistro);
            //    form.Show();
            //}
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                Producto productoSeleccionado = (Producto)dgvdata.Rows[e.RowIndex].DataBoundItem; // Obtener el objeto Producto de la fila
                if (productoSeleccionado != null)
                {
                    mdAct_Insert_Producto form = new mdAct_Insert_Producto();
                    form.SetDatos(productoSeleccionado.IdProducto,
                                  productoSeleccionado.Codigo,
                                  productoSeleccionado.TipoProducto.Nombre,  // Nombre de la propiedad relacionada
                                  productoSeleccionado.Marca.Nombre,
                                  productoSeleccionado.Modelo.Nombre,
                                  productoSeleccionado.CapacidadTamano.Nombre,
                                  productoSeleccionado.TipoComponente.Nombre,
                                  productoSeleccionado.Stock.ToString(),
                                  productoSeleccionado.PrecioCompra.ToString(),
                                  productoSeleccionado.PrecioVenta.ToString(),
                                  productoSeleccionado.Sucursal.Nombre,
                                  productoSeleccionado.Estado == true ? "Activo" : "No Activo",
                                  productoSeleccionado.Descripcion,
                                  productoSeleccionado.FechaRegistro.ToString());
                    form.Show();
                }
                else
                {
                    // Mensaje de error en caso de no obtener el producto
                    MessageBox.Show("No se pudo obtener el producto seleccionado");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mdAct_Insert_Producto frm = new mdAct_Insert_Producto();
            frm.ShowDialog();
        }
    }
}