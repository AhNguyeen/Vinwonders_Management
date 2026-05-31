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
-- THÊM 95 NHÂN VIÊN MỚI (TỪ ẢNH VINPEARL/VINWONDERS)
-- ==========================================================
INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam) VALUES
('NV21430001', NULL, N'Nguyễn Văn An', N'Nam', '1995-02-15', '0912000001', 'nguyenvanan1@gmail.com', '079100000001', N'Tổ trưởng Phục vụ', 12000000, '2023-01-10'),
('NV21430002', NULL, N'Trần Thị Bình', N'Nữ', '1998-05-20', '0912000002', 'tranthibinh2@gmail.com', '079100000002', N'Tổ trưởng Kỹ thuật ME', 13500000, '2022-04-12'),
('NV21430003', NULL, N'Lê Minh Châu', N'Nữ', '2000-08-10', '0912000003', 'leminhchau3@gmail.com', '079100000003', N'Chuyên viên Phục vụ Cao cấp', 11000000, '2023-06-15'),
('NV21430004', NULL, N'Phạm Hữu Dũng', N'Nam', '1992-11-25', '0912000004', 'phamhuudung4@gmail.com', '079100000004', N'Đầu bếp Cao cấp Âu/Bánh', 18000000, '2021-02-28'),
('NV21430005', NULL, N'Hoàng Thị Giang', N'Nữ', '1997-01-05', '0912000005', 'hoangthigiang5@gmail.com', '079100000005', N'Đầu bếp Âu/Lạnh', 15000000, '2021-11-11'),
('NV21430006', NULL, N'Vũ Hải Hà', N'Nữ', '1999-07-14', '0912000006', 'vuhaiha6@gmail.com', '079100000006', N'Nhân viên Tạp vụ', 6500000, '2024-01-05'),
('NV21430007', NULL, N'Võ Văn Hùng', N'Nam', '1994-03-30', '0912000007', 'vovanhung7@gmail.com', '079100000007', N'Nhân viên Kỹ thuật', 9500000, '2022-09-09'),
('NV21430008', NULL, N'Đặng Thanh Hương', N'Nữ', '1996-12-12', '0912000008', 'dangthanhhuong8@gmail.com', '079100000008', N'Nhân viên Lễ tân/SC', 8500000, '2023-03-22'),
('NV21430009', NULL, N'Bùi Khắc Khang', N'Nam', '1991-04-18', '0912000009', 'buikhackhang9@gmail.com', '079100000009', N'Nhân viên Hành lý', 7500000, '2021-07-30'),
('NV21430010', NULL, N'Đỗ Thị Linh', N'Nữ', '2001-09-22', '0912000010', 'dothilinh10@gmail.com', '079100000010', N'Nhân viên Đón tiếp Nhà hàng/Tiền sảnh', 8000000, '2023-10-10'),

