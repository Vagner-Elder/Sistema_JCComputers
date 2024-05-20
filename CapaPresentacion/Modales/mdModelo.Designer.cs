namespace CapaPresentacion.Modales
{
    partial class mdModelo
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
            this.btnGuardarModelo = new System.Windows.Forms.Button();
            this.txtN_Modelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(275, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(21, 20);
            this.txtId.TabIndex = 14;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnGuardarModelo
            // 
            this.btnGuardarModelo.Location = new System.Drawing.Point(128, 98);
            this.btnGuardarModelo.Name = "btnGuardarModelo";
            this.btnGuardarModelo.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarModelo.TabIndex = 13;
            this.btnGuardarModelo.Text = "Guardar";
            this.btnGuardarModelo.UseVisualStyleBackColor = true;
            this.btnGuardarModelo.Click += new System.EventHandler(this.btnGuardarModelo_Click);
            // 
            // txtN_Modelo
            // 
            this.txtN_Modelo.Location = new System.Drawing.Point(128, 62);
            this.txtN_Modelo.Name = "txtN_Modelo";
            this.txtN_Modelo.Size = new System.Drawing.Size(156, 20);
            this.txtN_Modelo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "INSERTAR NUEVO MODELO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre de la Marca:";
            // 
            // mdModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 173);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarModelo);
            this.Controls.Add(this.txtN_Modelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdModelo";
            this.Text = "mdModelo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardarModelo;
        private System.Windows.Forms.TextBox txtN_Modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}