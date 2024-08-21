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

        }
    }
}
