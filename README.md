## Trước tiên bạn vào SQL và chạy lệnh như sau 

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
INSERT INTO SANPHAM_MANH1 VALUES(1,N'Nước ngọt Pepsi');
INSERT INTO SANPHAM_MANH1 VALUES(2,N'Nước ngọt Mirinda');
INSERT INTO SANPHAM_MANH1 VALUES(3,N'Nước ngọt 7 Up');
INSERT INTO SANPHAM_MANH1 VALUES(4,N'Nước ngọt Cocacola');
GO
INSERT INTO SANPHAM_MANH2 VALUES(1,10000,1);
INSERT INTO SANPHAM_MANH2 VALUES(2,8000,1);
INSERT INTO SANPHAM_MANH2 VALUES(3,6500,1);
INSERT INTO SANPHAM_MANH2 VALUES(4,10600,2);
GO
INSERT INTO SANPHAM_MANH3 VALUES(5,N'Bánh quy bơ thập cẩm',115000,2);
INSERT INTO SANPHAM_MANH3 VALUES(6,N'Bộ quà Tết Kinh Đô Lộc Vàng hộp 811.4g',185000,2);
INSERT INTO SANPHAM_MANH3 VALUES(7,N'Bánh quy bơ Danisa',195000,3);
INSERT INTO SANPHAM_MANH3 VALUES(8,N'Bánh quy thập cẩm Oreo',163000,3);
```
## Sau khi bạn chạy lệnh SQL này xong bạn có thể thực hiện phân tán tùy theo mảnh bạn có thể chỉnh connect String cho từng mảnh như sau :

### mảnh 1 : Bạn truy cập vào CSDLPT-Tuan6-API\CSDLPT-Tuan6-API\program.cs

### Bạn đổi code ở các ô như này

```cs
builder.Services.AddDbContext<MyDbContext1>(options => options.UseSqlServer("Your Connect String 1"));
builder.Services.AddDbContext<MyDbContext2>(options => options.UseSqlServer("Your Connect String 2"));
builder.Services.AddDbContext<MyDbContext3>(options => options.UseSqlServer("Your Connect String 3"));
```

Note 

<ul>
  <li> MyDbContext1 là Connectstring mảnh 1</li>
  <li> MyDbContext2 là Connectstring mảnh 2</li>
  <li> MyDbContext3 là Connectstring mảnh 3</li>
</ul>


## Sau khi bạn đã config xong tiến hành truy cập vào CSDLPT-Tuan6-API\CSDLPT-Tuan6-API sau đó chạy lệnh

```bash
dotnet restore
&&
dotnet build
&&
dotnet run
```


## Sau khi bạn đã config xong tiến hành truy cập vào CSDLPT_Tuan6_WebApplication sau đó chạy lệnh

```bash
npm i
&&
npm run dev
```

### Sau đó bạn hãy vào 

FE : http://localhost:5173

BE : http://localhost:5007/swagger/index.html
