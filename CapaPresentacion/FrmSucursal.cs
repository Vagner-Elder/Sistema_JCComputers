using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class FrmSucursal : Form
    {
        public FrmSucursal()
        {
            InitializeComponent();
        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            List<Sucursal> listaSucursal = new CN_Sucursal().Listar();

            foreach (Sucursal item in listaSucursal)
            {
                dgvdata.Rows.Add(new object[]
                {
                    "",
                    item.IdSucursal,
                    item.Nombre,
                    item.Direccion
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Sucursal objSucursal = new Sucursal()
            {
                IdSucursal = Convert.ToInt32(txtid.Text),
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text
            };

            if (objSucursal.IdSucursal == 0)
            {
                int idsucursalgenerada = new CN_Sucursal().Registrar(objSucursal, out mensaje);
                if (idsucursalgenerada != 0)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                        "",
                        idsucursalgenerada,
                        txtNombre.Text,
                        txtDireccion.Text
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Sucursal().Editar(objSucursal, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Direccion"].Value = txtDireccion.Text;

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDireccion.Text = dgvdata.Rows[indice].Cells["Direccion"].Value.ToString();
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la Sucursal", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Sucursal objSucursal = new Sucursal()
                    {
                        IdSucursal = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Sucursal().Eliminar(objSucursal, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }
    }
}
