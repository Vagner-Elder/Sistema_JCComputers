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

namespace CapaPresentacion.Modales
{
    public partial class mdProducto : Form
    {
        public Producto _Producto { get; set; }

        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {

                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Producto> lista = new CN__Producto().Listar();

            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.TipoProducto.Nombre,
                    item.Marca.Nombre,
                    item.Modelo.Nombre,
                    item.CapacidadTamano.Nombre,
                    item.TipoComponente.Nombre,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta
                });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),

                    TipoProducto = new Tipo_Producto()
                    {
                        Nombre = dgvdata.Rows[iRow].Cells["Producto"].Value.ToString()
                    },

                    Marca = new Marca()
                    {
                        Nombre = dgvdata.Rows[iRow].Cells["Marca"].Value.ToString()
                    },

                    Modelo = new Modelo()
                    {
                        Nombre = dgvdata.Rows[iRow].Cells["Modelo"].Value.ToString()
                    },

                    CapacidadTamano = new Capacidad_Tamanio()
                    {
                        Nombre = dgvdata.Rows[iRow].Cells["Capacidad"].Value.ToString()
                    },

                    TipoComponente = new Tipo_Componente()
                    {
                        Nombre = dgvdata.Rows[iRow].Cells["TipoComponente"].Value.ToString()
                    },

                    Stock = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
