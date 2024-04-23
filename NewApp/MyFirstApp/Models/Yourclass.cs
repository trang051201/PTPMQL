using Internal;
using System;
namespace MyFirstApp.Models;
// tạo class
public class Yourclass
{
    // tao thuoc tinh
    public string FullName { get; set; };
    public string Address { get; set;}
    public string Age { get; set;}

    // method Enter data
    public Void EnterData() {
    Console.WriteLine("Full name : ");
    FullName = Console.Readline();
    console.WriteLine("Address : ");
    Address = Console.ReadLine();
    Console.WriteLine("Age : ");
    Age = Convert.ToInt16(Console.ReadLine());
    }
    // method address
    public void Display() {
        Console.WriteLine("ten va dia chi la: {0} - {1 - {2} tuoi", FullName, Address, Age);
    }
}
//  khởi tạo object
class Program {
    static void Main(string[] args) {

        // khởi tạo 2 đối tượng từ class person
        Person ps1 = new Person();
        Person ps2 = new Person();

        // gán giá trị thuộc tính đối tượng 1 : "ps1"
        ps1.FullName = "Quách Kiều Trang";
        ps1.Address = "Phú Thọ";
        ps1.Age = 23;

        // gọi phương thức hiển thị thông tin
        ps1.Display();


        // gán giá trị cho đối tượng ps2
        ps2.FullName = "Nguyễn Văn A";
        ps2.Address = "HN";
        ps2.Age = 22;
        // gọi phương thức hiển thị thông tin
        ps2.Display();
    }

}