('NV21430011', NULL, N'Nguyễn Ngọc Mai', N'Nữ', '1998-02-14', '0912000011', 'nguyenngocmai11@gmail.com', '079100000011', N'Nhân viên Pha chế (Rượu)', 10000000, '2022-12-01'),
('NV21430012', NULL, N'Trần Xuân Nam', N'Nam', '1993-06-08', '0912000012', 'tranxuannam12@gmail.com', '079100000012', N'Nhân viên Phục vụ (Buffet/Room)', 7000000, '2024-02-15'),
('NV21430013', NULL, N'Lê Thị Oanh', N'Nữ', '1995-10-19', '0912000013', 'lethioanh13@gmail.com', '079100000013', N'Nhân viên Giặt là (Ca đêm)', 8500000, '2023-08-08'),
('NV21430014', NULL, N'Phạm Tuấn Phong', N'Nam', '1990-12-25', '0912000014', 'phamtuanphong14@gmail.com', '079100000014', N'Nhân viên Bảo mẫu', 9000000, '2021-05-18'),
('NV21430015', NULL, N'Hoàng Lệ Quyên', N'Nữ', '1997-04-30', '0912000015', 'hoanglequyen15@gmail.com', '079100000015', N'Đội trưởng Kỹ thuật', 14000000, '2022-03-25'),
('NV21430016', NULL, N'Vũ Trường Sơn', N'Nam', '1992-08-15', '0912000016', 'vutruongson16@gmail.com', '079100000016', N'Tổ trưởng Lễ tân - Thu ngân', 12500000, '2021-10-10'),
('NV21430017', NULL, N'Võ Thu Trang', N'Nữ', '2000-01-20', '0912000017', 'vothutrang17@gmail.com', '079100000017', N'Tổ trưởng Housekeeping', 11500000, '2023-11-20'),
('NV21430018', NULL, N'Đặng Quốc Tuấn', N'Nam', '1994-05-12', '0912000018', 'dangquoctuan18@gmail.com', '079100000018', N'Tổ trưởng Kỹ thuật BM/ME', 14500000, '2020-12-12'),
('NV21430019', NULL, N'Bùi Phương Uyên', N'Nữ', '1996-09-05', '0912000019', 'buiphuonguyen19@gmail.com', '079100000019', N'Tổ trưởng Bảo dưỡng cỏ & CQMT', 13000000, '2022-07-07'),
('NV21430020', NULL, N'Đỗ Quang Vinh', N'Nam', '1991-03-28', '0912000020', 'doquangvinh20@gmail.com', '079100000020', N'Nhân viên Lễ tân - Thu ngân', 8500000, '2021-04-14'),

('NV21430021', NULL, N'Nguyễn Hải Yến', N'Nữ', '1999-11-11', '0912000021', 'nguyenhaiyen21@gmail.com', '079100000021', N'Nhân viên Bảo dưỡng cỏ', 7500000, '2023-05-05'),
('NV21430022', NULL, N'Trần Văn Bách', N'Nam', '1985-02-20', '0912000022', 'tranvanbach22@gmail.com', '079100000022', N'Trưởng bộ phận Nhân sự', 22000000, '2019-08-15'),
('NV21430023', NULL, N'Lê Kim Cúc', N'Nữ', '1998-07-07', '0912000023', 'lekimcuc23@gmail.com', '079100000023', N'Tổ trưởng Cứu hộ', 12000000, '2022-06-20'),
('NV21430024', NULL, N'Phạm Tiến Đạt', N'Nam', '1993-10-15', '0912000024', 'phamtiendat24@gmail.com', '079100000024', N'Chuyên viên Kinh doanh', 15000000, '2021-09-09'),
('NV21430025', NULL, N'Hoàng Thị Én', N'Nữ', '1995-12-01', '0912000025', 'hoangthien25@gmail.com', '079100000025', N'Nhân viên Housekeeping/Cây xanh', 7000000, '2023-01-25'),
('NV21430026', NULL, N'Vũ Đình Giao', N'Nam', '1997-03-08', '0912000026', 'vudinhgiao26@gmail.com', '079100000026', N'Nhân viên Hướng dẫn', 8000000, '2022-11-11'),
('NV21430027', NULL, N'Võ Cẩm Hiền', N'Nữ', '2000-06-25', '0912000027', 'vocamhien27@gmail.com', '079100000027', N'Nhân viên Cứu hộ', 8500000, '2024-03-10'),
('NV21430028', NULL, N'Đặng Văn Kiên', N'Nam', '1992-09-30', '0912000028', 'dangvankien28@gmail.com', '079100000028', N'TBP Tổ chức Sự kiện', 20000000, '2020-05-15'),
('NV21430029', NULL, N'Bùi Thị Liễu', N'Nữ', '1994-01-14', '0912000029', 'buithilieu29@gmail.com', '079100000029', N'Nhân viên Bán hàng', 7500000, '2023-08-20'),
('NV21430030', NULL, N'Đỗ Nhật Minh', N'Nam', '1996-04-10', '0912000030', 'donhatminh30@gmail.com', '079100000030', N'Nhân viên Cây xanh', 7000000, '2021-12-05'),

