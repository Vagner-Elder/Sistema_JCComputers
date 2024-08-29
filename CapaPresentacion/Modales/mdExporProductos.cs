using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using CapaPresentacion;

namespace CapaPresentacion.Modales
{
    public partial class mdExporProductos : Form
    {

        private DataGridView dgvdata;
        public mdExporProductos()
        {
            InitializeComponent();
            this.dgvdata = dgvdata;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //if (dgvdata.Rows.Count < 1)
            //{
            //    MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //// Define las columnas que deseas exportar y el orden
            //var columnasExportar = new List<string> { "Serial", "Id_Tipo_Producto", "Id_Marca", "Id_Modelo", "Stock", "PrecioVenta", "Id_Sucursal", "Estado", "Descripcion" };

            //try
            //{
            //    DataTable dt = new DataTable();

            //    // Agrega las columnas específicas al DataTable
            //    foreach (string colNombre in columnasExportar)
            //    {
            //        if (dgvdata.Columns[colNombre] != null)
            //        {
            //            dt.Columns.Add(dgvdata.Columns[colNombre].HeaderText, typeof(string));
            //        }
            //    }

            //    // Agrega las filas al DataTable
            //    foreach (DataGridViewRow row in dgvdata.Rows)
            //    {
            //        if (!row.IsNewRow && row.Visible) // Asegúrate de no incluir la fila de nueva fila
            //        {
            //            var cellValues = new object[dt.Columns.Count];
            //            for (int i = 0; i < dt.Columns.Count; i++)
            //            {
            //                // Encuentra el índice de la columna en el DataGridView
            //                string colName = columnasExportar[i];
            //                cellValues[i] = row.Cells[colName]?.Value?.ToString() ?? string.Empty;
            //            }
            //            dt.Rows.Add(cellValues);
            //        }
            //    }

            //    // Muestra el diálogo para guardar el archivo
            //    using (SaveFileDialog savefile = new SaveFileDialog())
            //    {
            //        savefile.FileName = $"ReporteProducto_{DateTime.Now:ddMMyyyyHHmmss}.xlsx";
            //        savefile.Filter = "Excel Files|*.xlsx";

            //        if (savefile.ShowDialog() == DialogResult.OK)
            //        {
            //            // Crea y guarda el archivo Excel
            //            using (XLWorkbook wb = new XLWorkbook())
            //            {
            //                wb.Worksheets.Add(dt, "Informe");
            //                wb.SaveAs(savefile.FileName);
            //            }

            //            MessageBox.Show("Reporte generado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Manejo de errores
            //    MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}


            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Lista para almacenar los nombres de las columnas seleccionadas
            var columnasExportar = new List<string>();

            // Verifica qué CheckBox están seleccionados y añade las columnas correspondientes
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    columnasExportar.Add(checkBox.Text); // Usa el texto del CheckBox como nombre de la columna
                }
            }

            if (columnasExportar.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una columna para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                DataTable dt = new DataTable();

                // Agrega las columnas seleccionadas al DataTable
                foreach (string colNombre in columnasExportar)
                {
                    if (dgvdata.Columns[colNombre] != null)
                    {
                        dt.Columns.Add(dgvdata.Columns[colNombre].HeaderText, typeof(string));
                    }
                }

                // Agrega las filas al DataTable
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (!row.IsNewRow && row.Visible) // Asegúrate de no incluir la fila de nueva fila
                    {
                        var cellValues = new object[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            // Encuentra el índice de la columna en el DataGridView
                            string colName = columnasExportar[i];
                            cellValues[i] = row.Cells[colName]?.Value?.ToString() ?? string.Empty;
                        }
                        dt.Rows.Add(cellValues);
                    }
                }

                // Muestra el diálogo para guardar el archivo
                using (SaveFileDialog savefile = new SaveFileDialog())
                {
                    savefile.FileName = $"ReporteProducto_{DateTime.Now:ddMMyyyyHHmmss}.xlsx";
                    savefile.Filter = "Excel Files|*.xlsx";

                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        // Crea y guarda el archivo Excel
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Informe");
                            wb.SaveAs(savefile.FileName);
                        }

                        MessageBox.Show("Reporte generado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
    }
}
