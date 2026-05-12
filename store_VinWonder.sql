-- =================================================================
-- BỘ STORED PROCEDURE CRUD (TỐI ƯU CHO C# CALL)
-- =================================================================

USE VinWonders_Management;
GO

-- =================================================================
-- 1. CRUD CHO BẢNG: TroChoi
-- =================================================================

-- 1.1. CREATE
CREATE PROCEDURE sp_Create_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi VARCHAR(100), 
    @PhanLoai VARCHAR(50) = NULL,
    @ChieuCaoToiThieu INT = NULL,
    @DoTuoiToiThieu INT = NULL,
    @SucChua INT = NULL,
    @TrangThai VARCHAR(50) = N'Đang hoạt động'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai)
        VALUES (@MaTroChoi, @MaKhuVuc, @TenTroChoi, @PhanLoai, @ChieuCaoToiThieu, @DoTuoiToiThieu, @SucChua, @TrangThai);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 1.2. READ
CREATE PROCEDURE sp_Read_TroChoi
    @MaTroChoi NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT t.*, k.TenKhuVuc 
    FROM TroChoi t
    LEFT JOIN KhuVuc k ON t.MaKhuVuc = k.MaKhuVuc
    WHERE (@MaTroChoi IS NULL OR t.MaTroChoi = @MaTroChoi);
END;
GO

-- 1.3. UPDATE
CREATE PROCEDURE sp_Update_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi VARCHAR(100),
    @PhanLoai VARCHAR(50),
    @ChieuCaoToiThieu INT,
    @DoTuoiToiThieu INT,
    @SucChua INT,
    @TrangThai VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE TroChoi
        SET MaKhuVuc = @MaKhuVuc,
            TenTroChoi = @TenTroChoi,
            PhanLoai = @PhanLoai,
            ChieuCaoToiThieu = @ChieuCaoToiThieu,
            DoTuoiToiThieu = @DoTuoiToiThieu,
            SucChua = @SucChua,
            TrangThai = @TrangThai
        WHERE MaTroChoi = @MaTroChoi;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 1.4. DELETE (Kết hợp Xóa Mềm & Xóa Cứng)
CREATE PROCEDURE sp_Delete_TroChoi
    @MaTroChoi NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM BaoTriTroChoi WHERE MaTroChoi = @MaTroChoi)
            OR EXISTS (SELECT 1 FROM QuyenLoiVe_TroChoi WHERE MaTroChoi = @MaTroChoi)
        BEGIN
            -- Xóa mềm
            UPDATE TroChoi
            SET TrangThai = N'Đã đóng cửa'
            WHERE MaTroChoi = @MaTroChoi;
        END
        ELSE
        BEGIN
            -- Xóa cứng
            DELETE FROM TroChoi WHERE MaTroChoi = @MaTroChoi;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- 2. CRUD CHO BẢNG: KhachHang
-- =================================================================

-- 2.1. CREATE
CREATE PROCEDURE sp_Create_KhachHang
    @MaKhachHang NVARCHAR(10),
    @MaDangKy NVARCHAR(10) = NULL,
    @MaHang NVARCHAR(10) = NULL,
    @HoTen VARCHAR(100),
    @LoaiKhach NVARCHAR(50) = N'Cá nhân',
    @NgaySinh DATE = NULL,
    @DiaChi VARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO KhachHang (MaKhachHang, MaDangKy, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy)
        VALUES (@MaKhachHang, @MaDangKy, @MaHang, @HoTen, @LoaiKhach, @NgaySinh, @DiaChi, @SoDienThoai, @Email, 0); 
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 2.2. READ
CREATE PROCEDURE sp_Read_KhachHang
    @TuKhoa VARCHAR(100) = NULL 
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT kh.*, h.TenHang 
    FROM KhachHang kh
    LEFT JOIN HangThanhVien h ON kh.MaHang = h.MaHang
    WHERE (@TuKhoa IS NULL 
           OR kh.HoTen LIKE '%' + @TuKhoa + '%' 
           OR kh.SoDienThoai LIKE '%' + @TuKhoa + '%');
END;
GO

-- 2.3. UPDATE
CREATE PROCEDURE sp_Update_KhachHang
    @MaKhachHang NVARCHAR(10),
    @HoTen VARCHAR(100),
    @LoaiKhach NVARCHAR(50),
    @NgaySinh DATE,
    @DiaChi VARCHAR(255),
    @SoDienThoai VARCHAR(15),
    @Email VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE KhachHang
        SET HoTen = @HoTen,
            LoaiKhach = @LoaiKhach,
            NgaySinh = @NgaySinh,
            DiaChi = @DiaChi,
            SoDienThoai = @SoDienThoai,
            Email = @Email
        WHERE MaKhachHang = @MaKhachHang;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 2.4. DELETE
CREATE PROCEDURE sp_Delete_KhachHang
    @MaKhachHang NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM HoaDonVe WHERE MaKhachHang = @MaKhachHang)
            OR EXISTS (SELECT 1 FROM HoaDonCuaHang WHERE MaKhachHang = @MaKhachHang)
        BEGIN
            -- Ném lỗi thẳng về C# để bắt Exception
            ;THROW 50001, N'Khách hàng này đã có lịch sử giao dịch. Không thể xóa!', 1;
        END
        ELSE
        BEGIN
            DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- 3. CRUD CHO BẢNG: SanPham
