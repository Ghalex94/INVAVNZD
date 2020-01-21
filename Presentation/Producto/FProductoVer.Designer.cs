namespace Presentation.Producto
{
    partial class FProductoVer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnCerrarVentana = new System.Windows.Forms.Button();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxfiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(-1, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 3);
            this.textBox1.TabIndex = 22;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(0, 90);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(219, 42);
            this.btnAgregarProducto.TabIndex = 21;
            this.btnAgregarProducto.Text = "Nuevo producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnCerrarVentana
            // 
            this.btnCerrarVentana.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrarVentana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarVentana.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrarVentana.FlatAppearance.BorderSize = 0;
            this.btnCerrarVentana.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btnCerrarVentana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnCerrarVentana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarVentana.ForeColor = System.Drawing.Color.White;
            this.btnCerrarVentana.Location = new System.Drawing.Point(0, -1);
            this.btnCerrarVentana.Name = "btnCerrarVentana";
            this.btnCerrarVentana.Size = new System.Drawing.Size(40, 55);
            this.btnCerrarVentana.TabIndex = 20;
            this.btnCerrarVentana.Text = "X";
            this.btnCerrarVentana.UseVisualStyleBackColor = false;
            this.btnCerrarVentana.Click += new System.EventHandler(this.btnCerrarVentana_Click);
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.AllowUserToResizeRows = false;
            this.dgvProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducto.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProducto.ColumnHeadersHeight = 40;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducto.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProducto.EnableHeadersVisualStyles = false;
            this.dgvProducto.GridColor = System.Drawing.Color.Silver;
            this.dgvProducto.Location = new System.Drawing.Point(12, 193);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(625, 248);
            this.dgvProducto.TabIndex = 19;
            this.dgvProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvProducto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsuarios_CellPainting);
            this.dgvProducto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPresentacion_ColumnHeaderMouseClick);
            this.dgvProducto.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPresentacion_ColumnHeaderCellChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(46, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 56);
            this.label1.TabIndex = 18;
            this.label1.Text = "PRODUCTOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filtrar por:";
            // 
            // cbxfiltro
            // 
            this.cbxfiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxfiltro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbxfiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxfiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxfiltro.FormattingEnabled = true;
            this.cbxfiltro.Items.AddRange(new object[] {
            "CodBarra",
            "Producto",
            "Detalle"});
            this.cbxfiltro.Location = new System.Drawing.Point(491, 155);
            this.cbxfiltro.Name = "cbxfiltro";
            this.cbxfiltro.Size = new System.Drawing.Size(146, 32);
            this.cbxfiltro.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Buscar producto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.Location = new System.Drawing.Point(209, 155);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(269, 32);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // FProductoVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 453);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxfiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnCerrarVentana);
            this.Controls.Add(this.dgvProducto);
            this.Controls.Add(this.label1);
            this.Name = "FProductoVer";
            this.Text = "FProductoVer";
            this.Load += new System.EventHandler(this.FProductoVer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnCerrarVentana;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxfiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}