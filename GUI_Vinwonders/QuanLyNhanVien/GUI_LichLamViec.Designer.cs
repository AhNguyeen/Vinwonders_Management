namespace Vinwonders_Management.QuanLyNhanVien
{
    partial class GUI_LichLamViec
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLichLamViec = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvLichLamViec = new System.Windows.Forms.DataGridView();
            this.colMaLich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChucVuGoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhungGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTriPhanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichLamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(857, 77);
            this.guna2Panel1.TabIndex = 18;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.txtTimKiem);
            this.guna2Panel2.Controls.Add(this.lblLichLamViec);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 5);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(857, 67);
            this.guna2Panel2.TabIndex = 0;
            // 
            // lblLichLamViec
            // 
            this.lblLichLamViec.BackColor = System.Drawing.Color.Transparent;
            this.lblLichLamViec.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLichLamViec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLichLamViec.Location = new System.Drawing.Point(18, 19);
            this.lblLichLamViec.Margin = new System.Windows.Forms.Padding(10);
            this.lblLichLamViec.Name = "lblLichLamViec";
            this.lblLichLamViec.Size = new System.Drawing.Size(221, 30);
            this.lblLichLamViec.TabIndex = 0;
            this.lblLichLamViec.Text = "Lịch làm việc tuần này";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.CustomizableEdges.TopLeft = false;
            this.guna2Panel3.CustomizableEdges.TopRight = false;
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 482);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(857, 36);
            this.guna2Panel3.TabIndex = 19;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.White;
            this.guna2Panel4.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel4.BorderRadius = 10;
            this.guna2Panel4.Controls.Add(this.dgvLichLamViec);
            this.guna2Panel4.CustomizableEdges.BottomLeft = false;
            this.guna2Panel4.CustomizableEdges.BottomRight = false;
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 77);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(857, 405);
            this.guna2Panel4.TabIndex = 20;
            // 
            // dgvLichLamViec
            // 
            this.dgvLichLamViec.AllowUserToAddRows = false;
            this.dgvLichLamViec.AllowUserToResizeColumns = false;
            this.dgvLichLamViec.AllowUserToResizeRows = false;
            this.dgvLichLamViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichLamViec.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichLamViec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichLamViec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLichLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichLamViec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLich,
            this.colMaNhanVien,
            this.colTenNhanVien,
            this.colChucVuGoc,
            this.colTenCa,
            this.colKhungGio,
            this.colNgayLamViec,
            this.colViTriPhanCong});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichLamViec.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLichLamViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichLamViec.EnableHeadersVisualStyles = false;
            this.dgvLichLamViec.Location = new System.Drawing.Point(0, 0);
            this.dgvLichLamViec.MultiSelect = false;
            this.dgvLichLamViec.Name = "dgvLichLamViec";
            this.dgvLichLamViec.ReadOnly = true;
            this.dgvLichLamViec.RowHeadersVisible = false;
            this.dgvLichLamViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichLamViec.Size = new System.Drawing.Size(857, 405);
            this.dgvLichLamViec.TabIndex = 9;
            // 
            // colMaLich
            // 
            this.colMaLich.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaLich.DataPropertyName = "MaLich";
            this.colMaLich.HeaderText = "Mã Lịch";
            this.colMaLich.Name = "colMaLich";
            this.colMaLich.ReadOnly = true;
            this.colMaLich.Width = 80;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaNhanVien.DataPropertyName = "MaNhanVien";
            this.colMaNhanVien.HeaderText = "Mã NV";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.ReadOnly = true;
            this.colMaNhanVien.Width = 80;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.DataPropertyName = "TenNhanVien";
            this.colTenNhanVien.HeaderText = "Họ và Tên";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.ReadOnly = true;
            // 
            // colChucVuGoc
            // 
            this.colChucVuGoc.DataPropertyName = "ChucVuGoc";
            this.colChucVuGoc.HeaderText = "Chức Vụ";
            this.colChucVuGoc.Name = "colChucVuGoc";
            this.colChucVuGoc.ReadOnly = true;
            // 
            // colTenCa
            // 
            this.colTenCa.DataPropertyName = "TenCa";
            this.colTenCa.HeaderText = "Ca Làm Việc";
            this.colTenCa.Name = "colTenCa";
            this.colTenCa.ReadOnly = true;
            // 
            // colKhungGio
            // 
            this.colKhungGio.DataPropertyName = "KhungGio";
            this.colKhungGio.HeaderText = "Khung Giờ";
            this.colKhungGio.Name = "colKhungGio";
            this.colKhungGio.ReadOnly = true;
            // 
            // colNgayLamViec
            // 
            this.colNgayLamViec.DataPropertyName = "NgayLamViec";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            this.colNgayLamViec.DefaultCellStyle = dataGridViewCellStyle8;
            this.colNgayLamViec.HeaderText = "Ngày Làm Việc";
            this.colNgayLamViec.Name = "colNgayLamViec";
            this.colNgayLamViec.ReadOnly = true;
            // 
            // colViTriPhanCong
            // 
            this.colViTriPhanCong.DataPropertyName = "ViTriPhanCong";
            this.colViTriPhanCong.HeaderText = "Vị Trí Phân Công";
            this.colViTriPhanCong.Name = "colViTriPhanCong";
            this.colViTriPhanCong.ReadOnly = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.IconLeft = global::Vinwonders_Management.Properties.Resources.Search;
            this.txtTimKiem.Location = new System.Drawing.Point(642, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm....";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            this.txtTimKiem.TabIndex = 5;
            // 
            // GUI_LichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "GUI_LichLamViec";
            this.Size = new System.Drawing.Size(857, 518);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichLamViec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLichLamViec;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.DataGridView dgvLichLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLich;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChucVuGoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhungGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTriPhanCong;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
    }
}
