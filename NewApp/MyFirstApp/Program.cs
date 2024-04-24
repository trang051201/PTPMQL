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
    }

}