-- =================================================================

-- 3.1. CREATE
CREATE PROCEDURE sp_Create_SanPham
    @MaSanPham NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @TenSanPham VARCHAR(100),
    @LoaiSanPham NVARCHAR(50),
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50) = N'Còn hàng'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO SanPham (MaSanPham, MaCuaHang, TenSanPham, LoaiSanPham, GiaBan, TrangThaiBan)
        VALUES (@MaSanPham, @MaCuaHang, @TenSanPham, @LoaiSanPham, @GiaBan, @TrangThaiBan);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 3.2. READ
CREATE PROCEDURE sp_Read_SanPham
    @MaCuaHang NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT sp.*, ch.TenCuaHang 
    FROM SanPham sp
    INNER JOIN CuaHang ch ON sp.MaCuaHang = ch.MaCuaHang
    WHERE (@MaCuaHang IS NULL OR sp.MaCuaHang = @MaCuaHang);
END;
GO

-- 3.3. UPDATE
CREATE PROCEDURE sp_Update_SanPham
    @MaSanPham NVARCHAR(10),
    @TenSanPham VARCHAR(100),
    @LoaiSanPham NVARCHAR(50),
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE SanPham
        SET TenSanPham = @TenSanPham,
            LoaiSanPham = @LoaiSanPham,
            GiaBan = @GiaBan,
            TrangThaiBan = @TrangThaiBan
        WHERE MaSanPham = @MaSanPham;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 3.4. DELETE (Kết hợp Xóa Mềm & Xóa Cứng)
CREATE PROCEDURE sp_Delete_SanPham
    @MaSanPham NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM ChiTietHDCH WHERE MaSanPham = @MaSanPham)
        BEGIN
            -- Xóa mềm
            UPDATE SanPham
            SET TrangThaiBan = N'Ngừng kinh doanh'
            WHERE MaSanPham = @MaSanPham;
        END
        ELSE
        BEGIN
            -- Xóa cứng
            DELETE FROM SanPham WHERE MaSanPham = @MaSanPham;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- 4. CRUD CHO BẢNG: NhanVien
-- =================================================================

-- 4.1. CREATE
CREATE PROCEDURE sp_Create_NhanVien
    @MaNhanVien NVARCHAR(10),
    @MaTaiKhoan NVARCHAR(10) = NULL,
    @HoTen VARCHAR(50),
    @GioTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri VARCHAR(50), 
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam)
        VALUES (@MaNhanVien, @MaTaiKhoan, @HoTen, @GioTinh, @NgaySinh, @SoDienThoai, @Email, @CCCD, @ViTri, @Luong, @NgayVaoLam);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 4.2. READ
CREATE PROCEDURE sp_Read_NhanVien
    @TuKhoa NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.*, tk.TenDangNhap, tk.QuyenTruyCap
    FROM NhanVien nv
    LEFT JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
    WHERE (@TuKhoa IS NULL 
           OR nv.HoTen LIKE '%' + @TuKhoa + '%' 
           OR nv.MaNhanVien = @TuKhoa 
           OR nv.SoDienThoai LIKE '%' + @TuKhoa + '%');
END;
GO

-- 4.3. UPDATE
CREATE PROCEDURE sp_Update_NhanVien
    @MaNhanVien NVARCHAR(10),
    @MaTaiKhoan NVARCHAR(10) = NULL,
    @HoTen VARCHAR(50),
    @GioTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri VARCHAR(50), 
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE NhanVien
        SET MaTaiKhoan = @MaTaiKhoan,
            HoTen = @HoTen,
            GioTinh = @GioTinh,
            NgaySinh = @NgaySinh,
            SoDienThoai = @SoDienThoai,
            Email = @Email,
            CCCD = @CCCD,
            ViTri = @ViTri,
            Luong = @Luong,
            NgayVaoLam = @NgayVaoLam
        WHERE MaNhanVien = @MaNhanVien;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 4.4. DELETE
CREATE PROCEDURE sp_Delete_NhanVien
    @MaNhanVien NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM HoaDonVe WHERE MaNhanVien = @MaNhanVien)
            OR EXISTS (SELECT 1 FROM HoaDonCuaHang WHERE MaNhanVien = @MaNhanVien)
            OR EXISTS (SELECT 1 FROM LichLamViec WHERE MaNhanVien = @MaNhanVien)
            OR EXISTS (SELECT 1 FROM BaoTriTroChoi WHERE MaNhanVien = @MaNhanVien)
        BEGIN
            ;THROW 50002, N'Nhân viên này đã tham gia vào quy trình nghiệp vụ (Hóa đơn, Lịch làm, Bảo trì). Không thể xóa cứng!', 1;
        END
        ELSE
        BEGIN
            DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- 5. CRUD CHO BẢNG: CuaHang
-- =================================================================

