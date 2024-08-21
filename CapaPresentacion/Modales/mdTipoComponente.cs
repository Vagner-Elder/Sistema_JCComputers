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
    public partial class mdTipoComponente : Form
    {
        public mdTipoComponente()
        {
            InitializeComponent();
        }

        private void btnGuardarTipoComp_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Tipo_Componente objTipoComp = new Tipo_Componente()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtN_TipComp.Text
            };

            if (objTipoComp.Id == 0)
            {
                int idgenerado = new CN_TipoComponente().Registrar(objTipoComp, out mensaje);
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
                bool resultado = new CN_TipoComponente().Editar(objTipoComp, out mensaje);
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
            txtN_TipComp.Text = "";
        }

        private void mdTipoComponente_Load(object sender, EventArgs e)
        {

        }
    }
}
