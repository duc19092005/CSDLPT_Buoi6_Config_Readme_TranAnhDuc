# CSDLPT Tuần 6 - Web Application

Ứng dụng React với TypeScript để quản lý và hiển thị danh sách sản phẩm từ API.

## Tính năng

- ✅ Gọi API để lấy danh sách sản phẩm
- ✅ Chọn DB Context Enum (Server1, Server2, Server3)
- ✅ Hiển thị dữ liệu sản phẩm với UI đẹp và hiện đại
- ✅ Xử lý các trường có thể null
- ✅ Responsive design
- ✅ Loading và error handling

## Cài đặt

1. Cài đặt dependencies:
```bash
npm install
```

2. Chạy ứng dụng ở chế độ development:
```bash
npm run dev
```

3. Build cho production:
```bash
npm run build
```

4. Preview build:
```bash
npm run preview
```

## API Endpoint

Ứng dụng gọi API tại: `http://localhost:5007/?dbContextEnum={value}`

- `dbContextEnum=0` cho Server1
- `dbContextEnum=1` cho Server2
- `dbContextEnum=2` cho Server3

## Cấu trúc dự án

```
├── src/
│   ├── types/
│   │   └── product.ts      # TypeScript interfaces
│   ├── App.tsx             # Component chính
│   ├── App.css             # Styles
│   ├── main.tsx            # Entry point
│   └── vite-env.d.ts       # Vite type definitions
├── index.html
├── package.json
├── tsconfig.json
└── vite.config.ts
```

## Công nghệ sử dụng

- React 18
- TypeScript
- Vite
- CSS3 (Gradient, Flexbox, Grid)

