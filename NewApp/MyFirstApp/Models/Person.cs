// using Internal;
using System;
namespace MyFirstApp.Models;

public class person
{
    // khai báo thuộc tính
    public string FullName { get; set; } = "";
    public string Address { get; set; } =  "";
    public int Age { get; set; } = 0;
    // khai báo phương thức (methods)
    public void EnterData() {
        Console.WriteLine("Full name : ");
        FullName = Console.ReadLine() ?? FullName;
        Console.WriteLine("Address : ");
        Address = Console.ReadLine() ?? Address;
        Console.WriteLine("Age : ");
        Age = Convert.ToInt16(Console.ReadLine());
    }

    public void Display() {
        Console.WriteLine("{0} - {1} - {2} tuoi", FullName, Address, Age);
    }
}