-- 5.1. CREATE
CREATE PROCEDURE sp_Create_CuaHang
    @MaCuaHang NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenCuaHang VARCHAR(100),
    @LoaiCuaHang NVARCHAR(50),
    @TrangThai VARCHAR(50) = N'Đang hoạt động'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO CuaHang (MaCuaHang, MaKhuVuc, TenCuaHang, LoaiCuaHang, TrangThai)
        VALUES (@MaCuaHang, @MaKhuVuc, @TenCuaHang, @LoaiCuaHang, @TrangThai);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 5.2. READ
CREATE PROCEDURE sp_Read_CuaHang
    @MaCuaHang NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ch.*, kv.TenKhuVuc 
    FROM CuaHang ch
    LEFT JOIN KhuVuc kv ON ch.MaKhuVuc = kv.MaKhuVuc
    WHERE (@MaCuaHang IS NULL OR ch.MaCuaHang = @MaCuaHang);
END;
GO

-- 5.3. UPDATE
CREATE PROCEDURE sp_Update_CuaHang
    @MaCuaHang NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenCuaHang VARCHAR(100),
    @LoaiCuaHang NVARCHAR(50),
    @TrangThai VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE CuaHang
        SET MaKhuVuc = @MaKhuVuc,
            TenCuaHang = @TenCuaHang,
            LoaiCuaHang = @LoaiCuaHang,
            TrangThai = @TrangThai
        WHERE MaCuaHang = @MaCuaHang;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 5.4. DELETE
CREATE PROCEDURE sp_Delete_CuaHang
    @MaCuaHang NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM SanPham WHERE MaCuaHang = @MaCuaHang)
            OR EXISTS (SELECT 1 FROM HoaDonCuaHang WHERE MaCuaHang = @MaCuaHang)
        BEGIN
            -- Xóa mềm: Đổi trạng thái cửa hàng
            UPDATE CuaHang 
            SET TrangThai = N'Đã đóng cửa' 
            WHERE MaCuaHang = @MaCuaHang;
        END
        ELSE
        BEGIN
            DELETE FROM CuaHang WHERE MaCuaHang = @MaCuaHang;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- SP NGIỆP VỤ: TÍCH ĐIỂM THÀNH VIÊN
-- =================================================================
CREATE PROCEDURE sp_TichDiemVaCapNhatHang
    @MaKhachHang NVARCHAR(10),
    @SoTienChiTieu DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Giả sử quy tắc: 100,000 VNĐ = 1 điểm
    DECLARE @DiemCongThem INT = CAST((@SoTienChiTieu / 100000) AS INT);

    IF @DiemCongThem > 0
    BEGIN
        -- 1. Cộng điểm cho khách
        UPDATE KhachHang
        SET DiemTichLuy = DiemTichLuy + @DiemCongThem
        WHERE MaKhachHang = @MaKhachHang;

        -- 2. Tìm hạng mới dựa trên điểm và cập nhật luôn
        UPDATE KH
        SET KH.MaHang = HTV.MaHang
        FROM KhachHang KH
        CROSS APPLY (
            SELECT TOP 1 MaHang
            FROM HangThanhVien
            WHERE DiemToiThieu <= KH.DiemTichLuy
            ORDER BY DiemToiThieu DESC
        ) HTV
        WHERE KH.MaKhachHang = @MaKhachHang;

        -- Trả về điểm cộng thêm
        SELECT @DiemCongThem AS DiemCongThem;
    END
END;
GO

-- =================================================================
-- 6. CRUD CHO BẢNG: SuKien
-- =================================================================

-- 6.1. CREATE
CREATE PROCEDURE sp_Create_SuKien
    @MaSuKien NVARCHAR(10),
    @TenSuKien NVARCHAR(100),
    @MoTa NVARCHAR(500) = NULL,
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME,
    @MaGiamGia VARCHAR(20) = NULL,
    @PhanTramGiam DECIMAL(5,2) = NULL,
    @GiamToiDa DECIMAL(18,2) = NULL,
    @TrangThai BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO SuKien (MaSuKien, TenSuKien, MoTa, NgayBatDau, NgayKetThuc, MaGiamGia, PhanTramGiam, GiamToiDa, TrangThai)
        VALUES (@MaSuKien, @TenSuKien, @MoTa, @NgayBatDau, @NgayKetThuc, @MaGiamGia, @PhanTramGiam, @GiamToiDa, @TrangThai);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 6.2. READ
CREATE PROCEDURE sp_Read_SuKien
    @DangDienRa BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM SuKien
    WHERE (@DangDienRa IS NULL 
           OR (@DangDienRa = 1 AND TrangThai = 1 AND GETDATE() BETWEEN NgayBatDau AND NgayKetThuc));
END;
GO

-- 6.3. UPDATE
CREATE PROCEDURE sp_Update_SuKien
    @MaSuKien NVARCHAR(10),
    @TenSuKien NVARCHAR(100),
    @MoTa NVARCHAR(500),
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME,
    @MaGiamGia VARCHAR(20),
    @PhanTramGiam DECIMAL(5,2),
    @GiamToiDa DECIMAL(18,2),
    @TrangThai BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE SuKien
        SET TenSuKien = @TenSuKien,
            MoTa = @MoTa,
            NgayBatDau = @NgayBatDau,
            NgayKetThuc = @NgayKetThuc,
            MaGiamGia = @MaGiamGia,
            PhanTramGiam = @PhanTramGiam,
            GiamToiDa = @GiamToiDa,
            TrangThai = @TrangThai
        WHERE MaSuKien = @MaSuKien;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 6.4. DELETE
