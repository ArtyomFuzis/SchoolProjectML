using Microsoft.AspNetCore.Mvc;
using PLTest.Models;
namespace PLTest.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? lastdata,int? variant)
        {
            ViewBag.Title = "Языки программирования";
            ViewBag.Category = 1;
            ViewBag.Last_Data = lastdata??"";
            ViewBag.Last_Variant = variant;
            return View(__model);
        }
        public IActionResult About() 
        {
            ViewBag.Title = "О сайте";
            ViewBag.Category = 3;
            return View();
        }
        public IActionResult Reses() 
        {
            ViewBag.Title = "Возможные результаты";
            ViewBag.Category = 2;
            return View();
        }
        QuestionTempModel __model = new QuestionTempModel();
    }
}
