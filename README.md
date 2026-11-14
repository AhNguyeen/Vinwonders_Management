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

## 📸 Hình ảnh giao diện (Screenshots)

*(Bạn có thể chụp ảnh màn hình phần mềm và thay thế các đường dẫn bên dưới để trang GitHub sinh động hơn)*

| Màn hình Đăng nhập | Bảng điều khiển (Dashboard) |
| :---: | :---: |
| ![Login](<img width="1920" height="1080" alt="Screenshot (392)" src="https://github.com/user-attachments/assets/107b8f7f-3e0b-4dec-affa-411569495fce" />) 
| ![Dashboard](<img width="1920" height="1080" alt="Screenshot (393)" src="https://github.com/user-attachments/assets/e9adf640-ae07-4ba9-a551-6d2f0893d338" />) |

| Quản lý Bán vé | Thống kê Doanh thu |
| :---: | :---: |
| ![Ticket](<img width="1920" height="1080" alt="Screenshot (394)" src="https://github.com/user-attachments/assets/7ec72008-b8f2-4736-80a6-7da1e07e67b1" />) 
| ![Employee](<img width="1920" height="1080" alt="Screenshot (395)" src="https://github.com/user-attachments/assets/cea3af1b-8899-4a84-b0d8-49185ae74895" />) |

---

## 🚀 Hướng dẫn cài đặt và chạy dự án

### 1. Yêu cầu hệ thống
* Hệ điều hành Windows 10/11.
* Visual Studio (khuyên dùng bản 2019 hoặc 2022).
* SQL Server (2017 trở lên).

### 2. Các bước cài đặt
1. **Clone repository về máy:**
   ```bash
   git clone https://github.com/AhNguyeen/<Ten-Repo-VinWonders-Cua-Ban>.git
   ```
2. **Thiết lập Cơ sở dữ liệu:**
   * Mở **SQL Server Management Studio (SSMS)**.
   * Chạy file script `Database/VinWonders_DB.sql` (đính kèm trong thư mục dự án) để khởi tạo database và dữ liệu mẫu.
3. **Cấu hình chuỗi kết nối (Connection String):**
   * Mở file `.sln` bằng Visual Studio.
   * Tìm đến file `App.config` (hoặc class kết nối SQL) và cập nhật `Server Name` theo máy của bạn:
     ```xml
     <connectionStrings>
         <add name="VinWondersDB" connectionString="Data Source=TEN_SERVER_CUA_BAN;Initial Catalog=VinWondersDB;Integrated Security=True" />
     </connectionStrings>
     ```
4. **Chạy ứng dụng:**
   * Nhấn `F5` hoặc nút **Start** trên Visual Studio để biên dịch và trải nghiệm.

---

## 👤 Tác giả

* **AhNguyeen**
* GitHub: [@AhNguyeen](https://github.com/AhNguyeen)

---
*Dự án được thực hiện trong giai đoạn 2025 - 2026.*
