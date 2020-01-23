namespace Presentation.Almacen
{
    partial class FAlmacenVer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAgregarAlmacen = new System.Windows.Forms.Button();
            this.btnCerrarVentana = new System.Windows.Forms.Button();
            this.dgvAlmacen = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacen)).BeginInit();
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
            // btnAgregarAlmacen
            // 
            this.btnAgregarAlmacen.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAlmacen.FlatAppearance.BorderSize = 0;
            this.btnAgregarAlmacen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarAlmacen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAgregarAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlmacen.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlmacen.Location = new System.Drawing.Point(0, 90);
            this.btnAgregarAlmacen.Name = "btnAgregarAlmacen";
            this.btnAgregarAlmacen.Size = new System.Drawing.Size(219, 42);
            this.btnAgregarAlmacen.TabIndex = 21;
            this.btnAgregarAlmacen.Text = "Nuevo almacen";
            this.btnAgregarAlmacen.UseVisualStyleBackColor = false;
            this.btnAgregarAlmacen.Click += new System.EventHandler(this.btnAgregarAlmacen_Click);
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
            // dgvAlmacen
            // 
            this.dgvAlmacen.AllowUserToAddRows = false;
            this.dgvAlmacen.AllowUserToDeleteRows = false;
            this.dgvAlmacen.AllowUserToResizeRows = false;
            this.dgvAlmacen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlmacen.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlmacen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlmacen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlmacen.ColumnHeadersHeight = 40;
            this.dgvAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlmacen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlmacen.EnableHeadersVisualStyles = false;
            this.dgvAlmacen.GridColor = System.Drawing.Color.Silver;
            this.dgvAlmacen.Location = new System.Drawing.Point(12, 155);
            this.dgvAlmacen.Name = "dgvAlmacen";
            this.dgvAlmacen.ReadOnly = true;
            this.dgvAlmacen.RowHeadersVisible = false;
            this.dgvAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlmacen.Size = new System.Drawing.Size(625, 286);
            this.dgvAlmacen.TabIndex = 19;
            this.dgvAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlmacen_CellClick);
            this.dgvAlmacen.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAlmacen_CellPainting);
            this.dgvAlmacen.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPresentacion_ColumnHeaderMouseClick);
            this.dgvAlmacen.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPresentacion_ColumnHeaderCellChanged);
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
            this.label1.Text = "ALMACEN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FAlmacenVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 453);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAgregarAlmacen);
            this.Controls.Add(this.btnCerrarVentana);
            this.Controls.Add(this.dgvAlmacen);
            this.Controls.Add(this.label1);
            this.Name = "FAlmacenVer";
            this.Text = "FAlmacenVer";
            this.Load += new System.EventHandler(this.FAlmacenVer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAgregarAlmacen;
        private System.Windows.Forms.Button btnCerrarVentana;
        private System.Windows.Forms.DataGridView dgvAlmacen;
        private System.Windows.Forms.Label label1;
    }
}