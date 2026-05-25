USE VinWonders_Management;
GO

-- ==========================================================
-- 1. DỮ LIỆU BẢNG CHA (Hạng Thành Viên, Khu Vực, Ca Làm Việc)
-- ==========================================================
INSERT INTO HangThanhVien (MaHang, TenHang, DiemToiThieu, TiLeGiamGia) VALUES
('HTV01', N'Thành viên Chuẩn', 0, 0),
('HTV02', N'Thành viên Bạc', 1000, 5.00),
('HTV03', N'Thành viên Vàng', 5000, 10.00),
('HTV04', N'Thành viên Kim Cương', 10000, 15.00);

INSERT INTO KhuVuc (MaKhuVuc, TenKhuVuc, MoTa, GioMoCua, GioDongCua) VALUES
('KV01', N'Khu Cảm Giác Mạnh', N'Tập trung các trò chơi mạo hiểm', '08:00', '22:00'),
('KV02', N'Công Viên Nước', N'Khu vui chơi dưới nước', '09:00', '18:00'),
('KV03', N'Khu Gia Đình & Trẻ Em', N'Phù hợp cho gia đình có trẻ nhỏ', '08:00', '22:00');

INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) VALUES
('CA01', N'Ca Sáng', '07:30', '15:30'),
('CA02', N'Ca Chiều', '15:00', '22:30'),
('CA03', N'Ca Tối (Bảo vệ)', '22:00', '06:00'),
('CA04', N'Ca Hành Chính', '08:00', '17:00'),
('CA05', N'Ca Gãy (F&B)', '10:00', '14:00');

-- ==========================================================
-- 2. DỮ LIỆU TÀI KHOẢN VÀ NHÂN VIÊN
-- ==========================================================
INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, QuyenTruyCap, TrangThai) VALUES
('TK01', 'admin', 'admin123', 'Admin', 1),
('TK02', 'thungan01', '123456', 'ThuNgan', 1),
('TK03', 'quanly01', '123456', 'QuanLy', 1),
('TK04', 'thungan02', '123456', 'ThuNgan', 1),
('TK05', 'quanly02', '123456', 'QuanLy', 1);

INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam) VALUES
-- 3 nhân viên cũ đã được bổ sung thêm CCCD
('NV01', 'TK01', N'Nguyễn Quản Trị', N'Nam', '1990-01-01', '0901234567', 'admin@vinwonders.com', '079000000001', N'Quản trị hệ thống', 25000000, '2020-01-01'),
('NV02', 'TK02', N'Trần Thu Ngân', N'Nữ', '1998-05-15', '0987654321', 'thungan1@vinwonders.com', '079000000002', N'Thu ngân quầy vé', 10000000, '2023-05-01'),
('NV03', 'TK03', N'Lê Trưởng Ca', N'Nam', '1992-08-20', '0911222333', 'quanly1@vinwonders.com', '079000000003', N'Quản lý vận hành', 18000000, '2021-02-15'),

-- 5 nhân viên mới của bạn giữ nguyên
('NV04', 'TK04', N'Lê Thị Thu', N'Nữ', '2000-10-10', '0988777666', 'thungan02@vinwonders.com', '079123456789', N'Thu ngân quầy vé', 9500000, '2023-06-01'),
('NV05', 'TK05', N'Trần Văn Sếp', N'Nam', '1985-02-28', '0912345678', 'quanly02@vinwonders.com', '079987654321', N'Quản lý khu nước', 20000000, '2020-05-15'),
('NV06', NULL, N'Bùi Văn Bảo', N'Nam', '1975-08-14', '0909090909', NULL, '079111222333', N'Bảo vệ', 7000000, '2022-01-01'),
('NV07', NULL, N'Nguyễn Thị Tấm', N'Nữ', '1980-04-30', '0933333333', NULL, '079444555666', N'Nhân viên vệ sinh', 6500000, '2021-11-20'),
('NV08', NULL, N'Đặng Văn Chơi', N'Nam', '1995-12-12', '0977777777', NULL, '079777888999', N'Vận hành trò chơi', 8500000, '2022-03-10');

