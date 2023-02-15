using Microsoft.AspNetCore.Mvc;
namespace PLTest.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? code)
        {
            ViewBag.Category = -1;
            ViewBag.Title = "Ошибка!";
            ViewBag.Code = code;
            return View();
        }
    }
}
