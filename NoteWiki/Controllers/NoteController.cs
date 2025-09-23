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

        public IActionResult Index(Guid noteGuid)
        {
            Console.WriteLine(noteGuid);
            NoteContentModel note = _content.Find(n => n.NoteGuid == noteGuid).FirstOrDefault();
            if (note == null) return Content("No notes");
            Console.WriteLine(note.Content);
            return View(note);
        }



        [HttpGet("Note/AddTestNote/{noteGuid}")]
        public async Task<IActionResult> AddTestNote(Guid noteGuid)
        {
            Console.WriteLine($"Route gave me: {noteGuid}");
            var newNote = new NoteContentModel(noteGuid, "this is some fuckass note from the note guid huhu haha", "Crazy Note");

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
