# Quản Lý Đề Tài Nghiên Cứu (QuanLyDeTai)

![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

## 📋 Giới Thiệu

**Quản Lý Đề Tài Nghiên Cứu** là ứng dụng desktop giúp quản lý toàn diện các đề tài nghiên cứu khoa học trong môi trường học thuật. Ứng dụng hỗ trợ theo dõi thông tin đề tài, quản lý kinh phí, giảng viên hướng dẫn và các dữ liệu quan trọng khác một cách hiệu quả.

### ✨ Tính Năng Chính

- ✅ Quản lý đề tài nghiên cứu (Thêm, Sửa, Xóa)
- 💰 Tính toán và cập nhật kinh phí thực hiện theo tỷ lệ phần trăm
- 🔍 Tìm kiếm đề tài theo nhiều tiêu chí (tên, mã số, giảng viên)
- 📊 Xuất danh sách đề tài với bộ lọc linh hoạt
- 📁 Lưu trữ dữ liệu dạng XML
- 🖥️ Giao diện thân thiện, dễ sử dụng

## 🛠️ Công Nghệ Sử Dụng

- **Ngôn ngữ**: C#
- **Framework**: .NET 6.0
- **Lưu trữ dữ liệu**: XML
- **IDE**: Visual Studio 2019 trở lên

## 📦 Cài Đặt

### Yêu Cầu Hệ Thống

- Windows 10 trở lên
- .NET 6.0 SDK trở lên
- Visual Studio 2019+ (hoặc IDE tương tự hỗ trợ C#)

### Các Bước Cài Đặt

1. **Clone repository**
   ```bash
   git clone https://github.com/daolequang/Bao-cao-de-an.git
   cd Bao-cao-de-an
   ```

2. **Mở project trong Visual Studio**
   - Double-click vào file `.sln` hoặc mở Visual Studio và chọn "Open Project"

3. **Build và chạy ứng dụng**
   - Nhấn `F5` hoặc chọn "Start Debugging" trong Visual Studio
   - Hoặc sử dụng lệnh:
   ```bash
   dotnet build
   dotnet run
   ```

## 📁 Cấu Trúc Dự Án

```
QuanLyDeTai/
├── DTO/           # Data Transfer Objects - Các lớp đối tượng dữ liệu
├── DAL/           # Data Access Layer - Xử lý truy cập dữ liệu XML
├── BLL/           # Business Logic Layer - Xử lý nghiệp vụ và tính toán
├── GUI/           # Graphical User Interface - Giao diện người dùng
└── Data/          # Thư mục chứa file XML dữ liệu
```

### Mô Tả Chi Tiết

- **DTO**: Định nghĩa các class model cho đề tài, giảng viên, kinh phí
- **DAL**: Xử lý đọc/ghi dữ liệu từ file XML
- **BLL**: Logic tính toán kinh phí, xử lý nghiệp vụ
- **GUI**: Các form Windows Forms cho giao diện người dùng

## 📖 Hướng Dẫn Sử Dụng

### 1. Thêm Đề Tài Mới
- Nhấn nút "Thêm mới"
- Điền đầy đủ thông tin: Mã đề tài, tên, giảng viên, kinh phí, v.v.
- Nhấn "Lưu" để hoàn tất

### 2. Cập Nhật Kinh Phí
- Chọn đề tài cần cập nhật từ danh sách
- Nhập tỷ lệ phần trăm kinh phí đã thực hiện
- Hệ thống tự động tính toán và cập nhật

### 3. Tìm Kiếm Đề Tài
- Nhập từ khóa (tên đề tài, mã số, hoặc tên giảng viên)
- Nhấn "Tìm kiếm" để xem kết quả
- Kết quả hiển thị ngay trên giao diện

### 4. Xuất Danh Sách
- Chọn tiêu chí lọc (kinh phí, thời gian, trạng thái, v.v.)
- Nhấn "Xuất danh sách" để xem hoặc in báo cáo

## 🤝 Đóng Góp

Chúng tôi hoan nghênh mọi đóng góp từ cộng đồng! Để đóng góp:

1. Fork dự án này
2. Tạo branch mới cho tính năng của bạn
   ```bash
   git checkout -b feature/TinhNangMoi
   ```
3. Commit các thay đổi
   ```bash
   git commit -m "Thêm tính năng mới"
   ```
4. Push lên branch
   ```bash
   git push origin feature/TinhNangMoi
   ```
5. Tạo Pull Request

### Quy Tắc Đóng Góp
- Code phải tuân thủ chuẩn coding convention của C#
- Thêm comment cho các function phức tạp
- Test kỹ trước khi submit PR

## 📝 License

Dự án này được phát hành dưới giấy phép [MIT License](LICENSE).

## 📧 Liên Hệ

- **Email**: quangdaoo2808@gmail.com
- **GitHub**: [@daolequang](https://github.com/daolequang)

## 🙏 Cảm Ơn

Cảm ơn tất cả những ai đã đóng góp và hỗ trợ cho dự án này! Đặc biệt cảm ơn:
- Các giảng viên hướng dẫn
- Các bạn sinh viên đã góp ý
- Cộng đồng phát triển mã nguồn mở

---

⭐ Nếu thấy dự án hữu ích, hãy cho chúng tôi một star nhé!
