namespace CapaPresentacion.Modales
{
    partial class mdTipo_Producto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtN_TipProducto = new System.Windows.Forms.TextBox();
            this.btnGuardarTP = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "INSERTAR NUEVO  TIPO DE PRODUCTO";
            // 
            // txtN_TipProducto
            // 
            this.txtN_TipProducto.Location = new System.Drawing.Point(146, 74);
            this.txtN_TipProducto.Name = "txtN_TipProducto";
            this.txtN_TipProducto.Size = new System.Drawing.Size(156, 20);
            this.txtN_TipProducto.TabIndex = 2;
            // 
            // btnGuardarTP
            // 
            this.btnGuardarTP.Location = new System.Drawing.Point(146, 110);
            this.btnGuardarTP.Name = "btnGuardarTP";
            this.btnGuardarTP.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTP.TabIndex = 3;
            this.btnGuardarTP.Text = "Guardar";
            this.btnGuardarTP.UseVisualStyleBackColor = true;
            this.btnGuardarTP.Click += new System.EventHandler(this.btnGuardarTP_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(146, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(21, 20);
            this.txtId.TabIndex = 4;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // mdTipo_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 187);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarTP);
            this.Controls.Add(this.txtN_TipProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdTipo_Producto";
            this.Text = "mdTipo_Producto";
            this.Load += new System.EventHandler(this.mdTipo_Producto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtN_TipProducto;
        private System.Windows.Forms.Button btnGuardarTP;
        private System.Windows.Forms.TextBox txtId;
    }
}