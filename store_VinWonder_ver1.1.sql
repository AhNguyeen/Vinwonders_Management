-- =================================================================
-- BỘ STORED PROCEDURE ĐÃ ĐỒNG BỘ UNICODE (NVARCHAR) CHUẨN FINAL
-- =================================================================

USE VinWonders_Management;
GO

-- =================================================================
-- 1. STORED PROCEDURES: PHÂN HỆ TÀI KHOẢN & NHÂN VIÊN
-- =================================================================

-- 1.1. Đăng nhập hệ thống (Kiểm tra tài khoản hoạt động)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Login')
    DROP PROCEDURE sp_Login;
GO
CREATE PROCEDURE sp_Login
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.*, tk.QuyenTruyCap, tk.TrangThai AS TrangThaiTaiKhoan
    FROM NhanVien nv
    INNER JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
    WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau AND tk.TrangThai = 1;
END;
GO

-- 1.2. Thêm mới Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_NhanVien')
    DROP PROCEDURE sp_Insert_NhanVien;
GO
CREATE PROCEDURE sp_Insert_NhanVien
    @MaNhanVien NVARCHAR(10),
    @MaTaiKhoan NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(50),         -- Đồng bộ NVARCHAR
    @GioTinh NVARCHAR(3),        -- Đồng bộ NVARCHAR
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri NVARCHAR(50),         -- Đồng bộ NVARCHAR
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam)
    VALUES (@MaNhanVien, @MaTaiKhoan, @HoTen, @GioTinh, @NgaySinh, @SoDienThoai, @Email, @CCCD, @ViTri, @Luong, @NgayVaoLam);
END;
GO

-- 1.3. Cập nhật thông tin Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_NhanVien')
    DROP PROCEDURE sp_Update_NhanVien;
GO
CREATE PROCEDURE sp_Update_NhanVien
    @MaNhanVien NVARCHAR(10),
    @HoTen NVARCHAR(50),
    @GioTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri NVARCHAR(50),
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE NhanVien
    SET HoTen = @HoTen, GioTinh = @GioTinh, NgaySinh = @NgaySinh, 
        SoDienThoai = @SoDienThoai, Email = @Email, CCCD = @CCCD, 
        ViTri = @ViTri, Luong = @Luong, NgayVaoLam = @NgayVaoLam
    WHERE MaNhanVien = @MaNhanVien;
END;
GO

-- 1.4. Lấy tất cả Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_NhanVien')
    DROP PROCEDURE sp_GetAll_NhanVien;
GO
CREATE PROCEDURE sp_GetAll_NhanVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.*, tk.TenDangNhap, tk.QuyenTruyCap
    FROM NhanVien nv
    LEFT JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan;
END;
GO

-- =================================================================
-- 2. STORED PROCEDURES: PHÂN HỆ KHÁCH HÀNG
-- =================================================================

-- 2.1. Thêm mới Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_KhachHang')
    DROP PROCEDURE sp_Insert_KhachHang;
GO
CREATE PROCEDURE sp_Insert_KhachHang
    @MaKhachHang NVARCHAR(10),
    @MaDangKy NVARCHAR(10) = NULL,
    @MaHang NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(100),       -- Đồng bộ NVARCHAR
    @LoaiKhach NVARCHAR(50),     -- 'Cá nhân' hoặc 'Khách đoàn'
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL, -- Đổi thành NVARCHAR chứa địa chỉ tiếng Việt
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @DiemTichLuy INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhachHang (MaKhachHang, MaDangKy, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy)
    VALUES (@MaKhachHang, @MaDangKy, @MaHang, @HoTen, @LoaiKhach, @NgaySinh, @DiaChi, @SoDienThoai, @Email, @DiemTichLuy);
END;
GO

-- 2.2. Cập nhật Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_KhachHang')
    DROP PROCEDURE sp_Update_KhachHang;
GO
CREATE PROCEDURE sp_Update_KhachHang
    @MaKhachHang NVARCHAR(10),
    @MaHang NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(100),
    @LoaiKhach NVARCHAR(50),
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @DiemTichLuy INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhachHang
    SET MaHang = @MaHang, HoTen = @HoTen, LoaiKhach = @LoaiKhach, NgaySinh = @NgaySinh,
        DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, DiemTichLuy = @DiemTichLuy
    WHERE MaKhachHang = @MaKhachHang;
END;
GO

-- 2.3. Lấy toàn bộ danh sách Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_KhachHang')
    DROP PROCEDURE sp_GetAll_KhachHang;
GO
CREATE PROCEDURE sp_GetAll_KhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT kh.*, htv.TenHang, htv.TiLeGiamGia
    FROM KhachHang kh
    LEFT JOIN HangThanhVien htv ON kh.MaHang = htv.MaHang;
END;
GO

-- =================================================================
-- 3. STORED PROCEDURES: QUẢN LÝ LOẠI VÉ
-- =================================================================

-- 3.1. Thêm mới Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_LoaiVe')
    DROP PROCEDURE sp_Insert_LoaiVe;
