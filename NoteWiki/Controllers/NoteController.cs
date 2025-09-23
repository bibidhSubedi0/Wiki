using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class NoteController : Controller
    {
        private readonly IMongoCollection<NoteContentModel> _content;

        public NoteController(MongoContext mongoContext)
        {
            _content = mongoContext.Database?.GetCollection<NoteContentModel>("notes")
                        ?? throw new Exception("Could not connect to MongoDB collection.");
        }

        // GET: /Note?searchString=...
        public IActionResult Index(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return View(new List<NoteContentModel>()); // Empty if no search
            }

            // Fetch notes where NoteName matches search string (case-insensitive)
            var notes = _content.Find(n => n.NoteName.ToLower().Contains(searchString.ToLower())).ToList();
            ViewBag.SearchString = searchString;
            return View(notes);
        }

        // GET: /Note/Details/{id}
        public IActionResult Details(Guid id)
        {
            var note = _content.Find(n => n.NoteGuid == id).FirstOrDefault();
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpGet]
        public async Task<IActionResult> AddTestNote()
        {
            var newNote = new NoteContentModel(Guid.NewGuid(), "This is a test content 2", "abc");

            try
            {
                await _content.InsertOneAsync(newNote);
                return Content($"Inserted new test note: {newNote.NoteName}");
            }
            catch (Exception ex)
            {
                return Content("Error inserting note: " + ex.Message);
            }
        }

    }
}
