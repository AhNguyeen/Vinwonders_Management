namespace Vinwonders_Management
{
    partial class GUI_LoaiVe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHoaDonVe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaoHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colMaLoaiVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLoaiVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhanLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonVe)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDonVe
            // 
            this.dgvHoaDonVe.AllowUserToAddRows = false;
            this.dgvHoaDonVe.AllowUserToResizeColumns = false;
            this.dgvHoaDonVe.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.dgvHoaDonVe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDonVe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDonVe.ColumnHeadersHeight = 30;
            this.dgvHoaDonVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLoaiVe,
            this.colTenLoaiVe,
            this.colPhanLoai,
            this.colGiaVe,
            this.colAnUong,
            this.colMoTa,
            this.colThaoTac});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDonVe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDonVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonVe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.dgvHoaDonVe.Location = new System.Drawing.Point(0, 146);
            this.dgvHoaDonVe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHoaDonVe.MultiSelect = false;
            this.dgvHoaDonVe.Name = "dgvHoaDonVe";
            this.dgvHoaDonVe.ReadOnly = true;
            this.dgvHoaDonVe.RowHeadersVisible = false;
            this.dgvHoaDonVe.RowHeadersWidth = 51;
            this.dgvHoaDonVe.Size = new System.Drawing.Size(1418, 650);
            this.dgvHoaDonVe.TabIndex = 5;
            this.dgvHoaDonVe.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange;
            this.dgvHoaDonVe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.dgvHoaDonVe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoaDonVe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHoaDonVe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoaDonVe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoaDonVe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoaDonVe.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDonVe.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvHoaDonVe.ThemeStyle.ReadOnly = true;
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            this.dgvHoaDonVe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.White;
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Separator1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 796);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1418, 54);
            this.guna2CustomGradientPanel1.TabIndex = 4;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 0);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1418, 12);
            this.guna2Separator1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1418, 146);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoHoaDon.BorderRadius = 6;
            this.btnTaoHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTaoHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnTaoHoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaoHoaDon.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnTaoHoaDon.ImageSize = new System.Drawing.Size(15, 15);
            this.btnTaoHoaDon.Location = new System.Drawing.Point(1218, 46);
            this.btnTaoHoaDon.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(186, 37);
            this.btnTaoHoaDon.TabIndex = 3;
            this.btnTaoHoaDon.Text = "Xóa Loại Vé";
            this.btnTaoHoaDon.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.guna2Button2);
            this.guna2Panel2.Controls.Add(this.guna2Button1);
            this.guna2Panel2.Controls.Add(this.btnTaoHoaDon);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 5);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1418, 132);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 6;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(15, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button1.Location = new System.Drawing.Point(1020, 46);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(188, 37);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Cập Nhật";
            this.guna2Button1.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.BorderRadius = 6;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageOffset = new System.Drawing.Point(15, 0);
            this.guna2Button2.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button2.Location = new System.Drawing.Point(822, 46);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(188, 37);
            this.guna2Button2.TabIndex = 3;
            this.guna2Button2.Text = "Thêm Loại Vé";
            this.guna2Button2.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách loại vé";
            // 
            // colMaLoaiVe
            // 
            this.colMaLoaiVe.DataPropertyName = "MaLoaiVe";
            this.colMaLoaiVe.HeaderText = "Mã Loại Vé";
            this.colMaLoaiVe.MinimumWidth = 6;
            this.colMaLoaiVe.Name = "colMaLoaiVe";
            this.colMaLoaiVe.ReadOnly = true;
            // 
            // colTenLoaiVe
            // 
            this.colTenLoaiVe.DataPropertyName = "TenLoaiVe";
            this.colTenLoaiVe.HeaderText = "Tên Vé";
            this.colTenLoaiVe.MinimumWidth = 6;
            this.colTenLoaiVe.Name = "colTenLoaiVe";
            this.colTenLoaiVe.ReadOnly = true;
            // 
            // colPhanLoai
            // 
            this.colPhanLoai.DataPropertyName = "PhanLoai";
            this.colPhanLoai.HeaderText = "Phân Loại";
            this.colPhanLoai.MinimumWidth = 6;
            this.colPhanLoai.Name = "colPhanLoai";
            this.colPhanLoai.ReadOnly = true;
            // 
            // colGiaVe
            // 
            this.colGiaVe.DataPropertyName = "GiaVe";
            this.colGiaVe.HeaderText = "Giá Vé";
            this.colGiaVe.MinimumWidth = 6;
            this.colGiaVe.Name = "colGiaVe";
            this.colGiaVe.ReadOnly = true;
            // 
            // colAnUong
            // 
            this.colAnUong.DataPropertyName = "BaoGomAnUong";
            this.colAnUong.HeaderText = "Ăn Uống";
            this.colAnUong.MinimumWidth = 6;
            this.colAnUong.Name = "colAnUong";
            this.colAnUong.ReadOnly = true;
            // 
            // colMoTa
            // 
            this.colMoTa.DataPropertyName = "MoTa";
            this.colMoTa.HeaderText = "Mô Tả";
            this.colMoTa.MinimumWidth = 6;
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.HeaderText = "Thao Tác";
            this.colThaoTac.MinimumWidth = 6;
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colThaoTac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // GUI_LoaiVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 850);
            this.ControlBox = false;
            this.Controls.Add(this.dgvHoaDonVe);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GUI_LoaiVe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonVe)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvHoaDonVe;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnTaoHoaDon;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhanLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewButtonColumn colThaoTac;
    }
}