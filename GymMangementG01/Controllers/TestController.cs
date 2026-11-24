using Microsoft.AspNetCore.Mvc;

namespace GymMangementG01.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            int Data = 10;
            return View(Data);
           // return View("Hamada");    // => Go  to Hamada Page 
        }
        public IActionResult Hamada(int id)
        {
           
            return View(id);
        }
    }
}