-- ==========================================================
-- 3. DỮ LIỆU KHÁCH HÀNG (Cho màn hình tạo Hóa Đơn)
-- ==========================================================
INSERT INTO KhachHang (MaKhachHang, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy) VALUES
-- 3 Khách hàng cũ đã được chèn thêm 2 giá trị NULL cho (NgaySinh, DiaChi)
('KH01', 'HTV01', N'Khách Vãng Lai', N'Cá nhân', NULL, NULL, '0000000000', NULL, 0), 
('KH02', 'HTV02', N'Phạm Văn B', N'Cá nhân', NULL, NULL, '0933444555', 'vanb@gmail.com', 1200),
('KH03', 'HTV03', N'Đoàn Công Ty ABC', N'Khách đoàn', NULL, NULL, '0944555666', 'contact@abc.com', 5500),

-- 5 Khách hàng mới giữ nguyên
('KH04', 'HTV01', N'Hoàng Văn Hùng', N'Cá nhân', '1990-05-20', N'Quận 1, TP.HCM', '0901112223', 'hunghv@gmail.com', 500),
('KH05', 'HTV02', N'Trương Thu Hà', N'Cá nhân', '1988-11-11', N'Nha Trang, Khánh Hòa', '0982223334', 'hatruong@yahoo.com', 2500),
('KH06', 'HTV04', N'Trần Đại Gia', N'Cá nhân', '1970-01-01', N'Quận 7, TP.HCM', '0999999999', 'daigia@vip.com', 15000),
('KH07', 'HTV03', N'Trường THPT Lê Hồng Phong', N'Khách đoàn', NULL, N'Quận 5, TP.HCM', '0283838383', 'contact@lhp.edu.vn', 8000),
('KH08', 'HTV01', N'Công ty Du lịch Hạnh Phúc', N'Khách đoàn', NULL, N'Đà Nẵng', '0236123456', 'booking@hanhphuctravel.vn', 0);

-- ==========================================================
-- 4. DỮ LIỆU LOẠI VÉ (Đúng theo góp ý của giáo viên)
-- ==========================================================
INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa) VALUES
('LV01', N'Vé Tham Quan', N'Vé vào cổng', 350000, 0, N'Chỉ qua cổng tham quan, không chơi trò chơi'),
('LV02', N'Vé Trọn Gói', N'Vé trọn gói', 850000, 0, N'Được chơi tất cả các trò chơi trong khu vực'),
('LV03', N'Combo Trọn Gói + Buffet', N'Combo ăn trưa', 1200000, 1, N'Vui chơi trọn gói và kèm 1 suất Buffet trưa 10h-12h');

-- ==========================================================
-- 5. DỮ LIỆU TRÒ CHƠI & QUYỀN LỢI VÉ
-- ==========================================================
INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai) VALUES
('TC01', 'KV01', N'Tàu Lượn Siêu Tốc', N'Cảm giác mạnh', 130, 14, 24, N'Đang hoạt động'),
('TC02', 'KV01', N'Đu Quay Dây Văng', N'Cảm giác mạnh', 120, 12, 30, N'Đang hoạt động'),
('TC03', 'KV02', N'Đường Trượt Lốc Xoáy', N'Trò chơi nước', 140, 14, 4, N'Đang hoạt động'),
('TC04', 'KV03', N'Vòng Quay Ngựa Gỗ', N'Trò chơi gia đình', 0, 3, 20, N'Đang hoạt động');

-- Áp dụng logic quyền lợi: Chỉ có LV02 và LV03 mới được chơi trò chơi
INSERT INTO QuyenLoiVe_TroChoi (MaLoaiVe, MaTroChoi) VALUES
('LV02', 'TC01'), ('LV02', 'TC02'), ('LV02', 'TC03'), ('LV02', 'TC04'), -- Trọn gói chơi hết
('LV03', 'TC01'), ('LV03', 'TC02'), ('LV03', 'TC03'), ('LV03', 'TC04'); -- Combo chơi hết
-- Lưu ý: Không Insert LV01 vào bảng này vì Vé Tham Quan không được chơi trò chơi.

