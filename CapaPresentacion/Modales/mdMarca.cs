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


            }
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtN_Marca.Text = "";
        }
    }
}
