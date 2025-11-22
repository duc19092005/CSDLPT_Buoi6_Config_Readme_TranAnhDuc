# Hướng Dẫn Cài Đặt Dự Án (CSDLPT - Tuần 6)

Tài liệu này hướng dẫn chi tiết các bước thiết lập cơ sở dữ liệu phân tán, cấu hình Backend (.NET API) và khởi chạy Frontend.

---

## 1. Cấu hình Cơ Sở Dữ Liệu (SQL Server)

Hãy chạy đoạn script sau trong **SQL Server Management Studio (SSMS)** để tạo bảng và dữ liệu mẫu cho các phân mảnh (fragments).

```sql
CREATE TABLE SANPHAM_MANH1(
    MASANPHAM INT NOT NULL,
    TENSANPHAM NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_SANPHAMM1 PRIMARY KEY (MASANPHAM)
);
GO

CREATE TABLE SANPHAM_MANH2(
    MASANPHAM INT NOT NULL,
    GIABAN INT,
    MAKHOHANG INT,
    CONSTRAINT PK_SANPHAMM2 PRIMARY KEY (MASANPHAM),
);
GO

CREATE TABLE SANPHAM_MANH3(
    MASANPHAM INT NOT NULL,
    TENSANPHAM NVARCHAR(100) NOT NULL,
    GIABAN INT,
    MAKHOHANG INT,
    CONSTRAINT PK_SANPHAM PRIMARY KEY (MASANPHAM),
);
GO

-- Insert dữ liệu cho Mảnh 1
INSERT INTO SANPHAM_MANH1 VALUES(1, N'Nước ngọt Pepsi');
INSERT INTO SANPHAM_MANH1 VALUES(2, N'Nước ngọt Mirinda');
INSERT INTO SANPHAM_MANH1 VALUES(3, N'Nước ngọt 7 Up');
INSERT INTO SANPHAM_MANH1 VALUES(4, N'Nước ngọt Cocacola');
GO

-- Insert dữ liệu cho Mảnh 2
INSERT INTO SANPHAM_MANH2 VALUES(1, 10000, 1);
INSERT INTO SANPHAM_MANH2 VALUES(2, 8000, 1);
INSERT INTO SANPHAM_MANH2 VALUES(3, 6500, 1);
INSERT INTO SANPHAM_MANH2 VALUES(4, 10600, 2);
GO

-- Insert dữ liệu cho Mảnh 3
INSERT INTO SANPHAM_MANH3 VALUES(5, N'Bánh quy bơ thập cẩm', 115000, 2);
INSERT INTO SANPHAM_MANH3 VALUES(6, N'Bộ quà Tết Kinh Đô Lộc Vàng hộp 811.4g', 185000, 2);
INSERT INTO SANPHAM_MANH3 VALUES(7, N'Bánh quy bơ Danisa', 195000, 3);
INSERT INTO SANPHAM_MANH3 VALUES(8, N'Bánh quy thập cẩm Oreo', 163000, 3);
```


2. Cấu hình & Chạy Backend (.NET API)
Bước 2.1: Cấu hình Connection Strings
Mở file mã nguồn tại đường dẫn: CSDLPT-Tuan6-API\CSDLPT-Tuan6-API\Program.cs

Tìm và cập nhật chuỗi kết nối (Connection String) cho từng mảnh tương ứng:

```cs
// Config Connection Strings cho các phân mảnh
builder.Services.AddDbContext<MyDbContext1>(options => 
    options.UseSqlServer("Your Connect String 1")); // Kết nối đến Mảnh 1

builder.Services.AddDbContext<MyDbContext2>(options => 
    options.UseSqlServer("Your Connect String 2")); // Kết nối đến Mảnh 2

builder.Services.AddDbContext<MyDbContext3>(options => 
    options.UseSqlServer("Your Connect String 3")); // Kết nối đến Mảnh 3

```

Lưu ý:

<li>MyDbContext1: Dành cho dữ liệu Mảnh 1 (Kết nối tới Site 1). </li>

<li>MyDbContext2: Dành cho dữ liệu Mảnh 2 (Kết nối tới Site 2).</li>

<li>MyDbContext3: Dành cho dữ liệu Mảnh 3 (Kết nối tới Site 3).</li>

Bước 2.2: Khởi chạy Server
Mở terminal, truy cập vào thư mục CSDLPT-Tuan6-API\CSDLPT-Tuan6-API và chạy các lệnh sau:


```bash
dotnet restore
dotnet build
dotnet run
```

3. Cấu hình & Chạy Frontend (Web Application)

4. Mở terminal mới, truy cập vào thư mục CSDLPT_Tuan6_WebApplication và chạy lệnh sau để cài đặt thư viện và khởi chạy:

```bash
npm install && npm run dev
```


5. Truy cập Ứng Dụng
Sau khi khởi chạy thành công, bạn có thể truy cập qua các đường dẫn sau:


```txt
Dịch vụ	Đường dẫn (URL)
Frontend (Giao diện)	http://localhost:5173
Backend (Swagger UI)	http://localhost:5007/swagger/index.html

```
