using Microsoft.AspNetCore.Mvc;
using NoteWiki.Data;
using NoteWiki.Models;
using System.Linq;

namespace NoteWiki.Controllers
{
    public class NotesListController : Controller
    {
        private readonly AppDbContext _sqlContext;


        public NotesListController(AppDbContext context)
        {
            _sqlContext = context;
        }


        public IActionResult Index(Guid id)
        {
            // Error handling for noteBox to be null
            NoteBoxModel? noteBox = _sqlContext.NoteBoxes.Where(nb => nb.NoteBoxGuid == id).FirstOrDefault();
            List<NoteMetadataModel> notes = _sqlContext.NoteMetadata.Where(nd => nd.NoteBoxGuid == id).ToList();
            return View(new Tuple<NoteBoxModel, List<NoteMetadataModel>>(noteBox, notes));
        }


        public IActionResult Create(Guid NoteBoxGuid)
        {
            return RedirectToAction("Create", "Note", new { noteBoxGuid = NoteBoxGuid});
        }
    }
}
