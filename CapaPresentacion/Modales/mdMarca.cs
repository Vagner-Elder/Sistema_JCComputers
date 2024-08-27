using CapaEntidad;
using CapaNegocio;
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

using CapaPresentacion.Modales;

namespace CapaPresentacion.Modales
{
    public partial class mdMarca : Form
    {
        public mdMarca()
        {
            InitializeComponent();
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Marca objMarca = new Marca()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtN_Marca.Text
            };

            if (objMarca.Id == 0)
            {
                int idgenerado = new CN_Marca().Registrar(objMarca, out mensaje);
                if (idgenerado != 0)
                {
                    MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar();
            }
            else
            {
                bool resultado = new CN_Marca().Editar(objMarca, out mensaje);
                if (resultado)
                {
                    MessageBox.Show("Actualización Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtN_Marca.Text = "";
        }

        private void mdMarca_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;

            List<Marca> lista = new CN_Marca().Listar();
            foreach (Marca item in lista)
            {
                dgv_Marca.Rows.Add(new object[]
                {
                    "",
                    item.Id,
                    item.Nombre
                });
            }
        }

        private void dgv_Marca_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgv_Marca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                txtId.Text = dgv_Marca.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtN_Marca.Text = dgv_Marca.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                btnEliminar.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                Marca objMarca = new Marca()
                {
                    Id = Convert.ToInt32(txtId.Text)
                };

                string mensaje;
                bool resultado = new CN_Marca().Eliminar(objMarca, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Eliminado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    btnEliminar.Enabled = false;
                    dgv_Marca.Rows.Clear();

                    List<Marca> lista = new CN_Marca().Listar();
                    foreach (Marca item in lista)
                    {
                        dgv_Marca.Rows.Add(new object[]
                        {
                    "",
                    item.Id,
                    item.Nombre
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Error al Eliminar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una marca para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
