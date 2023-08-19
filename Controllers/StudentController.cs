using Microsoft.AspNetCore.Mvc;

namespace BascCrud.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
