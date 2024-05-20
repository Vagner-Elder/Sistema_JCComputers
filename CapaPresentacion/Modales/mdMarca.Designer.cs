namespace CapaPresentacion.Modales
{
    partial class mdMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnGuardarMarca = new System.Windows.Forms.Button();
            this.txtN_Marca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(126, 8);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(21, 20);
            this.txtId.TabIndex = 9;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnGuardarMarca
            // 
            this.btnGuardarMarca.Location = new System.Drawing.Point(126, 115);
            this.btnGuardarMarca.Name = "btnGuardarMarca";
            this.btnGuardarMarca.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarMarca.TabIndex = 8;
            this.btnGuardarMarca.Text = "Guardar";
            this.btnGuardarMarca.UseVisualStyleBackColor = true;
            this.btnGuardarMarca.Click += new System.EventHandler(this.btnGuardarMarca_Click);
            // 
            // txtN_Marca
            // 
            this.txtN_Marca.Location = new System.Drawing.Point(126, 79);
            this.txtN_Marca.Name = "txtN_Marca";
            this.txtN_Marca.Size = new System.Drawing.Size(156, 20);
            this.txtN_Marca.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "INSERTAR NUEVA MARCA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre de la Marca:";
            // 
            // mdMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 199);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarMarca);
            this.Controls.Add(this.txtN_Marca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mdMarca";
            this.Text = "mdMarca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardarMarca;
        private System.Windows.Forms.TextBox txtN_Marca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}