GO
CREATE PROCEDURE sp_Insert_LoaiVe
    @MaLoaiVe NVARCHAR(10),
    @TenLoaiVe NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @PhanLoai NVARCHAR(50),     -- Vé vào cổng, Vé trọn gói...
    @GiaVe DECIMAL(18,2),
    @BaoGomAnUong BIT = 0,
    @MoTa NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa)
    VALUES (@MaLoaiVe, @TenLoaiVe, @PhanLoai, @GiaVe, @BaoGomAnUong, @MoTa);
END;
GO

-- 3.2. Lấy danh sách Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_LoaiVe')
    DROP PROCEDURE sp_GetAll_LoaiVe;
GO
CREATE PROCEDURE sp_GetAll_LoaiVe
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM LoaiVe;
END;
GO

-- =================================================================
-- 4. STORED PROCEDURES: NGHIỆP VỤ HÓA ĐƠN VÀ PHÁT HÀNH VÉ
-- =================================================================

-- 4.1. Thêm mới Hóa đơn bán vé (FIX TRIỆT ĐỂ LỖI TIẾNG VIỆT ?)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_HoaDonVe')
    DROP PROCEDURE sp_Insert_HoaDonVe;
GO
CREATE PROCEDURE sp_Insert_HoaDonVe
    @MaHoaDon NVARCHAR(10),
    @MaKhachHang NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MaSuKien NVARCHAR(10) = NULL,
    @ChietKhauDoan DECIMAL(18,2) = 0,
    @TongTien DECIMAL(18,2),
    @PhuongThucThanhToan NVARCHAR(50), -- Sửa thành NVARCHAR để nhận N'Tiền mặt'
    @TrangThai NVARCHAR(50)            -- Sửa thành NVARCHAR để nhận N'Đã thanh toán'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, MaSuKien, NgayMua, ChietKhauDoan, TongTien, PhuongThucThanhToan, TrangThai)
    VALUES (@MaHoaDon, @MaKhachHang, @MaNhanVien, @MaSuKien, GETDATE(), @ChietKhauDoan, @TongTien, @PhuongThucThanhToan, @TrangThai);
END;
GO

-- 4.2. Thêm từng vé đơn lẻ vào hệ thống (Khi nhấn Thanh toán trên GUI)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_Ve')
    DROP PROCEDURE sp_Insert_Ve;
GO
CREATE PROCEDURE sp_Insert_Ve
    @MaVe NVARCHAR(10),
    @MaHoaDon NVARCHAR(10),
    @MaLoaiVe NVARCHAR(10),
    @DonGia DECIMAL(18,2),
    @NgaySuDung DATE,
    @DaSuDung BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung)
    VALUES (@MaVe, @MaHoaDon, @MaLoaiVe, @DonGia, @NgaySuDung, @DaSuDung);
END;
GO

-- 4.3. Đổ danh sách Hóa đơn lên màn hình chính DataGridView
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_HoaDonVe')
    DROP PROCEDURE sp_GetAll_HoaDonVe;
GO
CREATE PROCEDURE sp_GetAll_HoaDonVe
AS
BEGIN
    SET NOCOUNT ON;
    SELECT hdv.*, kh.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien, sk.TenSuKien
    FROM HoaDonVe hdv
    INNER JOIN KhachHang kh ON hdv.MaKhachHang = kh.MaKhachHang
    INNER JOIN NhanVien nv ON hdv.MaNhanVien = nv.MaNhanVien
    LEFT JOIN SuKien sk ON hdv.MaSuKien = sk.MaSuKien
    ORDER BY hdv.NgayMua DESC;
END;
GO

-- 4.4. Lấy chi tiết các vé thuộc một hóa đơn cụ thể (Xem danh sách vé đã mua)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetVe_ByHoaDon')
    DROP PROCEDURE sp_GetVe_ByHoaDon;
GO
CREATE PROCEDURE sp_GetVe_ByHoaDon
    @MaHoaDon NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.*, lv.TenLoaiVe, lv.PhanLoai
    FROM Ve v
    INNER JOIN LoaiVe lv ON v.MaLoaiVe = lv.MaLoaiVe
    WHERE v.MaHoaDon = @MaHoaDon;
END;
GO

-- 4.5. Quét vé vào cổng (Cập nhật trạng thái sử dụng vé)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_QuetVeVaoCong')
    DROP PROCEDURE sp_QuetVeVaoCong;
GO
CREATE PROCEDURE sp_QuetVeVaoCong
    @MaVe NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Ve 
    SET DaSuDung = 1 
    WHERE MaVe = @MaVe AND DaSuDung = 0;
END;
GO

-- =================================================================
-- 5. STORED PROCEDURES: QUẢN LÝ TRÒ CHƠI
-- =================================================================

-- 5.1. Thêm mới Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_TroChoi')
    DROP PROCEDURE sp_Insert_TroChoi;
