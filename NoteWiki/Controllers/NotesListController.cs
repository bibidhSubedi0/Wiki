using Microsoft.AspNetCore.Mvc;

namespace NoteWiki.Controllers
{
    public class NotesListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