('NV21430031', NULL, N'Nguyễn Ái Nữ', N'Nữ', '1988-08-22', '0912000031', 'nguyenainu31@gmail.com', '079100000031', N'Trưởng Bộ phận Công viên nước', 25000000, '2019-10-10'),
('NV21430032', NULL, N'Trần Đức Phú', N'Nam', '1991-11-05', '0912000032', 'tranducphu32@gmail.com', '079100000032', N'Trợ lý Tổng Quản lý', 23000000, '2020-02-28'),
('NV21430033', NULL, N'Lê Diễm Quỳnh', N'Nữ', '1993-02-18', '0912000033', 'lediemquynh33@gmail.com', '079100000033', N'Bếp trưởng', 22000000, '2021-04-15'),
('NV21430034', NULL, N'Phạm Cao Sáng', N'Nam', '1995-07-30', '0912000034', 'phamcaosang34@gmail.com', '079100000034', N'Tổ trưởng Kiểm soát cổng', 12000000, '2022-09-05'),
('NV21430035', NULL, N'Hoàng Bích Tâm', N'Nữ', '1997-10-12', '0912000035', 'hoangbichtam35@gmail.com', '079100000035', N'Chuyên viên Nhân sự(Quan hệ Lao động)', 14000000, '2023-01-20'),
('NV21430036', NULL, N'Vũ Quốc Uy', N'Nam', '1999-01-25', '0912000036', 'vuquocuy36@gmail.com', '079100000036', N'Chuyên viên Hành chính (Kỹ thuật)', 13500000, '2024-02-10'),
('NV21430037', NULL, N'Võ Hà Vi', N'Nữ', '2001-05-09', '0912000037', 'vohavi37@gmail.com', '079100000037', N'Nhân viên Chăm sóc Động vật Thuỷ cung', 9500000, '2023-07-15'),
('NV21430038', NULL, N'Đặng Khắc Việt', N'Nam', '1994-08-21', '0912000038', 'dangkhacviet38@gmail.com', '079100000038', N'Nhân viên Lễ tân Thu ngân', 8500000, '2021-11-25'),
('NV21430039', NULL, N'Bùi Tường Vy', N'Nữ', '1996-12-04', '0912000039', 'buituongvy39@gmail.com', '079100000039', N'Đầu bếp Cao cấp Á/Âu', 17000000, '2022-03-30'),
('NV21430040', NULL, N'Đỗ Hoàng Xuân', N'Nam', '1990-03-17', '0912000040', 'dohoangxuan40@gmail.com', '079100000040', N'Đầu bếp Á/Âu', 14500000, '2020-08-08'),

