using BaiKiemTra03_02.Models;
using BaiKiemTra03_02.Data;
using Microsoft.AspNetCore.Mvc;
using BaiKiemTra03_01.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_01.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public  EmployeeController(ApplicationDbContext db)
        {  _db = db; }
        public IActionResult Index()
        {
            var nhanvien = _db.Employee.ToList();
            ViewBag.Employee = nhanvien;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Add(employee);  // Thêm nhân viên mới vào database
                _db.SaveChanges();            // Lưu thay đổi
                return RedirectToAction("Index");  // Chuyển hướng về trang danh sách nhân viên
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.EmployeeId == id);  // Tìm nhân viên theo id
            if (employee == null)
            {
                return NotFound();  // Nếu không tìm thấy, trả về NotFound
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Update(employee);  // Cập nhật thông tin nhân viên trong database
                _db.SaveChanges();               // Lưu thay đổi
                return RedirectToAction("Index");     // Chuyển hướng về danh sách nhân viên
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Xóa nhân viên khỏi database
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _db.Employee.Remove(employee);  // Xóa nhân viên khỏi database
                _db.SaveChanges();               // Lưu thay đổi
            }
            return RedirectToAction("Index");         // Chuyển hướng về danh sách nhân viên
        }

    }
}
