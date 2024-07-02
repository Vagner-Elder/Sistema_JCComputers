using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using CapaPresentacion;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaPresentacion.Modales
{
    public partial class mdAct_Insert_Producto : Form
    {
        private CD_TipoProducto objc_TipoProducto = new CD_TipoProducto();
        private CD_Marca objcd_Marca = new CD_Marca();
        private CD_Modelo objcd_Modelo = new CD_Modelo();
        private CD_Capacidad_Tam objcd_CapTam = new CD_Capacidad_Tam();
        private CD_TipoComponente objcd_TipComponente = new CD_TipoComponente();
        private CD_Sucursal objc_Sucursal = new CD_Sucursal();

        private CD_Producto objcd_Producto = new CD_Producto();
        public mdAct_Insert_Producto()
        {
            InitializeComponent();
            InicializarComboBoxEstado();
        }

        private void mdAct_Insert_Producto_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
        }

        private void InicializarComboBoxEstado()
        {
            cboestado.Items.Add("Activo");
            cboestado.Items.Add("No Activo");
        }

        public void SetDatos(int Id, string Serial, string TipoProducto, string Marca, string Modelo, string Capacidad, string TipoComponente, string Stock, string PrecioCompra, string PrecioVenta, string Sucursal, string Estado, string Descripcion, string FechaRegistro)
        {
            txtid.Text = Id.ToString();
            txtcodigo.Text = Serial;

            // Selección basada en nombres
            cboTipoProducto.SelectedItem = cboTipoProducto.Items.Cast<string>().FirstOrDefault(item => item == TipoProducto);
            cboMarca.SelectedItem = cboMarca.Items.Cast<string>().FirstOrDefault(item => item == Marca);
            cboModelo.SelectedItem = cboModelo.Items.Cast<string>().FirstOrDefault(item => item == Modelo);
            cboCapacidadTamanio.SelectedItem = cboCapacidadTamanio.Items.Cast<string>().FirstOrDefault(item => item == Capacidad);
            cboTipoComponente.SelectedItem = cboTipoComponente.Items.Cast<string>().FirstOrDefault(item => item == TipoComponente);
            cboSucursal.SelectedItem = cboSucursal.Items.Cast<string>().FirstOrDefault(item => item == Sucursal);

            txtStock.Text = Stock;
            txtPrecioCompra.Text = PrecioCompra;
            txtPrecioVenta.Text = PrecioVenta;
            cboestado.SelectedItem = Estado;
            txtDescripcion.Text = Descripcion;
            dtFechaRegistro.Text = FechaRegistro;

        }

        private void CargarComboBoxes()
        {
            try
            {
                List<Tipo_Producto> TipoProducto = objc_TipoProducto.Listar();
                List<Marca> marcas = objcd_Marca.Listar();
                List<Modelo> modelos = objcd_Modelo.Listar();
                List<Capacidad_Tamanio> capacidad = objcd_CapTam.Listar();
                List<Tipo_Componente> tipoComponente = objcd_TipComponente.Listar();
                List<Sucursal> sucursales = objc_Sucursal.Listar();

                cboTipoProducto.Items.Clear();
                cboMarca.Items.Clear();
                cboModelo.Items.Clear();
                cboCapacidadTamanio.Items.Clear();
                cboTipoComponente.Items.Clear();
                cboSucursal.Items.Clear();

                cboTipoProducto.Items.AddRange(TipoProducto.Select(tp => tp.Nombre).ToArray());
                cboMarca.Items.AddRange(marcas.Select(m => m.Nombre).ToArray());
                cboModelo.Items.AddRange(modelos.Select(m => m.Nombre).ToArray());
                cboCapacidadTamanio.Items.AddRange(capacidad.Select(ct => ct.Nombre).ToArray());
                cboTipoComponente.Items.AddRange(tipoComponente.Select(tc => tc.Nombre).ToArray());
                cboSucursal.Items.AddRange(sucursales.Select(s => s.Nombre).ToArray());

                cboTipoProducto.SelectedIndex = -1;
                cboMarca.SelectedIndex = -1;
                cboModelo.SelectedIndex = -1;
                cboCapacidadTamanio.SelectedIndex = -1;
                cboTipoComponente.SelectedIndex = -1;
                cboSucursal.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ConvertirEstadoATexto(string estado)
        {
            return estado == "Activo" ? 1 : 0;
        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los controles del formulario
                string codigo = txtcodigo.Text;
                int idTipoProducto = objc_TipoProducto.ObtenerIdPorNombre(cboTipoProducto.SelectedItem.ToString()); // Debes implementar el método en CD_TipoProducto
                int idMarca = objcd_Marca.ObtenerIdPorNombre(cboMarca.SelectedItem.ToString()); // Debes implementar el método en CD_Marca
                int idModelo = objcd_Modelo.ObtenerIdPorNombre(cboModelo.SelectedItem.ToString()); // Debes implementar el método en CD_Modelo
                int idCapacidadTamano = objcd_CapTam.ObtenerIdPorNombre(cboCapacidadTamanio.SelectedItem.ToString()); // Debes implementar el método en CD_Capacidad_Tam
                int idTipoComponente = objcd_TipComponente.ObtenerIdPorNombre(cboTipoComponente.SelectedItem.ToString()); // Debes implementar el método en CD_TipoComponente
                int stock = Convert.ToInt32(txtStock.Text);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                int idSucursal = objc_Sucursal.ObtenerIdPorNombre(cboSucursal.SelectedItem.ToString()); // Debes implementar el método en CD_Sucursal
                int estado = ConvertirEstadoATexto(cboestado.SelectedItem.ToString()); // Utiliza el método ConvertirEstadoATexto existente
                string descripcion = txtDescripcion.Text;

                // Llamar al método de la capa de negocio para registrar el producto
                string mensaje;
                int resultado = objcd_Producto.RegistrarProducto(codigo, idTipoProducto, idMarca, idModelo, idCapacidadTamano, idTipoComponente, stock, precioCompra, precioVenta, idSucursal, estado, descripcion, out mensaje);

                if (resultado > 0)
                {
                    MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Puedes agregar aquí lógica adicional como limpiar el formulario o cerrarlo
                }
                else
                {
                    MessageBox.Show("Error al registrar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