CREATE PROCEDURE sp_Delete_SuKien
    @MaSuKien NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM HoaDonVe WHERE MaSuKien = @MaSuKien)
        BEGIN
            -- Xóa mềm: Tắt trạng thái sự kiện
            UPDATE SuKien 
            SET TrangThai = 0 
            WHERE MaSuKien = @MaSuKien;
        END
        ELSE
        BEGIN
            DELETE FROM SuKien WHERE MaSuKien = @MaSuKien;
        END
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- =================================================================
-- 7. CRUD CHO BẢNG: Ve
-- =================================================================

-- 7.1. CREATE
CREATE PROCEDURE sp_Create_Ve
    @MaVe NVARCHAR(10),
    @MaChiTietHD NVARCHAR(10),
    @NgaySuDung DATE = NULL,
    @DaSuDung BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Ve (MaVe, MaChiTietHD, NgaySuDung, DaSuDung)
        VALUES (@MaVe, @MaChiTietHD, @NgaySuDung, @DaSuDung);
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 7.2. READ
CREATE PROCEDURE sp_Read_Ve
    @MaVe NVARCHAR(10) = NULL,
    @MaHoaDon NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.*, ct.MaHoaDon, ct.MaLoaiVe 
    FROM Ve v
    INNER JOIN ChiTietHoaDonVe ct ON v.MaChiTietHD = ct.MaChiTietHD
    WHERE (@MaVe IS NULL OR v.MaVe = @MaVe)
      AND (@MaHoaDon IS NULL OR ct.MaHoaDon = @MaHoaDon);
END;
GO

-- 7.3. UPDATE (Thường dùng để Check-in vé)
CREATE PROCEDURE sp_Update_Ve
    @MaVe NVARCHAR(10),
    @MaChiTietHD NVARCHAR(10),
    @NgaySuDung DATE,
    @DaSuDung BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Ve
        SET MaChiTietHD = @MaChiTietHD,
            NgaySuDung = @NgaySuDung,
            DaSuDung = @DaSuDung
        WHERE MaVe = @MaVe;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO

-- 7.4. DELETE
CREATE PROCEDURE sp_Delete_Ve
    @MaVe NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Ve WHERE MaVe = @MaVe;
    END TRY
    BEGIN CATCH
        ;THROW;
    END CATCH
END;
GO
-- =================================================================
-- CRUD CHO BẢNG: TaiKhoan
-- =================================================================
CREATE PROCEDURE sp_Create_TaiKhoan
    @MaTaiKhoan NVARCHAR(10), 
    @TenDangNhap VARCHAR(50), 
    @MatKhau VARCHAR(255), 
    @QuyenTruyCap VARCHAR(20), 
    @TrangThai BIT = 1
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, QuyenTruyCap, TrangThai)
        VALUES (@MaTaiKhoan, @TenDangNhap, @MatKhau, @QuyenTruyCap, @TrangThai);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_TaiKhoan 
    @MaTaiKhoan NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON;
    SELECT * FROM TaiKhoan 
    WHERE (@MaTaiKhoan IS NULL OR MaTaiKhoan = @MaTaiKhoan);
END;
GO

CREATE PROCEDURE sp_Update_TaiKhoan
    @MaTaiKhoan NVARCHAR(10), 
    @MatKhau VARCHAR(255), 
    @QuyenTruyCap VARCHAR(20), 
    @TrangThai BIT
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE TaiKhoan 
        SET MatKhau = @MatKhau, 
            QuyenTruyCap = @QuyenTruyCap, 
            TrangThai = @TrangThai 
        WHERE MaTaiKhoan = @MaTaiKhoan;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_TaiKhoan 
    @MaTaiKhoan NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM NhanVien WHERE MaTaiKhoan = @MaTaiKhoan)
        BEGIN
            -- Xóa mềm
            UPDATE TaiKhoan SET TrangThai = 0 WHERE MaTaiKhoan = @MaTaiKhoan; 
        END
        ELSE 
        BEGIN
            DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: DangKyThanhVien
-- =================================================================
CREATE PROCEDURE sp_Create_DangKyThanhVien
    @MaDangKy NVARCHAR(10), 
    @NgayDangKy DATE, 
    @DiaDiemDangKy NVARCHAR(100)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO DangKyThanhVien (MaDangKy, NgayDangKy, DiaDiemDangKy) 
        VALUES (@MaDangKy, ISNULL(@NgayDangKy, GETDATE()), @DiaDiemDangKy);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_DangKyThanhVien 
    @MaDangKy NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM DangKyThanhVien 
    WHERE (@MaDangKy IS NULL OR MaDangKy = @MaDangKy); 
END;
GO

