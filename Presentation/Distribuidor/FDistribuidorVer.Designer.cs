namespace Presentation.Distribuidor
{
    partial class FDistribuidorVer
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
            this.btnAgregarDistribuidor = new System.Windows.Forms.Button();
            this.btnCerrarVentana = new System.Windows.Forms.Button();
            this.dgvDistribuidor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribuidor)).BeginInit();
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
            // btnAgregarDistribuidor
            // 
            this.btnAgregarDistribuidor.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarDistribuidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDistribuidor.FlatAppearance.BorderSize = 0;
            this.btnAgregarDistribuidor.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregarDistribuidor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAgregarDistribuidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDistribuidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDistribuidor.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDistribuidor.Location = new System.Drawing.Point(0, 90);
            this.btnAgregarDistribuidor.Name = "btnAgregarDistribuidor";
            this.btnAgregarDistribuidor.Size = new System.Drawing.Size(219, 42);
            this.btnAgregarDistribuidor.TabIndex = 21;
            this.btnAgregarDistribuidor.Text = "Nuevo distribuidor";
            this.btnAgregarDistribuidor.UseVisualStyleBackColor = false;
            this.btnAgregarDistribuidor.Click += new System.EventHandler(this.btnAgregarDistribuidor_Click);
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
            // dgvDistribuidor
            // 
            this.dgvDistribuidor.AllowUserToAddRows = false;
            this.dgvDistribuidor.AllowUserToDeleteRows = false;
            this.dgvDistribuidor.AllowUserToResizeRows = false;
            this.dgvDistribuidor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDistribuidor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDistribuidor.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDistribuidor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDistribuidor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDistribuidor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDistribuidor.ColumnHeadersHeight = 40;
            this.dgvDistribuidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDistribuidor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDistribuidor.EnableHeadersVisualStyles = false;
            this.dgvDistribuidor.GridColor = System.Drawing.Color.Silver;
            this.dgvDistribuidor.Location = new System.Drawing.Point(12, 155);
            this.dgvDistribuidor.Name = "dgvDistribuidor";
            this.dgvDistribuidor.ReadOnly = true;
            this.dgvDistribuidor.RowHeadersVisible = false;
            this.dgvDistribuidor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDistribuidor.Size = new System.Drawing.Size(625, 286);
            this.dgvDistribuidor.TabIndex = 19;
            this.dgvDistribuidor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistribuidor_CellClick);
            this.dgvDistribuidor.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDistribuidor_CellPainting);
            this.dgvDistribuidor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPresentacion_ColumnHeaderMouseClick);
            this.dgvDistribuidor.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPresentacion_ColumnHeaderCellChanged);
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
            this.label1.Text = "DISTRIBUIDOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FDistribuidorVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 453);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAgregarDistribuidor);
            this.Controls.Add(this.btnCerrarVentana);
            this.Controls.Add(this.dgvDistribuidor);
            this.Controls.Add(this.label1);
            this.Name = "FDistribuidorVer";
            this.Text = "FDistribuidorVer";
            this.Load += new System.EventHandler(this.FDistribuidorVer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribuidor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAgregarDistribuidor;
        private System.Windows.Forms.Button btnCerrarVentana;
        private System.Windows.Forms.DataGridView dgvDistribuidor;
        private System.Windows.Forms.Label label1;
    }
}