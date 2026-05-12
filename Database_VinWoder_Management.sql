-- =================================================================
-- KHOI TAO DATABASE: VinWonders Management (Ban Chuan - Final)
-- =================================================================
CREATE DATABASE VinWonders_Management;
GO

USE VinWonders_Management;
GO

-- =================================================================
-- NHOM 1: DANH SACH CAC BANG GOC
-- =================================================================
CREATE TABLE TaiKhoan (
    MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL,
    QuyenTruyCap VARCHAR(20) NOT NULL, -- Admin, QuanLy, ThuNgan
    TrangThai BIT DEFAULT 1, 
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE DangKyThanhVien(
    MaDangKy NVARCHAR(10) PRIMARY KEY,
    NgayDangKy DATE DEFAULT GETDATE(),
    DiaDiemDangKy NVARCHAR(100)
);

CREATE TABLE HangThanhVien (
    MaHang NVARCHAR(10) PRIMARY KEY,
    TenHang NVARCHAR(50) NOT NULL, 
    DiemToiThieu INT NOT NULL CHECK (DiemToiThieu >= 0),
    TiLeGiamGia DECIMAL(5,2) CHECK (TiLeGiamGia >= 0 AND TiLeGiamGia <= 100)
);

CREATE TABLE KhuVuc (
    MaKhuVuc NVARCHAR(10) PRIMARY KEY,
    TenKhuVuc VARCHAR(100) NOT NULL,
    MoTa VARCHAR(500),
    GioMoCua TIME,
    GioDongCua TIME
);

CREATE TABLE CaLamViec (
    MaCa NVARCHAR(10) PRIMARY KEY,
    TenCa VARCHAR(50) NOT NULL,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL
);

CREATE TABLE SuKien (
    MaSuKien NVARCHAR(10) PRIMARY KEY,
    TenSuKien NVARCHAR(100) NOT NULL, 
    MoTa NVARCHAR(500),
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL,
    MaGiamGia VARCHAR(20) UNIQUE, 
    PhanTramGiam DECIMAL(5,2), 
    GiamToiDa DECIMAL(18,2), 
    TrangThai BIT DEFAULT 1 
);

-- =================================================================
-- NHOM 2: DANH SACH CAC BANG CAP 1
-- =================================================================

CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(10) PRIMARY KEY,
    MaDangKy NVARCHAR(10) NULL,
    MaHang NVARCHAR(10) NULL,
    HoTen VARCHAR(100) NOT NULL,
    LoaiKhach NVARCHAR(50) DEFAULT N'Cá nhân', -- 'Cá nhân' hoặc 'Khách đoàn'
    NgaySinh DATE,
    DiaChi VARCHAR(255),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    DiemTichLuy INT DEFAULT 0,
    FOREIGN KEY (MaDangKy) REFERENCES DangKyThanhVien(MaDangKy),
    FOREIGN KEY (MaHang) REFERENCES HangThanhVien(MaHang)
);

CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(10) PRIMARY KEY,
    MaTaiKhoan NVARCHAR(10) UNIQUE NULL, -- Liên kết 1-1 với Tài Khoản
    HoTen VARCHAR(50) NOT NULL,
    GioTinh NVARCHAR(3),
    NgaySinh DATE,
    SoDienThoai VARCHAR(15),
    Email NVARCHAR(50),
    CCCD VARCHAR(12),
    ViTri VARCHAR(50), 
    Luong DECIMAL(18,2),
    NgayVaoLam DATE,
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

