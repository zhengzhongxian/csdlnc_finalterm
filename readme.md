# **Quản Lý Sinh Viên Phân Tán**

## **Tác giả**

- **Họ và tên:** Trịnh Trung Hiển, Nguyễn Khánh Hoài
- **Email:** trunghien2807@gmail.com
- **Dự án:** Quản lý sinh viên phân tán với backend ASP.NET Core 8.0 và giao diện WinForm (sử dụng .NET Framework).

---

## **1. Giới thiệu dự án**

Dự án "Quản Lý Sinh Viên Phân Tán" là một ứng dụng được phát triển nhằm mục tiêu quản lý thông tin sinh viên một cách hiệu quả và dễ dàng mở rộng. Hệ thống hỗ trợ các chức năng chính như thêm, sửa, xóa, tìm kiếm và hiển thị thông tin sinh viên.

Điểm nổi bật của hệ thống:

- **Kiến trúc phân tán:** Dữ liệu sinh viên được lưu trữ và đồng bộ hóa giữa SQL Server và MongoDB.
- **Tích hợp dịch vụ Cloudinary:** Lưu trữ hình ảnh sinh viên trên đám mây để tối ưu hóa hiệu năng và tiết kiệm tài nguyên lưu trữ.
- **Giao diện người dùng thân thiện:** Xây dựng trên nền tảng WinForm (.NET Framework) với các chức năng CRUD (Create, Read, Update, Delete).

Ứng dụng bao gồm hai phần chính:

- **Backend:** Sử dụng **ASP.NET Core 8.0**, cung cấp các API phục vụ thao tác CRUD và đồng bộ dữ liệu.
- **Frontend:** Giao diện WinForm, cung cấp các tính năng quản lý sinh viên trực quan.

---

## **2. Công cụ cần thiết**

Để triển khai và chạy ứng dụng, bạn cần cài đặt các công cụ sau:

- **Visual Studio 2022** (hoặc mới hơn): Hỗ trợ phát triển **.NET Framework** (cho WinForm) và **ASP.NET Core 8.0** (cho Backend).
- **SQL Server**: Quản lý dữ liệu chính của hệ thống.
- **MongoDB**: Lưu trữ metadata và hỗ trợ các thao tác truy vấn nhanh.
- **Cloudinary Account**: Lưu trữ hình ảnh sinh viên trên nền tảng đám mây.
- **Postman** hoặc **Swagger** (tùy chọn): Kiểm tra và debug API.

---

## **3. Giới thiệu các thư viện sử dụng**

### **Backend (ASP.NET Core 8.0)**

- **Entity Framework Core**: ORM giúp làm việc với SQL Server một cách dễ dàng.
- **MongoDB.Driver**: Tích hợp và tương tác với cơ sở dữ liệu MongoDB.
- **CloudinaryDotNet**: Tải ảnh lên và quản lý hình ảnh trên Cloudinary.
- **AutoMapper**: Map dữ liệu giữa DTO và Entity Model.

### **Frontend (WinForm trên .NET Framework)**

- **Newtonsoft.Json**: Xử lý dữ liệu JSON, hỗ trợ giao tiếp với API.
- **RestSharp**: Thư viện gọi API từ ứng dụng WinForm.

---

## **4. Hướng dẫn cài đặt**

### **Bước 1: Chuẩn bị môi trường**

1.  **Copy file mẫu `secrets_example.json` tại đây và bỏ vô dự án**
2.  **Setting file secrets.json trong dự án trước khi chạy Backend:**

    - Cách mở file `secrets.json`:

      Bước 1: Mở file `COMP106002_PointManagement.sln` trong folder `COMP106002_PointManagement`.

        <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735886095/fpsl8wsu9tf0uj5ybpwq.png" alt="sln" width="400" height ="400">

      Bước 2: Click chuột phải vào `COMP106002_PointManagement.API`:

        <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735886884/xov5yowugbqz0piij94k.png" alt="instruct" width="400" height ="400">

      Bước 3: Click chuột phải vào Manage User Secrets. Tại đây sẽ xuất hiện file `secrets.json`

        <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735887258/prcsul8evpk96ziyyhh9.png" alt="instruct" width="400" height ="400">

    - Bỏ file mẫu `secrets_example.json` vào dự án.

      <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735887983/az0labrm6j6dknhqkkft.png" alt="example" width="400" height ="400">

