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
    public partial class mdModelo : Form
    {
        public mdModelo()
        {
            InitializeComponent();
        }

        private void btnGuardarModelo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Modelo objModelo = new Modelo()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtN_Modelo.Text
            };

            if (objModelo.Id == 0)
            {
                int idgenerado = new CN_Modelo().Registrar(objModelo, out mensaje);
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
                bool resultado = new CN_Modelo().Editar(objModelo, out mensaje);
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
            txtN_Modelo.Text = "";
        }

        private void mdModelo_Load(object sender, EventArgs e)
        {

        }
    }
}