CREATE TABLE TroChoi (
    MaTroChoi NVARCHAR(10) PRIMARY KEY,
    MaKhuVuc NVARCHAR(10) NOT NULL,
    TenTroChoi VARCHAR(100) NOT NULL,
    PhanLoai VARCHAR(50),
    ChieuCaoToiThieu INT, 
    DoTuoiToiThieu INT, 
    SucChua INT,
    TrangThai VARCHAR(50), 
    FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE CuaHang (
    MaCuaHang NVARCHAR(10) PRIMARY KEY,
    MaKhuVuc NVARCHAR(10) NOT NULL,
    TenCuaHang VARCHAR(100) NOT NULL,
    LoaiCuaHang NVARCHAR(50), -- VD: Quầy Fastfood, Nhà hàng Buffet, Quầy Lưu niệm
    TrangThai VARCHAR(50) DEFAULT N'Đang hoạt động',
    FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE LoaiVe (
    MaLoaiVe NVARCHAR(10) PRIMARY KEY,
    TenLoaiVe VARCHAR(100) NOT NULL,
    PhanLoai NVARCHAR(50), -- Vé vào cổng, Vé trọn gói, Combo ăn trưa
    GiaVe DECIMAL(18,2) NOT NULL,
    BaoGomAnUong BIT DEFAULT 0, 
    MoTa VARCHAR(255)
);

-- =================================================================
-- NHOM 3: BẢNG TRUNG GIAN & DỊCH VỤ F&B
-- =================================================================

CREATE TABLE QuyenLoiVe_TroChoi (
    MaLoaiVe NVARCHAR(10) NOT NULL,
    MaTroChoi NVARCHAR(10) NOT NULL,
    PRIMARY KEY (MaLoaiVe, MaTroChoi),
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe),
    FOREIGN KEY (MaTroChoi) REFERENCES TroChoi(MaTroChoi)
);

CREATE TABLE SanPham (
    MaSanPham NVARCHAR(10) PRIMARY KEY,
    MaCuaHang NVARCHAR(10) NOT NULL,
    TenSanPham VARCHAR(100) NOT NULL,
    LoaiSanPham NVARCHAR(50), -- VD: Món chính, Đồ uống, Lưu niệm
    GiaBan DECIMAL(18,2) NOT NULL,
    TrangThaiBan NVARCHAR(50) DEFAULT N'Còn hàng', -- Khắc phục lỗi logic "Tồn kho"
    FOREIGN KEY (MaCuaHang) REFERENCES CuaHang(MaCuaHang)
);

-- =================================================================
-- NHOM 4: NGHIỆP VỤ HÓA ĐƠN VÀ THANH TOÁN
-- =================================================================

CREATE TABLE HoaDonVe (
    MaHoaDon NVARCHAR(10) PRIMARY KEY,
    MaKhachHang NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, 
    MaSuKien NVARCHAR(10) NULL,
    NgayMua DATETIME DEFAULT GETDATE(),
    ChietKhauDoan DECIMAL(18,2) DEFAULT 0, 
    TongTien DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan VARCHAR(50),
    TrangThai VARCHAR(50),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaSuKien) REFERENCES SuKien(MaSuKien)
);

----- BỎ
CREATE TABLE ChiTietHoaDonVe (
    MaChiTietHD NVARCHAR(10) PRIMARY KEY,
    MaHoaDon NVARCHAR(10) NOT NULL,
    MaLoaiVe NVARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDonVe(MaHoaDon),
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe)
);

CREATE TABLE Ve (
    MaVe NVARCHAR(10) PRIMARY KEY,
    MaChiTietHD NVARCHAR(10) NOT NULL,
    NgaySuDung DATE,
    DaSuDung BIT DEFAULT 0, 
    FOREIGN KEY (MaChiTietHD) REFERENCES ChiTietHoaDonVe(MaChiTietHD)
);

CREATE TABLE HoaDonCuaHang (
    MaHDCH NVARCHAR(10) PRIMARY KEY,
    MaCuaHang NVARCHAR(10) NOT NULL,
    MaKhachHang NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, -- Ai thu tiền ở cửa hàng?
    TongTien DECIMAL(18,2) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaCuaHang) REFERENCES CuaHang(MaCuaHang),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietHDCH (
    MaCTHDCH NVARCHAR(10) PRIMARY KEY,
    MaHDCH NVARCHAR(10) NOT NULL,
    MaSanPham NVARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (MaHDCH) REFERENCES HoaDonCuaHang(MaHDCH),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- =================================================================
-- NHOM 5: QUẢN LÝ CA LÀM & BẢO TRÌ
-- =================================================================

CREATE TABLE LichLamViec (
    MaLich NVARCHAR(10) PRIMARY KEY,
    MaNhanVien NVARCHAR(10) NOT NULL,
    MaCa NVARCHAR(10) NOT NULL,
    NgayLamViec DATE NOT NULL,
    ViTriPhanCong VARCHAR(100),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
);

CREATE TABLE BaoTriTroChoi (
    MaBaoTri NVARCHAR(10) PRIMARY KEY,
    MaTroChoi NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, 
    NgayBatDau DATE NOT NULL,
    NgayDuKienXong DATE,
    MoTaLoi NVARCHAR(500), 
    ChiPhiBaoTri DECIMAL(18,2) CHECK (ChiPhiBaoTri >= 0),
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaTroChoi) REFERENCES TroChoi(MaTroChoi),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO