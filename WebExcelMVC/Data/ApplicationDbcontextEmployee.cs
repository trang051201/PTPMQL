// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using WebExcelMVC.Models;

namespace WebExcelMVC.Data
{
    public class ApplicationDbContextEmployee : DbContext
    {
        public ApplicationDbContextEmployee(DbContextOptions<ApplicationDbContextEmployee> options) : base(options)
        {
        }
        
        public DbSet<EmployeeModel> Employee { get; set; }
        // Định nghĩa DbSet cho các model khác nếu cần thiết
    }
}