('NV21430041', NULL, N'Nguyễn Thị Yến', N'Nữ', '1998-06-29', '0912000041', 'nguyenthiyen41@gmail.com', '079100000041', N'Nhân viên Cứu hộ/ Thợ lặn', 10500000, '2023-04-12'),
('NV21430042', NULL, N'Trần Bảo Ân', N'Nam', '1992-09-10', '0912000042', 'tranbaoan42@gmail.com', '079100000042', N'Nhân viên Phục vụ', 7000000, '2021-06-05'),
('NV21430043', NULL, N'Lê Mai Bích', N'Nữ', '1995-11-22', '0912000043', 'lemaibich43@gmail.com', '079100000043', N'Nhân viên Biểu diễn Động vật', 11000000, '2022-10-18'),
('NV21430044', NULL, N'Phạm Tiến Công', N'Nam', '1997-02-05', '0912000044', 'phamtiencong44@gmail.com', '079100000044', N'Kỹ thuật viên Thú y', 12500000, '2023-09-22'),
('NV21430045', NULL, N'Hoàng Thùy Dương', N'Nữ', '1999-05-18', '0912000045', 'hoangthuyduong45@gmail.com', '079100000045', N'Đầu bếp Bếp Á', 13000000, '2024-01-30'),
('NV21430046', NULL, N'Vũ Thành Đạt', N'Nam', '1991-08-30', '0912000046', 'vuthanhdat46@gmail.com', '079100000046', N'Tổ trưởng PA/ Buồng Phòng', 11500000, '2020-11-15'),
('NV21430047', NULL, N'Võ Lan Phương', N'Nữ', '1993-12-12', '0912000047', 'volanphuong47@gmail.com', '079100000047', N'Đầu bếp Cao cấp Âu/ Ấn/ Lạnh', 17500000, '2021-02-20'),
('NV21430048', NULL, N'Đặng Hữu Phước', N'Nam', '1996-03-26', '0912000048', 'danghuuphuoc48@gmail.com', '079100000048', N'Đầu bếp Á/ Âu/ Ấn/Lạnh/ ALC/ Canteen', 16000000, '2022-05-10'),
('NV21430049', NULL, N'Bùi Thu Cúc', N'Nữ', '1998-07-09', '0912000049', 'buithucuc49@gmail.com', '079100000049', N'Nhân viên Đón tiếp/ Service Centre', 8500000, '2023-08-25'),
('NV21430050', NULL, N'Đỗ Thái Học', N'Nam', '2000-10-21', '0912000050', 'dothaihoc50@gmail.com', '079100000050', N'Nhân viên Phục vụ ALC/Buffet', 7500000, '2024-03-05'),

('NV21430051', NULL, N'Nguyễn Hồng Hoa', N'Nữ', '1994-01-02', '0912000051', 'nguyenhonghoa51@gmail.com', '079100000051', N'Nhân viên Kỹ thuật Bảo trì/ATAS', 10500000, '2022-12-12'),
('NV21430052', NULL, N'Trần Minh Khang', N'Nam', '1990-04-16', '0912000052', 'tranminhkhang52@gmail.com', '079100000052', N'Tổ trưởng Phục vụ', 12000000, '2021-07-28'),
('NV21430053', NULL, N'Lê Trúc Ly', N'Nữ', '1992-06-28', '0912000053', 'letrucly53@gmail.com', '079100000053', N'Tổ trưởng Kỹ thuật ME', 13500000, '2020-09-10'),
('NV21430054', NULL, N'Phạm Hoàng Long', N'Nam', '1995-10-10', '0912000054', 'phamhoanglong54@gmail.com', '079100000054', N'Chuyên viên Phục vụ Cao cấp', 11000000, '2022-01-20'),
('NV21430055', NULL, N'Hoàng Nguyệt Nga', N'Nữ', '1997-01-23', '0912000055', 'hoangnguyetnga55@gmail.com', '079100000055', N'Đầu bếp Cao cấp Âu/Bánh', 18000000, '2023-04-05'),
('NV21430056', NULL, N'Vũ Hữu Nghĩa', N'Nam', '1999-04-06', '0912000056', 'vuhuunghia56@gmail.com', '079100000056', N'Đầu bếp Âu/Lạnh', 15000000, '2024-02-18'),
('NV21430057', NULL, N'Võ Kim Oanh', N'Nữ', '1991-07-19', '0912000057', 'vokimoanh57@gmail.com', '079100000057', N'Nhân viên Tạp vụ', 6500000, '2020-10-30'),
('NV21430058', NULL, N'Đặng Thanh Phong', N'Nam', '1993-10-31', '0912000058', 'dangthanhphong58@gmail.com', '079100000058', N'Nhân viên Kỹ thuật', 9500000, '2021-12-15'),
('NV21430059', NULL, N'Bùi Thị Quyên', N'Nữ', '1996-02-12', '0912000059', 'buithiquyen59@gmail.com', '079100000059', N'Nhân viên Lễ tân/SC', 8500000, '2023-03-01'),
('NV21430060', NULL, N'Đỗ Thái Sơn', N'Nam', '1998-05-26', '0912000060', 'dothaison60@gmail.com', '079100000060', N'Nhân viên Hành lý', 7500000, '2022-06-14'),

