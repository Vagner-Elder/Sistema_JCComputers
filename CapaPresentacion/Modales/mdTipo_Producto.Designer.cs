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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtN_TipProducto = new System.Windows.Forms.TextBox();
            this.btnGuardarTP = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dgv_Tipo_Productos = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Productos)).BeginInit();
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
            // dgv_Tipo_Productos
            // 
            this.dgv_Tipo_Productos.AllowUserToAddRows = false;
            this.dgv_Tipo_Productos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Tipo_Productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Tipo_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tipo_Productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Nombre});
            this.dgv_Tipo_Productos.Location = new System.Drawing.Point(33, 116);
            this.dgv_Tipo_Productos.MultiSelect = false;
            this.dgv_Tipo_Productos.Name = "dgv_Tipo_Productos";
            this.dgv_Tipo_Productos.ReadOnly = true;
            this.dgv_Tipo_Productos.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Tipo_Productos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Tipo_Productos.RowTemplate.Height = 28;
            this.dgv_Tipo_Productos.Size = new System.Drawing.Size(593, 254);
            this.dgv_Tipo_Productos.TabIndex = 217;
            this.dgv_Tipo_Productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tipo_Productos_CellContentClick);
            this.dgv_Tipo_Productos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_Tipo_Productos_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.HeaderText = "Tipo de Productos";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 124;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(410, 72);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 218;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(491, 71);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 219;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // mdTipo_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 391);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgv_Tipo_Productos);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarTP);
            this.Controls.Add(this.txtN_TipProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdTipo_Producto";
            this.Text = "mdTipo_Producto";
            this.Load += new System.EventHandler(this.mdTipo_Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtN_TipProducto;
        private System.Windows.Forms.Button btnGuardarTP;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dgv_Tipo_Productos;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
    }
}