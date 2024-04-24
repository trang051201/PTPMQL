using System.Collections;
using System.Collections.Specialized;
using Internal;
using System;
using  MyFirstApp.Models;
public class Program {
    private static void Main(string[] args) {

        // khởi tạo 2 đối tượng(obj) từ class person
        person ps1 = new person();
        person ps2 = new person();

        // gán giá trị thuộc tính đối tượng 1 : "ps1"
        ps1.FullName = "Quach Kieu Trang";
        ps1.Address = "Phu Tho";
        ps1.Age = 23;

        // gọi phương thức hiển thị thông tin
        ps1.Display();


        // gán giá trị cho đối tượng ps2
        ps2.FullName = "Nguyen van A";
        ps2.Address = "HN";
        ps2.Age = 22;
        // gọi phương thức hiển thị thông tin
        ps2.Display();



        // tạo obj cho từ class student
        Student std = new Student();
        std.EnterData();
        std.StudentCode = "2021050654";
        std.Display();

        // khởi tạo Array
        int intArray = new int[5];
        // khai báo 1 phần tử 
        int a = 10;
        // gán giá trị của phần từ thứ 3 trong mảng
        intArray[2] = a;

        // khởi tạo mảng và gán giá trị index bằng một giá trị obj
        Student[] stdArray  = new Student[10];
        // khai báo phần tử kiểu int và gán giá trị bằng 10
        Student std = new Student();
        std.NhapThongTin(); // nhập thông tin cho đối tượng std
        // gán giá trị của phần tử thứ 7 bằng giá trị của biến
        stdArray[6] = std;

        // nhập dữ liệu  cho mảng int (intArray) bao gồm n phần tử & sử dụng vòng lặp for
        for (int i = 0; i < n ; i++) {
            Console.WriteLine("nhap phan tu thu {0} : ", i); 
            int a =  Convert.ToInt32(Console.ReadLine());
            intArray[i] = a;
        }
        // nhập dữ liệu từ mảng student (stdStudent) bao gồm n phần tử
        for (int i = 0; i<n ;i++) {
            Console.WriteLine("nhap phan tu thu {0}", i);
            Student std = new Student();
            std.NhapThongTin();
            intArray[i] = std;
        }

        // hiển thị dữ liệu  mảng int (intArray) bao gồm bao nhiêu phần tử
        for(int i = 0; i < intArray.Count(); i++) {
                Console.WriteLine(intArray[i] + "\t");
        }

        // hiển thị dữ liệu của mảng Student (stdStudent) bao gồm n phần tử
        foreach (Student std in stdArray) {
            string fName = std.FullName;
            string address = std.Address;
            Console.WriteLine("{0} - {1}", fName, address);
        {
            
        }
        // tạo arrayList
        ArrayList arrlist = new ArrayList();
        // thêm 1 phần tử vào arraylist
        arrlist.Add(value);
        arrlist[5];
        // none generic conllections
        ArrayList arrlist = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            Student std = new Student();
            std.NhapThongTin();
            arrList.Add(std);
        }
        // hiển thị các phần tử trong arrList sử dụng vòng lặp for
        for(int i = 0; i < 5; i++) {
            Student std  = (Student) arrList[i];
            std.HienThiThongTin();
        }
     }

}