CREATE PROCEDURE sp_Update_DangKyThanhVien
    @MaDangKy NVARCHAR(10), 
    @NgayDangKy DATE, 
    @DiaDiemDangKy NVARCHAR(100)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE DangKyThanhVien 
        SET NgayDangKy = @NgayDangKy, 
            DiaDiemDangKy = @DiaDiemDangKy 
        WHERE MaDangKy = @MaDangKy;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_DangKyThanhVien 
    @MaDangKy NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM KhachHang WHERE MaDangKy = @MaDangKy)
        BEGIN
            ;THROW 50003, N'Lịch sử đăng ký này đang gắn với Khách hàng. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM DangKyThanhVien WHERE MaDangKy = @MaDangKy;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: HangThanhVien
-- =================================================================
CREATE PROCEDURE sp_Create_HangThanhVien
    @MaHang NVARCHAR(10), 
    @TenHang NVARCHAR(50), 
    @DiemToiThieu INT, 
    @TiLeGiamGia DECIMAL(5,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO HangThanhVien (MaHang, TenHang, DiemToiThieu, TiLeGiamGia) 
        VALUES (@MaHang, @TenHang, @DiemToiThieu, @TiLeGiamGia);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_HangThanhVien 
    @MaHang NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM HangThanhVien 
    WHERE (@MaHang IS NULL OR MaHang = @MaHang); 
END;
GO

CREATE PROCEDURE sp_Update_HangThanhVien
    @MaHang NVARCHAR(10), 
    @TenHang NVARCHAR(50), 
    @DiemToiThieu INT, 
    @TiLeGiamGia DECIMAL(5,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE HangThanhVien 
        SET TenHang = @TenHang, 
            DiemToiThieu = @DiemToiThieu, 
            TiLeGiamGia = @TiLeGiamGia 
        WHERE MaHang = @MaHang;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_HangThanhVien 
    @MaHang NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM KhachHang WHERE MaHang = @MaHang)
        BEGIN
            ;THROW 50004, N'Đang có khách hàng thuộc hạng này. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM HangThanhVien WHERE MaHang = @MaHang;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: KhuVuc
-- =================================================================
CREATE PROCEDURE sp_Create_KhuVuc
    @MaKhuVuc NVARCHAR(10), 
    @TenKhuVuc VARCHAR(100), 
    @MoTa VARCHAR(500), 
    @GioMoCua TIME, 
    @GioDongCua TIME
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO KhuVuc (MaKhuVuc, TenKhuVuc, MoTa, GioMoCua, GioDongCua) 
        VALUES (@MaKhuVuc, @TenKhuVuc, @MoTa, @GioMoCua, @GioDongCua);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_KhuVuc 
    @MaKhuVuc NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM KhuVuc 
    WHERE (@MaKhuVuc IS NULL OR MaKhuVuc = @MaKhuVuc); 
END;
GO

CREATE PROCEDURE sp_Update_KhuVuc
    @MaKhuVuc NVARCHAR(10), 
    @TenKhuVuc VARCHAR(100), 
    @MoTa VARCHAR(500), 
    @GioMoCua TIME, 
    @GioDongCua TIME
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE KhuVuc 
        SET TenKhuVuc = @TenKhuVuc, 
            MoTa = @MoTa, 
            GioMoCua = @GioMoCua, 
            GioDongCua = @GioDongCua 
        WHERE MaKhuVuc = @MaKhuVuc;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_KhuVuc 
    @MaKhuVuc NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM TroChoi WHERE MaKhuVuc = @MaKhuVuc) 
           OR EXISTS (SELECT 1 FROM CuaHang WHERE MaKhuVuc = @MaKhuVuc)
        BEGIN
            ;THROW 50005, N'Khu vực đang chứa trò chơi hoặc cửa hàng. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM KhuVuc WHERE MaKhuVuc = @MaKhuVuc;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: CaLamViec
-- =================================================================
CREATE PROCEDURE sp_Create_CaLamViec
    @MaCa NVARCHAR(10), 
    @TenCa VARCHAR(50), 
    @GioBatDau TIME, 
    @GioKetThuc TIME
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) 
        VALUES (@MaCa, @TenCa, @GioBatDau, @GioKetThuc);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_CaLamViec 
    @MaCa NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM CaLamViec 
    WHERE (@MaCa IS NULL OR MaCa = @MaCa); 
END;
GO

CREATE PROCEDURE sp_Update_CaLamViec
    @MaCa NVARCHAR(10), 
    @TenCa VARCHAR(50), 
    @GioBatDau TIME, 
    @GioKetThuc TIME
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE CaLamViec 
        SET TenCa = @TenCa, 
            GioBatDau = @GioBatDau, 
            GioKetThuc = @GioKetThuc 
        WHERE MaCa = @MaCa;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_CaLamViec 
    @MaCa NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM LichLamViec WHERE MaCa = @MaCa)
        BEGIN
            ;THROW 50006, N'Ca làm việc đã được phân lịch. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM CaLamViec WHERE MaCa = @MaCa;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: LoaiVe