GO
CREATE PROCEDURE sp_Insert_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @PhanLoai NVARCHAR(50) = NULL,
    @ChieuCaoToiThieu INT = NULL,
    @DoTuoiToiThieu INT = NULL,
    @SucChua INT = NULL,
    @TrangThai NVARCHAR(50) = N'Đang hoạt động'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai)
    VALUES (@MaTroChoi, @MaKhuVuc, @TenTroChoi, @PhanLoai, @ChieuCaoToiThieu, @DoTuoiToiThieu, @SucChua, @TrangThai);
END;
GO

-- 5.2. Cập nhật Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_TroChoi')
    DROP PROCEDURE sp_Update_TroChoi;
GO
CREATE PROCEDURE sp_Update_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi NVARCHAR(100),
    @PhanLoai NVARCHAR(50),
    @ChieuCaoToiThieu INT,
    @DoTuoiToiThieu INT,
    @SucChua INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TroChoi
    SET MaKhuVuc = @MaKhuVuc, TenTroChoi = @TenTroChoi, PhanLoai = @PhanLoai,
        ChieuCaoToiThieu = @ChieuCaoToiThieu, DoTuoiToiThieu = @DoTuoiToiThieu,
        SucChua = @SucChua, TrangThai = @TrangThai
    WHERE MaTroChoi = @MaTroChoi;
END;
GO

-- 5.3. Lấy tất cả Trò chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_TroChoi')
    DROP PROCEDURE sp_GetAll_TroChoi;
GO
CREATE PROCEDURE sp_GetAll_TroChoi
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tc.*, kv.TenKhuVuc
    FROM TroChoi tc
    INNER JOIN KhuVuc kv ON tc.MaKhuVuc = kv.MaKhuVuc;
END;
GO

-- =================================================================
-- 6. STORED PROCEDURES: QUẢN LÝ GIAN HÀNG & SẢN PHẨM (F&B)
-- =================================================================

-- 6.1. Thêm mới Sản phẩm
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_SanPham')
    DROP PROCEDURE sp_Insert_SanPham;
GO
CREATE PROCEDURE sp_Insert_SanPham
    @MaSanPham NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @TenSanPham NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @LoaiSanPham NVARCHAR(50) = NULL,
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50) = N'Còn hàng'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SanPham (MaSanPham, MaCuaHang, TenSanPham, LoaiSanPham, GiaBan, TrangThaiBan)
    VALUES (@MaSanPham, @MaCuaHang, @TenSanPham, @LoaiSanPham, @GiaBan, @TrangThaiBan);
END;
GO

-- 6.2. Cập nhật Sản phẩm
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_SanPham')
    DROP PROCEDURE sp_Update_SanPham;
GO
CREATE PROCEDURE sp_Update_SanPham
    @MaSanPham NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @TenSanPham NVARCHAR(100),
    @LoaiSanPham NVARCHAR(50),
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SanPham
    SET MaCuaHang = @MaCuaHang, TenSanPham = @TenSanPham, LoaiSanPham = @LoaiSanPham,
        GiaBan = @GiaBan, TrangThaiBan = @TrangThaiBan
    WHERE MaSanPham = @MaSanPham;
END;
GO

-- 6.3. Lấy toàn bộ Sản phẩm (F&B và Lưu niệm)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_SanPham')
    DROP PROCEDURE sp_GetAll_SanPham;
GO
CREATE PROCEDURE sp_GetAll_SanPham
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sp.*, ch.TenCuaHang, ch.LoaiCuaHang
    FROM SanPham sp
    INNER JOIN CuaHang ch ON sp.MaCuaHang = ch.MaCuaHang;
END;
GO

-- =================================================================
-- 7. STORED PROCEDURES: QUẢN LÝ KHEN THƯỞNG & KỶ LUẬT (MỚI THÊM)
-- =================================================================

-- 7.1. Thêm quyết định Thưởng / Phạt nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_KhenThuongKyLuat')
    DROP PROCEDURE sp_Insert_KhenThuongKyLuat;
GO
CREATE PROCEDURE sp_Insert_KhenThuongKyLuat
    @MaKTKL NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @Loai NVARCHAR(50),          -- 'Khen thưởng' hoặc 'Kỷ luật'
    @LyDo NVARCHAR(500),         -- Lưu lý do tiếng Việt có dấu
    @SoTien DECIMAL(18,2) = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhenThuongKyLuat (MaKTKL, MaNhanVien, Loai, LyDo, SoTien, NgayQuyetDinh)
    VALUES (@MaKTKL, @MaNhanVien, @Loai, @LyDo, @SoTien, GETDATE());
END;
GO

-- 7.2. Lấy toàn bộ danh sách Thưởng / Phạt để quản lý kiểm tra
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_KhenThuongKyLuat')
    DROP PROCEDURE sp_GetAll_KhenThuongKyLuat;
GO
CREATE PROCEDURE sp_GetAll_KhenThuongKyLuat
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ktkl.*, nv.HoTen AS TenNhanVien
    FROM KhenThuongKyLuat ktkl
    INNER JOIN NhanVien nv ON ktkl.MaNhanVien = nv.MaNhanVien
    ORDER BY ktkl.NgayQuyetDinh DESC;
END;
GO
