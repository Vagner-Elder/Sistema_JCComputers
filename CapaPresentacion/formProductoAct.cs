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
using System.Web;
using CapaDatos;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;

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
            cbobusqueda.Items.Add(new { Text = "Serial", Value = "Serial" });
            cbobusqueda.Items.Add(new { Text = "Producto", Value = "Producto" });
            cbobusqueda.Items.Add(new { Text = "Marca", Value = "Marca" });
            cbobusqueda.Items.Add(new { Text = "Modelo", Value = "Modelo" });
            cbobusqueda.DisplayMember = "Text";
            cbobusqueda.ValueMember = "Value";
            cbobusqueda.SelectedIndex = 0;

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

            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = Properties.Resources.check20.Width;
            var h = Properties.Resources.check20.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
            e.Handled = true;
        }

    

        private void dgvdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                int idProducto = (int)dgvdata.Rows[e.RowIndex].Cells["Id"].Value;
                string codigo = dgvdata.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                string tipoProducto = dgvdata.Rows[e.RowIndex].Cells["NomProducto"].Value.ToString();
                string marca = dgvdata.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
                string modelo = dgvdata.Rows[e.RowIndex].Cells["Modelo"].Value.ToString();
                string capacidadTamano = dgvdata.Rows[e.RowIndex].Cells["Capacidad"].Value.ToString();
                string tipoComponente = dgvdata.Rows[e.RowIndex].Cells["TipoComponente"].Value.ToString();
                string stock = dgvdata.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                string precioCompra = dgvdata.Rows[e.RowIndex].Cells["PrecioCompra"].Value.ToString();
                string precioVenta = dgvdata.Rows[e.RowIndex].Cells["PrecioVenta"].Value.ToString();
                string sucursal = dgvdata.Rows[e.RowIndex].Cells["Sucursal"].Value.ToString();
                string estado = dgvdata.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                string descripcion = dgvdata.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                string fechaRegistro = dgvdata.Rows[e.RowIndex].Cells["FechaRegistro"].Value.ToString();

                mdAct_Insert_Producto form = new mdAct_Insert_Producto(this);
                form.Show();
                form.SetDatos(idProducto, codigo, tipoProducto, marca, modelo, capacidadTamano, tipoComponente, stock, precioCompra, precioVenta, sucursal, estado, descripcion, fechaRegistro);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mdAct_Insert_Producto frm = new mdAct_Insert_Producto(this);
            frm.ShowDialog();
        }

        public void ActualizarDataGridView()
        {
            dgvdata.Rows.Clear(); // Limpiar las filas actuales

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

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string criterio = ((dynamic)cbobusqueda.SelectedItem).Value;
            string valor = txtbusqueda.Text.Trim();

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.cadena))
            {
                oConexion.Open();
                using (MySqlCommand cmd = new MySqlCommand("BuscarProducto", oConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("criterio", criterio);
                    cmd.Parameters.AddWithValue("valor", valor);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvdata.Rows.Clear();
                        while (reader.Read())
                        {
                            dgvdata.Rows.Add(new object[]
                            {
                                "",
                                reader["IdProducto"],
                                reader["Codigo"],
                                reader["TipoProducto"],
                                reader["Marca"],
                                reader["Modelo"],
                                reader["CapacidadTamano"],
                                reader["TipoComponente"],
                                reader["Stock"],
                                reader["PrecioCompra"],
                                reader["PrecioVenta"],
                                reader["Sucursal"],
                                reader["Estado"].ToString() == "1" ? "Activo" : "No Activo",
                                reader["Descripcion"],
                                reader["FechaRegistro"]
                            });
                        }
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            ActualizarDataGridView();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            mdExporProductos form = new mdExporProductos();
            form.ShowDialog();
        }

    }
}