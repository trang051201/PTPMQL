
using System.IO;
using System.Security.AccessControl;
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
// lệnh ReadLine sử dụng cho kiểu String(chuỗi)
        Console.WriteLine("Nhap vao du lieu nguoi dung: ");
        string ten = Console.ReadLine();
        string tuoi = Console.ReadLine();
        Console.WriteLine("So tuoi cua " + ten + " la " + tuoi);


// 4.Ép kiểu từ string sang number sử dụng Parse và tryParse
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

// 5.Các kiểu toán tử
    // toán tử số học : +, -, *, /, %, ++, --.
    // toán tử so sánh: ==, >,<, >=, <=, !=. 
    // toán tử logic: &&, ||, !

// 6.Các cấu trúc điều kiện
int a =10;
if(a<0) {
        Consonle.WriteLine("{0} la so nguyen am", a);
} else
{
        if(a % 2 == 0)
        {
        Consonle.WriteLine("{0} la so nguyen duong chan", a);
        } else
        {
                Consonle.WriteLine("{0} la so nguyen duong le",a);
        }
}
//7. switch-case
int day = 2
switch (day)
        {
            case 1:
                Console.WriteLine("CN");
                break;
            case 2:
                Console.WriteLine(" thu 2.");
                break;
            case 3:
                Console.WriteLine("thu 3.");
                break;
            default:
                Console.WriteLine("Số bạn đã chọn không nằm trong danh sách.");
                break;
        }

// 8. for
for (int i = 0; i < 10; i++)
{
        Consonle.WriteLine("vong lap thu {0}",i);
}
// 9. wwhile 
  int a=1;
  while (a<10)
  {
                Consonle.WriteLine("vong lap thu {0}",a);
                a++;
  }
//10. do wwhile
 int A = 10;
 do
 {        Consonle.WriteLine("vong lap thu{0}",A);
A++;
 } while (A<11);
// 10. break & return
// break sử dụng để ngắt một đoạn trương trình
// continue sử dụng để bỏ qua một giá trị được quy định và tiếp tục thực thi các lện trương trình còn lại

// 11. chạy debug trong C#
