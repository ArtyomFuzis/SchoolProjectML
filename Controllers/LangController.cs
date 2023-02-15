using Microsoft.AspNetCore.Mvc;
using PLTest.Models.Interfaces;
using PLTest.Models.LocalDB;
namespace PLTest.Controllers
{
    public class LangController : Controller
    {
        public static ILangModel __model=new LangModelJson();
        private IActionResult GenerateView(string? title,string lang) 
        {
            ViewBag.Category = 2;
            ViewBag.Title= title;
            ViewBag.Lang= lang;
            return View("Index",__model);
        }
        /*public LangController(ILangModel model) 
        {
            __model = model;
        }*/
        public IActionResult Index()
        {
            return Redirect("/main/reses");
        }
        public IActionResult Cs() 
        {
            return GenerateView("Язык программирования C#", "cs");
        }
        public IActionResult Cpp()
        {
            return GenerateView("Язык программирования C++", "cpp");
        }
        public IActionResult C()
        {
            return GenerateView("Язык программирования C", "c");
        }
        public IActionResult Python()
        {
            return GenerateView("Язык программирования Python", "python");
        }
        public IActionResult Java()
        {
            return GenerateView("Язык программирования Java", "java");
        }
        public IActionResult Kotlin()
        {
            return GenerateView("Язык программирования Kotlin", "kotlin");
        }
        public IActionResult Go()
        {
            return GenerateView("Язык программирования Go", "go");
        }
        public IActionResult Swift()
        {
            return GenerateView("Язык программирования Swift", "swift");
        }
        public IActionResult Asm()
        {
            return GenerateView("Язык программирования Assembler", "asm");
        }
        public IActionResult Js()
        {
            return GenerateView("Язык программирования JavaScript", "js");
        }
        public IActionResult Ts()
        {
            return GenerateView("Язык программирования TypeScript", "ts");
        }
        public IActionResult Php()
        {
            return GenerateView("Язык программирования PHP", "php");
        }
        public IActionResult Ruby()
        {
            return GenerateView("Язык программирования Ruby", "ruby");
        }
        public IActionResult Vb()
        {
            return GenerateView("Язык программирования Visual Basic", "vb");
        }
    }
}