-- =================================================================
CREATE PROCEDURE sp_Create_LoaiVe
    @MaLoaiVe NVARCHAR(10), 
    @TenLoaiVe VARCHAR(100), 
    @PhanLoai NVARCHAR(50), 
    @GiaVe DECIMAL(18,2), 
    @BaoGomAnUong BIT, 
    @MoTa VARCHAR(255)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa) 
        VALUES (@MaLoaiVe, @TenLoaiVe, @PhanLoai, @GiaVe, @BaoGomAnUong, @MoTa);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_LoaiVe 
    @MaLoaiVe NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM LoaiVe 
    WHERE (@MaLoaiVe IS NULL OR MaLoaiVe = @MaLoaiVe); 
END;
GO

CREATE PROCEDURE sp_Update_LoaiVe
    @MaLoaiVe NVARCHAR(10), 
    @TenLoaiVe VARCHAR(100), 
    @PhanLoai NVARCHAR(50), 
    @GiaVe DECIMAL(18,2), 
    @BaoGomAnUong BIT, 
    @MoTa VARCHAR(255)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE LoaiVe 
        SET TenLoaiVe = @TenLoaiVe, 
            PhanLoai = @PhanLoai, 
            GiaVe = @GiaVe, 
            BaoGomAnUong = @BaoGomAnUong, 
            MoTa = @MoTa 
        WHERE MaLoaiVe = @MaLoaiVe;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_LoaiVe 
    @MaLoaiVe NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM ChiTietHoaDonVe WHERE MaLoaiVe = @MaLoaiVe) 
           OR EXISTS (SELECT 1 FROM QuyenLoiVe_TroChoi WHERE MaLoaiVe = @MaLoaiVe)
        BEGIN
            ;THROW 50007, N'Loại vé đã phát sinh giao dịch hoặc đã thiết lập quyền lợi. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM LoaiVe WHERE MaLoaiVe = @MaLoaiVe;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: QuyenLoiVe_TroChoi (Bảng trung gian n-n)
-- =================================================================
CREATE PROCEDURE sp_Create_QuyenLoiVe_TroChoi
    @MaLoaiVe NVARCHAR(10), 
    @MaTroChoi NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO QuyenLoiVe_TroChoi (MaLoaiVe, MaTroChoi) 
        VALUES (@MaLoaiVe, @MaTroChoi);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_QuyenLoiVe_TroChoi 
    @MaLoaiVe NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM QuyenLoiVe_TroChoi 
    WHERE (@MaLoaiVe IS NULL OR MaLoaiVe = @MaLoaiVe); 
END;
GO

CREATE PROCEDURE sp_Delete_QuyenLoiVe_TroChoi
    @MaLoaiVe NVARCHAR(10), 
    @MaTroChoi NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        DELETE FROM QuyenLoiVe_TroChoi 
        WHERE MaLoaiVe = @MaLoaiVe AND MaTroChoi = @MaTroChoi;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: HoaDonVe
-- =================================================================
-- Ghi chú: CREATE đã có ở bản tối ưu ban đầu (sp_TaoHoaDonVe), dưới đây là R, U, D
CREATE PROCEDURE sp_Read_HoaDonVe 
    @MaHoaDon NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM HoaDonVe 
    WHERE (@MaHoaDon IS NULL OR MaHoaDon = @MaHoaDon); 
END;
GO

CREATE PROCEDURE sp_Update_HoaDonVe
    @MaHoaDon NVARCHAR(10), 
    @PhuongThucThanhToan VARCHAR(50), 
    @TrangThai VARCHAR(50)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE HoaDonVe 
        SET PhuongThucThanhToan = @PhuongThucThanhToan, 
            TrangThai = @TrangThai 
        WHERE MaHoaDon = @MaHoaDon;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_HoaDonVe 
    @MaHoaDon NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM ChiTietHoaDonVe WHERE MaHoaDon = @MaHoaDon)
        BEGIN
            ;THROW 50008, N'Hóa đơn đã có chi tiết, hãy xóa chi tiết trước!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM HoaDonVe WHERE MaHoaDon = @MaHoaDon;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: ChiTietHoaDonVe
-- =================================================================
CREATE PROCEDURE sp_Create_ChiTietHoaDonVe
    @MaChiTietHD NVARCHAR(10), 
    @MaHoaDon NVARCHAR(10), 
    @MaLoaiVe NVARCHAR(10), 
    @SoLuong INT, 
    @DonGia DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO ChiTietHoaDonVe (MaChiTietHD, MaHoaDon, MaLoaiVe, SoLuong, DonGia) 
        VALUES (@MaChiTietHD, @MaHoaDon, @MaLoaiVe, @SoLuong, @DonGia);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_ChiTietHoaDonVe 
    @MaHoaDon NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM ChiTietHoaDonVe 
    WHERE (@MaHoaDon IS NULL OR MaHoaDon = @MaHoaDon); 
END;
GO

CREATE PROCEDURE sp_Update_ChiTietHoaDonVe
    @MaChiTietHD NVARCHAR(10), 
    @SoLuong INT, 
    @DonGia DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE ChiTietHoaDonVe 
        SET SoLuong = @SoLuong, 
            DonGia = @DonGia 
        WHERE MaChiTietHD = @MaChiTietHD;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_ChiTietHoaDonVe 
    @MaChiTietHD NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM Ve WHERE MaChiTietHD = @MaChiTietHD)
        BEGIN
            ;THROW 50009, N'Chi tiết hóa đơn này đã xuất vé. Không thể xóa!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM ChiTietHoaDonVe WHERE MaChiTietHD = @MaChiTietHD;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: HoaDonCuaHang
