using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra01.Controllers
{
    public class DangKyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
