using Microsoft.AspNetCore.Mvc;

namespace NoteWiki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
