using Microsoft.AspNetCore.Mvc;
using NoteWiki.Data;  // adjust if your DbContext namespace is different
using NoteWiki.Models;
using System.Linq;

namespace NoteWiki.Controllers
{
    public class NotesListController : Controller
    {
        private readonly AppDbContext _context;

        public NotesListController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid id)
        {
            var noteBox = _context.NoteBoxes
                                  .Where(nb => nb.NoteBoxGuid == id)
                                  .FirstOrDefault();

            var notes = _context.NoteMetadata.Where(nd => nd.NoteBoxGuid == id).ToList();

            //if (noteBox == null) return NotFound();

            var t = new Tuple<NoteBoxModel,List<NoteMetadataModel>> (noteBox,notes);

            return View(t);
        }

        public IActionResult Create(Guid NoteBoxGuid)
        {
            return RedirectToAction("Create", "Note", new { noteBoxGuid = NoteBoxGuid});
        }


        // seed
        public async Task<IActionResult> InsertNote(Guid id)
        {
            var noteMD = new NoteMetadataModel("B trees and whatever the fuck they are", id);

            await _context.NoteMetadata.AddAsync(noteMD);
            await _context.SaveChangesAsync();
            
            return Content("Inserted");
        }
    }
}
