namespace MyFirstApp.Models;

public class Student : person
{
    public string StudentCode {get; set;} = "";
    // tạo phương thức
    public void EnterData() {
        // sử dụng base kế thừa phương thức enterdata
        base.EnterData();
        Console.Write("Student code : ");
        StudentCode = Console.ReadLine() ?? StudentCode;
    }
    public void Display() {
        // sử dụng base kế thừa phương thức display
        base.Display();
        Console.Write("Msv : {0}", StudentCode);
    }
}
