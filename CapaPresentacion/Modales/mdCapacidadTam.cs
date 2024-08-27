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

namespace CapaPresentacion.Modales
{
    public partial class mdCapacidadTam : Form
    {
        public mdCapacidadTam()
        {
            InitializeComponent();
        }

        private void btnGuardarCapTam_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Capacidad_Tamanio objCapacidadTam = new Capacidad_Tamanio()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtN_CapTam.Text
            };

            if (objCapacidadTam.Id == 0)
            {
                int idgenerado = new CN_CapacidadTamanio().Registrar(objCapacidadTam, out mensaje);
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
                bool resultado = new CN_CapacidadTamanio().Editar(objCapacidadTam, out mensaje);
                if (resultado)
                {
                    MessageBox.Show("Actualización exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtN_CapTam.Text = "";
        }

        private void mdCapacidadTam_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;

            List<Capacidad_Tamanio> lista = new CN_CapacidadTamanio().Listar();
            foreach (Capacidad_Tamanio item in lista)
            {
                dgv_CapaTam.Rows.Add(new object[]
                {
                    "",
                    item.Id,
                    item.Nombre
                });
            }
        }

        private void dgv_CapaTam_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgv_CapaTam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                txtId.Text = dgv_CapaTam.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtN_CapTam.Text = dgv_CapaTam.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

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
                Capacidad_Tamanio objCapTam = new Capacidad_Tamanio()
                {
                    Id = Convert.ToInt32(txtId.Text)
                };

                string mensaje;
                bool resultado = new CN_CapacidadTamanio().Eliminar(objCapTam, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Eliminado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    btnEliminar.Enabled = false;
                    dgv_CapaTam.Rows.Clear();

                    List<Capacidad_Tamanio> lista = new CN_CapacidadTamanio().Listar();
                    foreach (Capacidad_Tamanio item in lista)
                    {
                        dgv_CapaTam.Rows.Add(new object[]
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
                MessageBox.Show("Por favor, seleccione un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