-- =================================================================
CREATE PROCEDURE sp_Create_HoaDonCuaHang
    @MaHDCH NVARCHAR(10), 
    @MaCuaHang NVARCHAR(10), 
    @MaKhachHang NVARCHAR(10), 
    @MaNhanVien NVARCHAR(10), 
    @TongTien DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO HoaDonCuaHang (MaHDCH, MaCuaHang, MaKhachHang, MaNhanVien, TongTien) 
        VALUES (@MaHDCH, @MaCuaHang, @MaKhachHang, @MaNhanVien, @TongTien);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_HoaDonCuaHang 
    @MaHDCH NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM HoaDonCuaHang 
    WHERE (@MaHDCH IS NULL OR MaHDCH = @MaHDCH); 
END;
GO

CREATE PROCEDURE sp_Update_HoaDonCuaHang
    @MaHDCH NVARCHAR(10), 
    @TongTien DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE HoaDonCuaHang 
        SET TongTien = @TongTien 
        WHERE MaHDCH = @MaHDCH;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_HoaDonCuaHang 
    @MaHDCH NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM ChiTietHDCH WHERE MaHDCH = @MaHDCH)
        BEGIN
            ;THROW 50010, N'Hóa đơn cửa hàng đã có chi tiết, hãy xóa chi tiết trước!', 1;
        END
        ELSE 
        BEGIN
            DELETE FROM HoaDonCuaHang WHERE MaHDCH = @MaHDCH;
        END
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: ChiTietHDCH
-- =================================================================
CREATE PROCEDURE sp_Create_ChiTietHDCH
    @MaCTHDCH NVARCHAR(10), 
    @MaHDCH NVARCHAR(10), 
    @MaSanPham NVARCHAR(10), 
    @SoLuong INT, 
    @GiaBan DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO ChiTietHDCH (MaCTHDCH, MaHDCH, MaSanPham, SoLuong, GiaBan) 
        VALUES (@MaCTHDCH, @MaHDCH, @MaSanPham, @SoLuong, @GiaBan);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_ChiTietHDCH 
    @MaHDCH NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM ChiTietHDCH 
    WHERE (@MaHDCH IS NULL OR MaHDCH = @MaHDCH); 
END;
GO

CREATE PROCEDURE sp_Update_ChiTietHDCH
    @MaCTHDCH NVARCHAR(10), 
    @SoLuong INT, 
    @GiaBan DECIMAL(18,2)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE ChiTietHDCH 
        SET SoLuong = @SoLuong, 
            GiaBan = @GiaBan 
        WHERE MaCTHDCH = @MaCTHDCH;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_ChiTietHDCH 
    @MaCTHDCH NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        DELETE FROM ChiTietHDCH WHERE MaCTHDCH = @MaCTHDCH;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: LichLamViec
-- =================================================================
CREATE PROCEDURE sp_Create_LichLamViec
    @MaLich NVARCHAR(10), 
    @MaNhanVien NVARCHAR(10), 
    @MaCa NVARCHAR(10), 
    @NgayLamViec DATE, 
    @ViTriPhanCong VARCHAR(100)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO LichLamViec (MaLich, MaNhanVien, MaCa, NgayLamViec, ViTriPhanCong) 
        VALUES (@MaLich, @MaNhanVien, @MaCa, @NgayLamViec, @ViTriPhanCong);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_LichLamViec 
    @MaNhanVien NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM LichLamViec 
    WHERE (@MaNhanVien IS NULL OR MaNhanVien = @MaNhanVien); 
END;
GO

CREATE PROCEDURE sp_Update_LichLamViec
    @MaLich NVARCHAR(10), 
    @MaCa NVARCHAR(10), 
    @NgayLamViec DATE, 
    @ViTriPhanCong VARCHAR(100)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE LichLamViec 
        SET MaCa = @MaCa, 
            NgayLamViec = @NgayLamViec, 
            ViTriPhanCong = @ViTriPhanCong 
        WHERE MaLich = @MaLich;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_LichLamViec 
    @MaLich NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY 
        DELETE FROM LichLamViec WHERE MaLich = @MaLich; 
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

-- =================================================================
-- CRUD CHO BẢNG: BaoTriTroChoi
-- =================================================================
-- Ghi chú: Logic Create phức tạp đã nằm ở sp_GhiNhanBaoTri (từ trước), ở đây mình bổ sung đủ form
CREATE PROCEDURE sp_Create_BaoTriTroChoi
    @MaBaoTri NVARCHAR(10), 
    @MaTroChoi NVARCHAR(10), 
    @MaNhanVien NVARCHAR(10), 
    @NgayBatDau DATE, 
    @NgayDuKienXong DATE, 
    @MoTaLoi NVARCHAR(500), 
    @ChiPhiBaoTri DECIMAL(18,2), 
    @TrangThai NVARCHAR(50)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        INSERT INTO BaoTriTroChoi (MaBaoTri, MaTroChoi, MaNhanVien, NgayBatDau, NgayDuKienXong, MoTaLoi, ChiPhiBaoTri, TrangThai)
        VALUES (@MaBaoTri, @MaTroChoi, @MaNhanVien, @NgayBatDau, @NgayDuKienXong, @MoTaLoi, @ChiPhiBaoTri, @TrangThai);
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Read_BaoTriTroChoi 
    @MaTroChoi NVARCHAR(10) = NULL
AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT * FROM BaoTriTroChoi 
    WHERE (@MaTroChoi IS NULL OR MaTroChoi = @MaTroChoi); 
END;
GO

CREATE PROCEDURE sp_Update_BaoTriTroChoi
    @MaBaoTri NVARCHAR(10), 
    @NgayDuKienXong DATE, 
    @MoTaLoi NVARCHAR(500), 
    @ChiPhiBaoTri DECIMAL(18,2), 
    @TrangThai NVARCHAR(50)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY
        UPDATE BaoTriTroChoi 
        SET NgayDuKienXong = @NgayDuKienXong, 
            MoTaLoi = @MoTaLoi, 
            ChiPhiBaoTri = @ChiPhiBaoTri, 
            TrangThai = @TrangThai 
        WHERE MaBaoTri = @MaBaoTri;
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO

CREATE PROCEDURE sp_Delete_BaoTriTroChoi 
    @MaBaoTri NVARCHAR(10)
AS 
BEGIN 
    SET NOCOUNT ON; 
    BEGIN TRY 
        DELETE FROM BaoTriTroChoi WHERE MaBaoTri = @MaBaoTri; 
    END TRY 
    BEGIN CATCH 
        ;THROW; 
    END CATCH 
END;
GO
-- =================================================================
-- SP NGIỆP VỤ: BẢO TRÌ & TẠO HÓA ĐƠN
-- =================================================================

-- 8.1. Ghi nhận báo cáo bảo trì
CREATE PROCEDURE sp_GhiNhanBaoTri
    @MaBaoTri NVARCHAR(10),
    @MaTroChoi NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MoTaLoi NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Thêm lịch sử bảo trì
        INSERT INTO BaoTriTroChoi (MaBaoTri, MaTroChoi, MaNhanVien, NgayBatDau, MoTaLoi, TrangThai)
        VALUES (@MaBaoTri, @MaTroChoi, @MaNhanVien, GETDATE(), @MoTaLoi, N'Đang xử lý');

        -- 2. Cập nhật trạng thái trò chơi
        UPDATE TroChoi
        SET TrangThai = N'Đang bảo trì'
        WHERE MaTroChoi = @MaTroChoi;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- C# sẽ bắt được lỗi này qua SqlException
        IF @@TRANCOUNT > 0 
            ROLLBACK TRANSACTION;
            
        ;THROW; 
    END CATCH
END;
GO

-- 8.2. Hóa đơn tự tính toán và thêm
CREATE PROCEDURE sp_TaoHoaDonVe
    @MaHoaDon NVARCHAR(10),
    @MaKhachHang NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MaSuKien NVARCHAR(10) = NULL,
    @TongTienGoc DECIMAL(18,2),
    @PhuongThucThanhToan VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @ChietKhau DECIMAL(18,2) = 0;
        DECLARE @PhanTramGiam DECIMAL(5,2) = 0;
        DECLARE @GiamToiDa DECIMAL(18,2) = 0;

        -- Kiểm tra sự kiện giảm giá nếu có
        IF @MaSuKien IS NOT NULL
        BEGIN
            SELECT @PhanTramGiam = PhanTramGiam, @GiamToiDa = ISNULL(GiamToiDa, 0)
            FROM SuKien 
            WHERE MaSuKien = @MaSuKien 
              AND TrangThai = 1 
              AND GETDATE() BETWEEN NgayBatDau AND NgayKetThuc;

            IF @PhanTramGiam > 0
            BEGIN
                SET @ChietKhau = @TongTienGoc * (@PhanTramGiam / 100.0);
                
                -- Ràng buộc mức giảm tối đa
                IF @GiamToiDa > 0 AND @ChietKhau > @GiamToiDa
                BEGIN
                    SET @ChietKhau = @GiamToiDa;
                END
            END
        END

        BEGIN TRANSACTION;

        -- Thêm mới hóa đơn
        INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, MaSuKien, NgayMua, ChietKhauDoan, TongTien, PhuongThucThanhToan, TrangThai)
        VALUES (@MaHoaDon, @MaKhachHang, @MaNhanVien, @MaSuKien, GETDATE(), @ChietKhau, (@TongTienGoc - @ChietKhau), @PhuongThucThanhToan, N'Đã thanh toán');

        COMMIT TRANSACTION;
        
        -- Trả về tổng tiền cuối cùng cho C# (sử dụng ExecuteScalar hoặc ExecuteReader)
        SELECT (@TongTienGoc - @ChietKhau) AS TongTienThanhToan;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 
            ROLLBACK TRANSACTION;
            
        ;THROW; 
    END CATCH
END;
GO