﻿
namespace GUI.QuanTri
{
    partial class frmQuanLyKhuyenMai
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
            this.dtgvDanhSachLoaiSanPham = new System.Windows.Forms.DataGridView();
            this.MaLoaiSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMaLoaiSanPham = new System.Windows.Forms.TextBox();
            this.txtTenLoaiSanPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTroLai = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachLoaiSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDanhSachLoaiSanPham
            // 
            this.dtgvDanhSachLoaiSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachLoaiSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiSanPham,
            this.TenLoaiSanPham,
            this.SoLuongSanPham});
            this.dtgvDanhSachLoaiSanPham.Location = new System.Drawing.Point(-1, 162);
            this.dtgvDanhSachLoaiSanPham.Name = "dtgvDanhSachLoaiSanPham";
            this.dtgvDanhSachLoaiSanPham.Size = new System.Drawing.Size(496, 194);
            this.dtgvDanhSachLoaiSanPham.TabIndex = 16;
            // 
            // MaLoaiSanPham
            // 
            this.MaLoaiSanPham.DataPropertyName = "MaLoaiSanPham";
            this.MaLoaiSanPham.HeaderText = "Mã loại sản phẩm";
            this.MaLoaiSanPham.Name = "MaLoaiSanPham";
            this.MaLoaiSanPham.Width = 150;
            // 
            // TenLoaiSanPham
            // 
            this.TenLoaiSanPham.DataPropertyName = "TenLoaiSanPham";
            this.TenLoaiSanPham.HeaderText = "Tên loại sản phẩm";
            this.TenLoaiSanPham.Name = "TenLoaiSanPham";
            this.TenLoaiSanPham.Width = 150;
            // 
            // SoLuongSanPham
            // 
            this.SoLuongSanPham.DataPropertyName = "SoLuongSanPham";
            this.SoLuongSanPham.HeaderText = "Số lượng sản phẩm";
            this.SoLuongSanPham.Name = "SoLuongSanPham";
            this.SoLuongSanPham.Width = 150;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(273, 123);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(151, 123);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã loại sản phẩm:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(34, 123);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // txtMaLoaiSanPham
            // 
            this.txtMaLoaiSanPham.Location = new System.Drawing.Point(179, 37);
            this.txtMaLoaiSanPham.Name = "txtMaLoaiSanPham";
            this.txtMaLoaiSanPham.ReadOnly = true;
            this.txtMaLoaiSanPham.Size = new System.Drawing.Size(234, 20);
            this.txtMaLoaiSanPham.TabIndex = 10;
            // 
            // txtTenLoaiSanPham
            // 
            this.txtTenLoaiSanPham.Location = new System.Drawing.Point(179, 76);
            this.txtTenLoaiSanPham.Name = "txtTenLoaiSanPham";
            this.txtTenLoaiSanPham.Size = new System.Drawing.Size(169, 20);
            this.txtTenLoaiSanPham.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên loại sản phẩm:";
            // 
            // btnTroLai
            // 
            this.btnTroLai.Location = new System.Drawing.Point(390, 123);
            this.btnTroLai.Name = "btnTroLai";
            this.btnTroLai.Size = new System.Drawing.Size(75, 23);
            this.btnTroLai.TabIndex = 18;
            this.btnTroLai.Text = "Trở lại";
            this.btnTroLai.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(354, 76);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(59, 23);
            this.btnTim.TabIndex = 17;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // frmQuanLyKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 356);
            this.Controls.Add(this.dtgvDanhSachLoaiSanPham);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMaLoaiSanPham);
            this.Controls.Add(this.txtTenLoaiSanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTroLai);
            this.Controls.Add(this.btnTim);
            this.Name = "frmQuanLyKhuyenMai";
            this.Text = "frmQuanLyKhuyenMai";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachLoaiSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvDanhSachLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongSanPham;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtMaLoaiSanPham;
        private System.Windows.Forms.TextBox txtTenLoaiSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTroLai;
        private System.Windows.Forms.Button btnTim;
    }
}