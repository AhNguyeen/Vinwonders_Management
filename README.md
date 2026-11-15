# 🎢 Hệ thống Quản lý VinWonders (VinWonders Management System)

![C#](https://img.shields.io/badge/C%23-.NET-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Guna UI](https://img.shields.io/badge/UI-Guna%20UI2-0078D7?style=for-the-badge)

## 📖 Giới thiệu dự án
**VinWonders Management System** là ứng dụng desktop toàn diện được phát triển nhằm số hóa và tối ưu hóa quy trình vận hành tại khu vui chơi giải trí VinWonders. Hệ thống cung cấp giao diện hiện đại, trực quan, hỗ trợ nhân viên và quản lý theo dõi bán vé, kiểm soát dịch vụ, quản lý khách hàng và thống kê doanh thu một cách chính xác.

---

## ✨ Tính năng nổi bật

* **🔐 Phân quyền & Bảo mật:** Hệ thống đăng nhập phân quyền chặt chẽ giữa Quản trị viên (Admin) và Nhân viên (Staff).
* **🎟️ Quản lý Bán vé & Dịch vụ:** Đặt vé theo từng phân khu, loại vé (người lớn, trẻ em, VIP), áp dụng mã khuyến mãi và xuất hóa đơn nhanh chóng.
* **🎡 Quản lý Khu vui chơi & Trò chơi:** Theo dõi trạng thái hoạt động, lịch bảo trì các khu vực trò chơi và dịch vụ đi kèm.
* **👥 Quản lý Nhân sự & Khách hàng:** Lưu trữ thông tin nhân viên, ca làm việc và quản lý thông tin khách hàng thân thiết.
* **📊 Báo cáo & Thống kê Doanh thu:** Trực quan hóa dữ liệu doanh thu theo ngày/tháng/năm bằng biểu đồ và xuất báo cáo chi tiết.
* **⚙️ Triển khai thực tế:** Tích hợp tính năng sao lưu/phục hồi cơ sở dữ liệu và đóng gói bộ cài đặt hoàn chỉnh (`.exe`/`.msi`) sẵn sàng triển khai trên máy khách hàng.

---

## 🛠️ Công nghệ sử dụng

* **Ngôn ngữ lập trình:** C# (.NET Framework / .NET)
* **Giao diện người dùng (UI/UX):** Windows Forms kết hợp thư viện **Guna UI2**
* **Cơ sở dữ liệu:** Microsoft SQL Server
* **Kết nối dữ liệu:** ADO.NET (sử dụng Stored Procedures & Triggers để tối ưu hiệu suất và toàn vẹn dữ liệu)
* **Công cụ phát triển:** Visual Studio 2022, SQL Server Management Studio (SSMS)

---

## 🚀 Hướng dẫn cài đặt và chạy dự án

### 1. Yêu cầu hệ thống
* Hệ điều hành Windows 10/11.
* Visual Studio (khuyên dùng bản 2019 hoặc 2022).
* SQL Server (2017 trở lên).

### 2. Các bước cài đặt
1. **Clone repository về máy:**
   ```bash
   git clone https://github.com/AhNguyeen/Vinwonders_Management.git
