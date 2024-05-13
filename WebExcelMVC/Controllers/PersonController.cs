using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebExcelMVC.Models;
using WebExcelMVC.Data;
using System.Threading.Tasks;
using System.IO;

namespace WebExcelMVC.Controllers
{
    public class PersonController : Controller
    {
        // Khai báo ApplicationDbContext để làm việc với CSDL
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Action Index - trả về view 1 list dữ liệu person trong csdl
        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
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
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Upload/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        // save file to server
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return View();
        }
    }
}