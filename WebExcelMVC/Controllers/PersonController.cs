using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebExcelMVC.Models;
using WebExcelMVC.Data;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using WebExcelMVC.Models.Process;
using OfficeOpenXml;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebExcelMVC.Controllers
{
    public class PersonController : Controller
    {
        // Khai báo ApplicationDbContext để làm việc với CSDL
        private readonly ApplicationDbContext _context;
        // tạo phân trang
        public async Task<IActionResult> Index(int ? page, int? PageSize)
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Value="3", Text= "3" },
                new SelectListItem() { Value="5", Text= "5" },
                new SelectListItem() { Value="10", Text= "10" },
                new SelectListItem() { Value="15", Text= "15" },
                new SelectListItem() { Value="25", Text= "25" },
                new SelectListItem() { Value="50", Text= "50" },
            };
            int Pagesize = (PageSize ?? 3);
            ViewBag.psize = Pagesize;
            var model = _context.Person.ToList().ToPagedList(page ?? 1, Pagesize);
            return View(model);
        }

        // create process
        private ExcelProcess _excelProcess = new ExcelProcess();
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Action create - trả về view thực hiện thêm mới 1 scdl
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId, FullName, Address")] PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        // Action Edit - trả về view thực hiện sửa thông tin 1 person trong csdl
        public async Task<IActionResult> Edit(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // khai báo PersonExists để kiểm tra person có tồn tại hay không    
        public async Task<IActionResult> Edit(string id, [Bind("PersonId, FullName, Address")] PersonModel person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        // Action delete - Thực hiện xóa thông tin person trong csdl
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person
            .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // action delete
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null!");
            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // khai báo PersonExists để kiểm tra person có tồn tại hay không
        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }

        // Tạo action upload để lưu file lên server
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // action Upload
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to uolad!");
                }
                else
                {
                    // rename file to server
                    // Loại bỏ ký tự không hợp lệ (: trong trường hợp này)
                    var fileName = DateTime.Now.ToString("yyyyMMddHHmmss").Replace(':', '-') + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", "Excels", fileName);
                    var fileDirectory = Path.GetDirectoryName(filePath);
                    // Kiểm tra và tạo thư mục nếu cần thiết
                    if (!Directory.Exists(fileDirectory))
                    {
                        Directory.CreateDirectory(fileDirectory);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        // save file to server
                        await file.CopyToAsync(stream);
                    }
                    // Đọc dữ liệu từ file Excel và thêm vào DbContext
                    var dt = _excelProcess.ExcelToDataTable(filePath);
                    foreach (DataRow row in dt.Rows)
                    {
                        var person = new PersonModel
                        {
                            PersonId = row[0].ToString(),
                            FullName = row[1].ToString(),
                            Address = row[2].ToString()
                        };
                        _context.Person.Add(person);
                    }
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        // action download
        public IActionResult Download()
        {
            // Tên của file khi tải lên
            var fileName = "YourListPerson" + ".xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                // thêm ký tự vào cột A1    
                worksheet.Cells["A1"].Value = "PersonID";
                worksheet.Cells["B1"].Value = "FullName";
                worksheet.Cells["C1"].Value = "Address";
                //lấy tất cả thông tin người dùng
                var personList = _context.Person.ToList();
                //Đổ dữ liệu vào bảng tính
                worksheet.Cells["A2"].LoadFromCollection(personList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                //Tải file
                return File(stream, "application/vnd.openxmlformats-officedocumet.spreadsheetml.sheet", fileName);
            }
        }
    }
}