('NV21430061', NULL, N'Nguyễn Thủy Tiên', N'Nữ', '2000-09-08', '0912000061', 'nguyenthuytien61@gmail.com', '079100000061', N'Nhân viên Đón tiếp Nhà hàng/Tiền sảnh', 8000000, '2023-11-20'),
('NV21430062', NULL, N'Trần Anh Tuấn', N'Nam', '1989-12-21', '0912000062', 'trananhtuan62@gmail.com', '079100000062', N'Nhân viên Pha chế (Rượu)', 10000000, '2019-05-10'),
('NV21430063', NULL, N'Lê Tú Uyên', N'Nữ', '1992-03-05', '0912000063', 'letuuyen63@gmail.com', '079100000063', N'Nhân viên Phục vụ (Buffet/Room)', 7000000, '2021-08-25'),
('NV21430064', NULL, N'Phạm Quang Vinh', N'Nam', '1994-06-17', '0912000064', 'phamquangvinh64@gmail.com', '079100000064', N'Nhân viên Giặt là (Ca đêm)', 8500000, '2022-10-05'),
('NV21430065', NULL, N'Hoàng Yến Vy', N'Nữ', '1996-09-29', '0912000065', 'hoangyenvy65@gmail.com', '079100000065', N'Nhân viên Bảo mẫu', 9000000, '2023-01-15'),
('NV21430066', NULL, N'Vũ Ngọc Anh', N'Nam', '1998-12-11', '0912000066', 'vungocanh66@gmail.com', '079100000066', N'Đội trưởng Kỹ thuật', 14000000, '2024-04-22'),
('NV21430067', NULL, N'Võ Mỹ Duyên', N'Nữ', '1990-03-25', '0912000067', 'vomyduyen67@gmail.com', '079100000067', N'Tổ trưởng Lễ tân - Thu ngân', 12500000, '2020-07-07'),
('NV21430068', NULL, N'Đặng Trọng Cảnh', N'Nam', '1993-07-08', '0912000068', 'dangtrongcanh68@gmail.com', '079100000068', N'Tổ trưởng Housekeeping', 11500000, '2021-09-18'),
('NV21430069', NULL, N'Bùi Hoài Thu', N'Nữ', '1995-10-20', '0912000069', 'buihoaithu69@gmail.com', '079100000069', N'Tổ trưởng Kỹ thuật BM/ME', 14500000, '2022-11-28'),
('NV21430070', NULL, N'Đỗ Chí Kiên', N'Nam', '1997-01-02', '0912000070', 'dochikien70@gmail.com', '079100000070', N'Tổ trưởng Bảo dưỡng cỏ & CQMT', 13000000, '2023-05-10'),

