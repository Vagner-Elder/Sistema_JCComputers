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
        private formProductoAct _formProductoAct;
        public mdAct_Insert_Producto( formProductoAct form)
        {
            InitializeComponent();
            InicializarComboBoxEstado();
            _formProductoAct = form;
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
            string mensaje;

            try
            {
                int idProducto = Convert.ToInt32(txtid.Text);
                string codigo = txtcodigo.Text;
                int idTipoProducto = objc_TipoProducto.ObtenerIdPorNombre(cboTipoProducto.SelectedItem.ToString()); 
                int idMarca = objcd_Marca.ObtenerIdPorNombre(cboMarca.SelectedItem.ToString()); 
                int idModelo = objcd_Modelo.ObtenerIdPorNombre(cboModelo.SelectedItem.ToString()); 
                int idCapacidadTamano = objcd_CapTam.ObtenerIdPorNombre(cboCapacidadTamanio.SelectedItem.ToString()); 
                int idTipoComponente = objcd_TipComponente.ObtenerIdPorNombre(cboTipoComponente.SelectedItem.ToString()); 
                int stock = Convert.ToInt32(txtStock.Text);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                int idSucursal = objc_Sucursal.ObtenerIdPorNombre(cboSucursal.SelectedItem.ToString()); 
                int estado = ConvertirEstadoATexto(cboestado.SelectedItem.ToString()); 
                string descripcion = txtDescripcion.Text;


                // int resultado = objcd_Producto.RegistrarProducto(codigo, idTipoProducto, idMarca, idModelo, idCapacidadTamano, idTipoComponente, stock, precioCompra, precioVenta, idSucursal, estado, descripcion, out mensaje);
                int resultado;

                if (idProducto == 0)
                {
                    resultado = objcd_Producto.RegistrarProducto(codigo, idTipoProducto, idMarca, idModelo, idCapacidadTamano, idTipoComponente, stock, precioCompra, precioVenta, idSucursal, estado, descripcion, out mensaje);
                   
                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        this.Close();
                        _formProductoAct.ActualizarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el producto: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    resultado = objcd_Producto.EditarProducto(idProducto, codigo, idTipoProducto, idMarca, idModelo, idCapacidadTamano, idTipoComponente, stock, precioCompra, precioVenta, idSucursal, estado, descripcion, out mensaje);
                    
                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        this.Close();
                        _formProductoAct.ActualizarDataGridView();

                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el producto: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtDescripcion.Text = "";

            cboTipoComponente.Items.Clear();
            cboMarca.Items.Clear();
            cboModelo.Items.Clear();
            cboCapacidadTamanio.Items.Clear();
            cboTipoProducto.Items.Clear();
            cboestado.Items.Clear();
            cboSucursal.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (mdMarca form_Marca = new mdMarca())
            {
                if(form_Marca.ShowDialog() == DialogResult.OK)
                {
                    CargarComboBoxes();
                    cboMarca.SelectedIndex = cboMarca.Items.Count - 1;
                }
            }
        }

        private void btn_new_nombpro_Click(object sender, EventArgs e)
        {
            using (mdTipo_Producto form_Tipo_Producto = new mdTipo_Producto())
            {
                if (form_Tipo_Producto.ShowDialog() == DialogResult.OK)
                {
                    CargarComboBoxes();
                    cboTipoProducto.SelectedIndex = cboTipoProducto.Items.Count - 1;
                }
            }
        }

        private void btn_new_modelo_Click(object sender, EventArgs e)
        {
            using (mdModelo form = new mdModelo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarComboBoxes();
                    cboModelo.SelectedIndex = cboModelo.Items.Count - 1;
                }
            }
        }

        private void btn_new_capacidad_Click(object sender, EventArgs e)
        {
            using (mdCapacidadTam form = new mdCapacidadTam())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarComboBoxes();
                    cboCapacidadTamanio.SelectedIndex = cboCapacidadTamanio.Items.Count - 1;
                }
            }
        }

        private void btn_new_tipocop_Click(object sender, EventArgs e)
        {
            using (mdTipoComponente form = new mdTipoComponente())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarComboBoxes();
                    cboTipoComponente.SelectedIndex = cboTipoComponente.Items.Count - 1;
                }
            }
        }
    }
}

