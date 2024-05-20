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
        public mdAct_Insert_Producto()
        {
            InitializeComponent();
        }

        private void mdAct_Insert_Producto_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
        }


        public void SetDatos(int Id, string Serial, string TipoProducto, string Marca, string Modelo, string Capacidad, string TipoComponente, string Stock, string PrecioCompra, string PrecioVenta, string Sucursal, string Estado, string Descripcion, string FechaRegistro)
        {
            txtid.Text = Id.ToString();
            txtcodigo.Text = Serial.ToString();
            cboTipoProducto.Text = TipoProducto.ToString();
            cboMarca.Text = Marca.ToString();
            cboModelo.Text = Modelo.ToString();
            cboCapacidadTamanio.Text = Capacidad.ToString();
            cboTipoComponente.Text = TipoComponente.ToString();
            cboTipoComponente.SelectedValue = TipoComponente.ToString();
            txtStock.Text = Stock.ToString();
            txtPrecioCompra.Text = PrecioCompra.ToString();
            txtPrecioVenta.Text = PrecioVenta.ToString();
            cboSucursal.Text = Sucursal.ToString();
            cboestado.Text = Estado.ToString();
            txtDescripcion.Text = Descripcion.ToString();
            dtFechaRegistro.Text = FechaRegistro.ToString();

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

                foreach (Tipo_Producto tipoProducto in TipoProducto)
                {
                    cboTipoProducto.Items.Add(tipoProducto.Nombre);
                }
                if (cboTipoProducto.Items.Count > 0)
                {
                    cboTipoProducto.SelectedIndex = 0;
                }

                foreach (Marca marca in marcas)
                {
                    cboMarca.Items.Add(marca.Nombre);
                }
                if (cboMarca.Items.Count > 0)
                {
                    cboMarca.SelectedIndex = 0;
                }


                foreach (Modelo modelo in modelos)
                {
                    cboModelo.Items.Add(modelo.Nombre);
                }
                if (cboModelo.Items.Count > 0)
                {
                    cboModelo.SelectedIndex = 0;
                }


                foreach (Capacidad_Tamanio capTam in capacidad)
                {
                    cboCapacidadTamanio.Items.Add(capTam.Nombre);
                }
                if (cboCapacidadTamanio.Items.Count > 0)
                {
                    cboCapacidadTamanio.SelectedIndex = 0;
                }


                foreach (Tipo_Componente tipcompo in tipoComponente)
                {
                    cboTipoComponente.Items.Add(tipcompo.Nombre);
                }
                if (cboTipoComponente.Items.Count > 0)
                {
                    cboTipoComponente.SelectedIndex = 0;
                }

                foreach (Sucursal sucursal in sucursales)
                {
                    cboSucursal.Items.Add(sucursal.Nombre);
                }
                if (cboSucursal.Items.Count > 0)
                {
                    cboSucursal.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
