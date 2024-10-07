using BaiKiemTra03_01.Models;
using BaiKiemTra03_02.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_01.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var departments = _db.Department.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Department.Add(department); // Thêm phòng ban mới vào database
                _db.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách phòng ban
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _db.Department.FirstOrDefault(d => d.DepartmentId == id); // Tìm phòng ban theo id
            if (department == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về NotFound
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _db.Department.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Department.Update(department); // Cập nhật thông tin phòng ban trong database
                _db.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng về danh sách phòng ban
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _db.Department.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Xóa phòng ban khỏi database
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _db.Department.FirstOrDefault(d => d.DepartmentId == id);
            if (department != null)
            {
                _db.Department.Remove(department); // Xóa phòng ban khỏi database
                _db.SaveChanges(); // Lưu thay đổi
            }
            return RedirectToAction("Index"); // Chuyển hướng về danh sách phòng ban
        }

    }
}