('NV21430071', NULL, N'Nguyễn Nhã Phương', N'Nữ', '1999-04-15', '0912000071', 'nguyennhaphuong71@gmail.com', '079100000071', N'Nhân viên Lễ tân - Thu ngân', 8500000, '2024-01-20'),
('NV21430072', NULL, N'Trần Công Lý', N'Nam', '1991-07-27', '0912000072', 'trancongly72@gmail.com', '079100000072', N'Nhân viên Bảo dưỡng cỏ', 7500000, '2021-12-05'),
('NV21430073', NULL, N'Lê Hồng Nhung', N'Nữ', '1993-10-09', '0912000073', 'lehongnhung73@gmail.com', '079100000073', N'Tổ trưởng Cứu hộ', 12000000, '2022-02-14'),
('NV21430074', NULL, N'Phạm Tiến Minh', N'Nam', '1996-01-22', '0912000074', 'phamtienminh74@gmail.com', '079100000074', N'Chuyên viên Kinh doanh', 15000000, '2023-06-25'),
('NV21430075', NULL, N'Hoàng Cẩm Tú', N'Nữ', '1998-04-05', '0912000075', 'hoangcamtu75@gmail.com', '079100000075', N'Nhân viên Housekeeping/Cây xanh', 7000000, '2023-09-09'),
('NV21430076', NULL, N'Vũ Đình Bảo', N'Nam', '2000-07-18', '0912000076', 'vudinhbao76@gmail.com', '079100000076', N'Nhân viên Hướng dẫn', 8000000, '2024-03-30'),
('NV21430077', NULL, N'Võ Diệp Thảo', N'Nữ', '1989-10-30', '0912000077', 'vodiepthao77@gmail.com', '079100000077', N'Nhân viên Cứu hộ', 8500000, '2020-01-10'),
('NV21430078', NULL, N'Đặng Gia Huy', N'Nam', '1992-02-12', '0912000078', 'danggiahuy78@gmail.com', '079100000078', N'TBP Tổ chức Sự kiện', 20000000, '2021-04-20'),
('NV21430079', NULL, N'Bùi Phương Trinh', N'Nữ', '1994-05-25', '0912000079', 'buiphuongtrinh79@gmail.com', '079100000079', N'Nhân viên Bán hàng', 7500000, '2022-08-15'),
('NV21430080', NULL, N'Đỗ Trọng Hiếu', N'Nam', '1996-08-07', '0912000080', 'dotronghieu80@gmail.com', '079100000080', N'Nhân viên Cây xanh', 7000000, '2023-11-11'),

('NV21430081', NULL, N'Nguyễn Thanh Trúc', N'Nữ', '1998-11-20', '0912000081', 'nguyenthanhtruc81@gmail.com', '079100000081', N'Tổ trưởng Kiểm soát cổng', 12000000, '2024-02-05'),
('NV21430082', NULL, N'Trần Minh Vương', N'Nam', '1990-02-01', '0912000082', 'tranminhvuong82@gmail.com', '079100000082', N'Chuyên viên Nhân sự(Quan hệ Lao động)', 14000000, '2020-06-18'),
('NV21430083', NULL, N'Lê Bích Ngọc', N'Nữ', '1992-05-14', '0912000083', 'lebichngoc83@gmail.com', '079100000083', N'Chuyên viên Hành chính (Kỹ thuật)', 13500000, '2021-10-22'),
('NV21430084', NULL, N'Phạm Tiến Luân', N'Nam', '1994-08-27', '0912000084', 'phamtienluan84@gmail.com', '079100000084', N'Nhân viên Chăm sóc Động vật Thuỷ cung', 9500000, '2022-12-08'),
('NV21430085', NULL, N'Hoàng Lan Hương', N'Nữ', '1997-12-09', '0912000085', 'hoanglanhuong85@gmail.com', '079100000085', N'Nhân viên Lễ tân Thu ngân', 8500000, '2023-04-14'),
('NV21430086', NULL, N'Vũ Hữu Phước', N'Nam', '1999-03-23', '0912000086', 'vuhuuphuoc86@gmail.com', '079100000086', N'Đầu bếp Cao cấp Á/Âu', 17000000, '2024-01-25'),
('NV21430087', NULL, N'Võ Thanh Tâm', N'Nữ', '1991-06-05', '0912000087', 'vothanhtam87@gmail.com', '079100000087', N'Đầu bếp Á/Âu', 14500000, '2020-09-09'),
('NV21430088', NULL, N'Đặng Quang Hải', N'Nam', '1993-09-17', '0912000088', 'dangquanghai88@gmail.com', '079100000088', N'Nhân viên Cứu hộ/ Thợ lặn', 10500000, '2021-11-20'),
('NV21430089', NULL, N'Bùi Tố Như', N'Nữ', '1995-12-30', '0912000089', 'buitonhu89@gmail.com', '079100000089', N'Nhân viên Phục vụ', 7000000, '2023-02-10'),
('NV21430090', NULL, N'Đỗ Thanh Tùng', N'Nam', '1998-04-12', '0912000090', 'dothanhtung90@gmail.com', '079100000090', N'Nhân viên Biểu diễn Động vật', 11000000, '2024-05-01'),

