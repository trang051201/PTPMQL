
using Internal;
// using Internal;
using System;
// // Tập sử dụng Console.Read
// // lệnh này sử dụng để đọc và chuyển đổi cho kiểu number sang ASCII
        Consonle.WriteLine("nhập vào số mong muốn:");
        int a = Console.Read();
        Consonle.WriteLine(" số được chuyển đổi thành: " + a);

// // tập sử dụng Console.ReadLine
// // lệnh ReadLine dùng để đọc dữ liệu đầu vào hoặc đã nhập vào
// // lệnh ReadLine sử dụng cho kiểu String(chuỗi)
        Console.WriteLine("Nhap vao du lieu nguoi dung: ");
        string ten = Console.ReadLine();
        string tuoi = Console.ReadLine();
        Console.WriteLine("So tuoi cua " + ten + " la " + tuoi);


// Ép kiểu từ string sang number sử dụng Parse và tryParse
//khai báo biến kiểu string và gán giá trị = Nguyen Van A
      const string hoten ="Nguyen Van A";
//Khai báo biên int và gán giá trị = 8
      const int namlamviec = 8;
      const int baolau = 5;
      Console.WriteLine("Nhan vien {0} - {1}  nam kinh nghiem va làm việc được {2} năm", hoten, namlamviec, baolau);

// Ép kiểu sử dụng lớp convert
        string str = "123"; // giá trị đầu vào để chuyển đổi
        // chuyển đổi kiểu dữ liệu string (giá trị ="123")
        // sang kiểu dữ liệu int (giá trị sau khi chuyển đôi = 123)
        int a = Convert.ToInt32(str);
        Console.WriteLine("a=" +a);