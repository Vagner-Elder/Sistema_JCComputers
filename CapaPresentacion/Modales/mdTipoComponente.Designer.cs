namespace CapaPresentacion.Modales
{
    partial class mdTipoComponente
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
            this.btnGuardarTipoComp = new System.Windows.Forms.Button();
            this.txtN_TipComp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(231, 6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(21, 20);
            this.txtId.TabIndex = 14;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnGuardarTipoComp
            // 
            this.btnGuardarTipoComp.Location = new System.Drawing.Point(128, 79);
            this.btnGuardarTipoComp.Name = "btnGuardarTipoComp";
            this.btnGuardarTipoComp.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTipoComp.TabIndex = 13;
            this.btnGuardarTipoComp.Text = "Guardar";
            this.btnGuardarTipoComp.UseVisualStyleBackColor = true;
            this.btnGuardarTipoComp.Click += new System.EventHandler(this.btnGuardarTipoComp_Click);
            // 
            // txtN_TipComp
            // 
            this.txtN_TipComp.Location = new System.Drawing.Point(128, 43);
            this.txtN_TipComp.Name = "txtN_TipComp";
            this.txtN_TipComp.Size = new System.Drawing.Size(156, 20);
            this.txtN_TipComp.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "INSERTAR NUEVO TIPO DE MODELO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre de la Marca:";
            // 
            // mdTipoComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 172);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarTipoComp);
            this.Controls.Add(this.txtN_TipComp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdTipoComponente";
            this.Text = "mdTipoComponente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardarTipoComp;
        private System.Windows.Forms.TextBox txtN_TipComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}