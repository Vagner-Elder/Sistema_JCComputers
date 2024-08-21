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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtN_TipProducto = new System.Windows.Forms.TextBox();
            this.btnGuardarTP = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dgv_Tipo_Producto = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Producto)).BeginInit();
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
            this.btnGuardarTP.Location = new System.Drawing.Point(329, 72);
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
            // dgv_Tipo_Producto
            // 
            this.dgv_Tipo_Producto.AllowUserToAddRows = false;
            this.dgv_Tipo_Producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tipo_Producto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Nombre});
            this.dgv_Tipo_Producto.Location = new System.Drawing.Point(33, 121);
            this.dgv_Tipo_Producto.Name = "dgv_Tipo_Producto";
            this.dgv_Tipo_Producto.ReadOnly = true;
            this.dgv_Tipo_Producto.Size = new System.Drawing.Size(625, 192);
            this.dgv_Tipo_Producto.TabIndex = 5;
            this.dgv_Tipo_Producto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_Tipo_Producto_CellPainting);
            // 
            // btnseleccionar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.btnseleccionar.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.btnseleccionar.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // mdTipo_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 391);
            this.Controls.Add(this.dgv_Tipo_Producto);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarTP);
            this.Controls.Add(this.txtN_TipProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdTipo_Producto";
            this.Text = "mdTipo_Producto";
            this.Load += new System.EventHandler(this.mdTipo_Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Producto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtN_TipProducto;
        private System.Windows.Forms.Button btnGuardarTP;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dgv_Tipo_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}