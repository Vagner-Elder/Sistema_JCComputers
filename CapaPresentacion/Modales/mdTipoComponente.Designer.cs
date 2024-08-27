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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnGuardarTipoComp = new System.Windows.Forms.Button();
            this.txtN_TipComp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgv_Tipo_Modelo = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Modelo)).BeginInit();
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
            this.btnGuardarTipoComp.Location = new System.Drawing.Point(307, 43);
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
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(469, 42);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 222;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(388, 43);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 221;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgv_Tipo_Modelo
            // 
            this.dgv_Tipo_Modelo.AllowUserToAddRows = false;
            this.dgv_Tipo_Modelo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Tipo_Modelo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Tipo_Modelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tipo_Modelo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Nombre});
            this.dgv_Tipo_Modelo.Location = new System.Drawing.Point(11, 87);
            this.dgv_Tipo_Modelo.MultiSelect = false;
            this.dgv_Tipo_Modelo.Name = "dgv_Tipo_Modelo";
            this.dgv_Tipo_Modelo.ReadOnly = true;
            this.dgv_Tipo_Modelo.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Tipo_Modelo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Tipo_Modelo.RowTemplate.Height = 28;
            this.dgv_Tipo_Modelo.Size = new System.Drawing.Size(593, 254);
            this.dgv_Tipo_Modelo.TabIndex = 220;
            this.dgv_Tipo_Modelo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tipo_Modelo_CellContentClick);
            this.dgv_Tipo_Modelo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_Tipo_Modelo_CellPainting);
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
            this.Nombre.HeaderText = "Modelos";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 84;
            // 
            // mdTipoComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 366);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgv_Tipo_Modelo);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardarTipoComp);
            this.Controls.Add(this.txtN_TipComp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mdTipoComponente";
            this.Text = "mdTipoComponente";
            this.Load += new System.EventHandler(this.mdTipoComponente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tipo_Modelo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardarTipoComp;
        private System.Windows.Forms.TextBox txtN_TipComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgv_Tipo_Modelo;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}