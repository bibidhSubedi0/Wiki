using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class NoteController : Controller
    {
        private readonly IMongoCollection<NoteContentModel> _context;

        private readonly AppDbContext _SqlContext;

        public NoteController(MongoContext mongoContext, AppDbContext sqlContext)
        {
            _context = mongoContext.Database?.GetCollection<NoteContentModel>("notes")
                        ?? throw new Exception("Could not connect to MongoDB collection.");
            _SqlContext = sqlContext;
        }

        public IActionResult Index(Guid noteGuid)
        {
            NoteContentModel note = _context.Find(n => n.NoteGuid == noteGuid).FirstOrDefault();
            if (note == null) return Content("No notes");
            return View(note);
        }

        [HttpGet]
        public IActionResult Create(Guid noteBoxGuid)
        {
            ViewBag.NoteBoxGuid = noteBoxGuid;
            return View();
        }

        [HttpPost]
        public IActionResult Create(NoteContentModel notedata, Guid noteBoxGuid) {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "NoteList");
            }
            notedata.NoteGuid = Guid.NewGuid();
            notedata.CreatedAt = DateTime.Now;
            notedata.UpdatedAt = DateTime.Now;

            NoteMetadataModel metadata = new NoteMetadataModel();
            metadata.NoteGuid = notedata.NoteGuid;
            metadata.NoteBoxGuid = noteBoxGuid;
            metadata.UpdatedAt = DateTime.Now;
            metadata.CreatedAt = DateTime.Now;
            metadata.NoteName = notedata.NoteName;
            
            

            _context.InsertOne(notedata);
            _SqlContext.NoteMetadata.Add(metadata);
            _SqlContext.SaveChanges();



            return RedirectToAction("Index", "NotesList", new { id = metadata.NoteBoxGuid });
        }
        



        [HttpGet("Note/AddTestNote/{noteGuid}")]
        public async Task<IActionResult> AddTestNote(Guid noteGuid)
        {
            var newNote = new NoteContentModel(noteGuid, "this is some fuckass note from the note guid huhu haha", "Crazy Note");

            try
            {
                await _context.InsertOneAsync(newNote);
                return Content($"Inserted new test note: {newNote.NoteName}");
            }
            catch (Exception ex)
            {
                return Content("Error inserting note: " + ex.Message);
            }
        }

    }
}
