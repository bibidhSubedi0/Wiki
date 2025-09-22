using Microsoft.AspNetCore.Mvc;

namespace NoteWiki.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
