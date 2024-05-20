using CapaEntidad;
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

            }

        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtN_TipProducto.Text = "";
        }
    }
}