-- ==========================================================
-- 6. DỮ LIỆU DỊCH VỤ CỬA HÀNG & F&B (Món ăn, Nước uống)
-- ==========================================================
INSERT INTO CuaHang (MaCuaHang, MaKhuVuc, TenCuaHang, LoaiCuaHang, TrangThai) VALUES
('CH01', 'KV01', N'Quầy Fastfood Thần Tốc', N'Quầy Fastfood', N'Đang hoạt động'),
('CH02', 'KV03', N'Nhà Hàng Buffet Lâu Đài', N'Nhà hàng Buffet', N'Đang hoạt động'),
('CH03', 'KV02', N'Quầy Lưu Niệm Đại Dương', N'Quầy Lưu niệm', N'Đang hoạt động');

INSERT INTO SanPham (MaSanPham, MaCuaHang, TenSanPham, LoaiSanPham, GiaBan, TrangThaiBan) VALUES
('SP01', 'CH01', N'Combo Gà Rán Khoai Tây', N'Món chính', 95000, N'Còn hàng'),
('SP02', 'CH01', N'Nước Ngọt Cola Size L', N'Đồ uống', 35000, N'Còn hàng'),
('SP03', 'CH02', N'Buffet Trưa Người Lớn', N'Dịch vụ F&B', 350000, N'Còn hàng'),
('SP04', 'CH03', N'Gấu Bông VinWonders', N'Lưu niệm', 150000, N'Còn hàng'),
('SP05', 'CH01', N'Xúc Xích Nướng Đức', N'Ăn vặt', 45000, N'Hết hàng');

-- ==========================================================
-- 7. DỮ LIỆU MẪU HÓA ĐƠN & VÉ (Test hiển thị lên DataGridView)
-- ==========================================================
-- Hóa đơn 1: Bán cho khách vãng lai, mua 2 vé trọn gói
INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, TongTien, PhuongThucThanhToan, TrangThai) VALUES
('HDV001', 'KH01', 'NV02', 1700000, N'Tiền mặt', N'Đã thanh toán');

INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung) VALUES
('V0001', 'HDV001', 'LV02', 850000, CAST(GETDATE() AS DATE), 0),
('V0002', 'HDV001', 'LV02', 850000, CAST(GETDATE() AS DATE), 0);

-- Hóa đơn 2: Bán cho khách đoàn, mua 5 vé Combo (Có chiết khấu 10% = 600k)
INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, ChietKhauDoan, TongTien, PhuongThucThanhToan, TrangThai) VALUES
('HDV002', 'KH03', 'NV02', 600000, 5400000, N'Chuyển khoản', N'Đã thanh toán');

INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung) VALUES
('V0003', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 1), -- Đã quét vé cổng
('V0004', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 1),
('V0005', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0),
('V0006', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0),
('V0007', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0);

-- ==========================================================
-- 5. THÊM LỊCH LÀM VIỆC (Test giao diện DataGridView Lịch làm việc)
-- ==========================================================
-- Lưu ý: Bạn có thể đổi ngày '2024-05-25' thành ngày hiện tại để test dễ hơn
INSERT INTO LichLamViec (MaLich, MaNhanVien, MaCa, NgayLamViec, ViTriPhanCong) VALUES
('LLV001', 'NV02', 'CA01', '2024-05-25', N'Quầy vé Cổng chính'),
('LLV002', 'NV04', 'CA02', '2024-05-25', N'Quầy vé Cổng chính'),
('LLV003', 'NV05', 'CA04', '2024-05-25', N'Văn phòng Quản lý Khu 2'),
('LLV004', 'NV06', 'CA03', '2024-05-25', N'Tuần tra Cổng phụ'),
('LLV005', 'NV07', 'CA01', '2024-05-25', N'Vệ sinh khu nhà hàng'),
('LLV006', 'NV08', 'CA02', '2024-05-25', N'Trực Tàu lượn siêu tốc'),

('LLV007', 'NV02', 'CA02', '2024-05-26', N'Quầy vé Cổng chính'),
('LLV008', 'NV04', 'CA01', '2024-05-26', N'Quầy vé Cổng chính'),
('LLV009', 'NV08', 'CA01', '2024-05-26', N'Trực Đu quay dây văng');