3.  **Cài đặt SQL Server:**

    - Tạo database mới.
    - Import file SQL mẫu được cung cấp trong thư mục `tại đây`.
    - Lấy chuỗi kết nối cập nhật vào `secrets.json`.
      Ví dụ:

      <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735888399/z6ezanwvn6lhafqnwjlr.png" alt="example">

4.  **Khởi động MongoDB:**

    - Chạy MongoDB server trên máy tính của bạn hoặc sử dụng dịch vụ MongoDB Atlas.
    - Cấu hình chuỗi kết nối trong `secrets.json` của Backend.

    <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735888243/w4iuvvaoeg525ebjq1yr.png" alt="example">

5.  **Cấu hình Cloudinary:**

    - Tạo tài khoản tại [Cloudinary](https://cloudinary.com).
    - Lấy thông tin `CloudName`, `ApiKey`, và `ApiSecret` và cập nhật vào `secrets.json`.

      <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735888539/d2utmkjmzw07sgwygwub.png" alt="sln">

---

### **Bước 2: Chạy Backend**

1. Mở file `COMP106002_PointManagement.sln` trong folder `COMP106002_PointManagement`.
2. Click vào `https` hoặc ấn phím **F10** để chạy Backend (Đảm bảo các chuỗi kết nối phải được thiết lập đúng trước khi chạy).

  <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735889257/oiptjwkngeqrujxntcm2.png" alt="instruct" width="700" height ="400">

---

### **Bước 3: Chạy Frontend (WinForm GUI)**

1. Mở file `PointManagement_Application.sln` trong folder `PointManagement_Application`.
2. Kiểm tra các API URL trong mã WinForm:

   - Vào folder `Helper` sau khi mở file `PointManagement_Application.sln`. Ấn vào `ApiHelper.cs`và kiểm tra.
   - Đảm bảo đường dẫn của WinForm phải khớp với Backend đang được chạy.

   Winform:

    <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735890172/fsw9bkr05vaw0tchqzcs.png" alt="check">

   BackEnd:

    <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735890206/icpkoo5tvfvqbg93uzry.png" alt="check">

3. Build và chạy ứng dụng.

   Tài khoản demo: trunghien112

   Mật Khẩu demo: 1234

---

### **Bước 4: Sử dụng Swagger hoặc Postman để kiểm tra API (tùy chọn)**

1.  Sử dụng Swagger (mặc định của Asp.net) để gửi các request tới API.
2.  Kiểm tra các chức năng thêm, sửa, xóa, và tìm kiếm sinh viên.

    **Lưu ý:** Trong trường hợp hệ thống chưa có tài khoản demo, bạn có thể sử dụng Swagger để tạo một tài khoản mới với vai trò `Role = "Admin"`và `location = 1` nếu quản lý khu vực ở Hà Nội hay `location = 2` nếu quản lý khuc vực Thành phố Hồ Chí Minh. Tài khoản này sẽ cho phép bạn truy cập vào tất cả các tính năng của ứng dụng sau khi đăng nhập. Vì ứng dụng được thiết kế dành riêng cho **Admin**, việc đảm bảo tài khoản có quyền truy cập đầy đủ là rất quan trọng để trải nghiệm toàn bộ chức năng của hệ thống.

    <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735891289/vyaq5ldkxo7vtnydxeqv.png" alt="example">

---

## **5. Screenshots**

1. **Giao diện chính của WinForm:**

   <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735891898/attztmpnorj4bio9s6hr.png" alt="proccess" width = "500">

2. **Form thêm sinh viên:**

   <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735891747/rznmfxscul3lt70wjrnb.png" alt="proccess" width = "500">

3. **Quy trình xử lý phân tán:**

   <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735891422/gb7awswihxwauire8lce.png" alt="proccess" width = "700">

4. **Quy trình lưu trữ dữ liệu trên Cloudinary:**

   <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735891544/nfpepmiulzbykpvbujkx.png" alt="proccess" width ="700">

5. **Swagger kiểm tra API:**

   <img src="https://res.cloudinary.com/dvxnesld4/image/upload/v1735892012/dxmdgi5ub3rch0ssi0lp.png" alt="proccess" width = "500">

---

## **6. Ghi chú**

- **Yêu cầu cài đặt:** SQL Server, MongoDB, và tài khoản Cloudinary phải được cấu hình đúng trước khi chạy ứng dụng.
- Nếu gặp lỗi, vui lòng kiểm tra lại file cấu hình `secrets.json` hoặc liên hệ qua email: **trunghien2807@gmail.com**.