('NV21430091', NULL, N'Nguyễn Quỳnh Như', N'Nữ', '2000-07-25', '0912000091', 'nguyenquynhnhu91@gmail.com', '079100000091', N'Kỹ thuật viên Thú y', 12500000, '2023-08-18'),
('NV21430092', NULL, N'Trần Văn Đạt', N'Nam', '1989-10-07', '0912000092', 'tranvandat92@gmail.com', '079100000092', N'Đầu bếp Bếp Á', 13000000, '2019-12-22'),
('NV21430093', NULL, N'Lê Thu Hoài', N'Nữ', '1992-01-19', '0912000093', 'lethuhoai93@gmail.com', '079100000093', N'Tổ trưởng PA/ Buồng Phòng', 11500000, '2021-03-05'),
('NV21430094', NULL, N'Phạm Đăng Khoa', N'Nam', '1994-04-02', '0912000094', 'phamdangkhoa94@gmail.com', '079100000094', N'Nhân viên Đón tiếp/ Service Centre', 8500000, '2022-07-15'),
('NV21430095', NULL, N'Hoàng Mỹ Linh', N'Nữ', '1996-07-15', '0912000095', 'hoangmylinh95@gmail.com', '079100000095', N'Nhân viên Phục vụ ALC/Buffet', 7500000, '2023-10-28');
GO

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
('LV01', N'Vé Vào Cổng Người Lớn', N'Người lớn', 950000, 0, N'Dành cho khách hàng cao từ 140cm trở lên'),
('LV02', N'Vé Vào Cổng Trẻ Em', N'Trẻ em', 700000, 0, N'Dành cho khách hàng cao từ 100cm - 140cm'),
('LV03', N'Vé Vào Cổng Cao Tuổi', N'Người cao tuổi', 700000, 0, N'Dành cho khách hàng từ 60 tuổi trở lên');

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
-- Lưu ý: Bạn có thể đổi ngày '2026-05-25' thành ngày hiện tại để test dễ hơn
INSERT INTO LichLamViec (MaLich, MaNhanVien, MaCa, NgayLamViec, ViTriPhanCong) VALUES
('LLV001', 'NV02', 'CA01', '2026-05-25', N'Quầy vé Cổng chính'),
('LLV002', 'NV04', 'CA02', '2026-05-25', N'Quầy vé Cổng chính'),
('LLV003', 'NV05', 'CA04', '2026-05-25', N'Văn phòng Quản lý Khu 2'),
('LLV004', 'NV06', 'CA03', '2026-05-25', N'Tuần tra Cổng phụ'),
('LLV005', 'NV07', 'CA01', '2026-05-25', N'Vệ sinh khu nhà hàng'),
('LLV006', 'NV08', 'CA02', '2026-05-25', N'Trực Tàu lượn siêu tốc'),

('LLV007', 'NV02', 'CA02', '2026-05-26', N'Quầy vé Cổng chính'),
('LLV008', 'NV04', 'CA01', '2026-05-26', N'Quầy vé Cổng chính'),
('LLV009', 'NV08', 'CA01', '2026-05-26', N'Trực Đu quay dây văng'),

('LLV010', 'NV02', 'CA01', '2026-05-27', N'Quầy vé Cổng chính'),
('LLV011', 'NV06', 'CA04', '2026-05-28', N'Tuần tra Cổng chính'),
('LLV012', 'NV07', 'CA02', '2026-05-29', N'Vệ sinh khu vui chơi'),
('LLV013', 'NV08', 'CA02', '2026-05-30', N'Trực Tàu lượn siêu tốc'),
('LLV014', 'NV05', 'CA04', '2026-05-31', N'Giám sát chung');
GO