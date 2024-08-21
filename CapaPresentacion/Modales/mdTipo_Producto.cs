﻿using CapaEntidad;
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

namespace CapaPresentacion.Modales
{
    public partial class mdTipo_Producto : Form
    {
        public mdTipo_Producto()
        {
            InitializeComponent();
        }

        private void mdTipo_Producto_Load(object sender, EventArgs e)
        {
            //Mostrar las Marcas
            List<Tipo_Producto> lista = new CN_TipoProducto().Listar();
            foreach (Tipo_Producto item in lista)
            {
                dgv_Tipo_Producto.Rows.Add(new object[]
                {
                    "",
                    item.Id,
                    item.Nombre
                });
            }
        }

        private void btnGuardarTP_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Tipo_Producto objTipoProducto = new Tipo_Producto()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtN_TipProducto.Text
            };

            if(objTipoProducto.Id == 0)
            {
                int idgenerado = new CN_TipoProducto().Registrar(objTipoProducto, out mensaje);
                if(idgenerado != 0)
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
                bool resultado = new CN_TipoProducto().Editar(objTipoProducto, out mensaje);
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
            txtN_TipProducto.Text = "";
        }

        private void dgv_Tipo_Producto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
