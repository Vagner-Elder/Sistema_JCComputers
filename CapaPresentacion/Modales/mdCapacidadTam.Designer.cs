namespace CapaPresentacion.Modales
{
    partial class mdCapacidadTam
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
            this.btnGuardarCapTam = new System.Windows.Forms.Button();
            this.txtN_CapTam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(228, 35);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(21, 20);
            this.txtId.TabIndex = 14;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnGuardarCapTam
            // 
            this.btnGuardarCapTam.Location = new System.Drawing.Point(128, 112);
            this.btnGuardarCapTam.Name = "btnGuardarCapTam";
            this.btnGuardarCapTam.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCapTam.TabIndex = 13;
            this.btnGuardarCapTam.Text = "Guardar";
            this.btnGuardarCapTam.UseVisualStyleBackColor = true;
            this.btnGuardarCapTam.Click += new System.EventHandler(this.btnGuardarCapTam_Click);
            // 
            // txtN_CapTam
            // 
            this.txtN_CapTam.Location = new System.Drawing.Point(128, 76);
            this.txtN_CapTam.Name = "txtN_CapTam";
            this.txtN_CapTam.Size = new System.Drawing.Size(156, 20);
            this.txtN_CapTam.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "INSERTAR NUEVA CAPACIDAD ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre de la Marca:";
            // 
            // mdCapacidadTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 226);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarCapTam);
            this.Controls.Add(this.txtN_CapTam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdCapacidadTam";
            this.Text = "mdCapacidadTam";
            this.Load += new System.EventHandler(this.mdCapacidadTam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardarCapTam;
        private System.Windows.Forms.TextBox txtN_CapTam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}