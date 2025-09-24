using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class NoteController : Controller
    {
        private readonly MongoContext _mongoContext;
        private readonly AppDbContext _SqlContext;


        public NoteController(MongoContext mongoContext, AppDbContext sqlContext)
        {
            _mongoContext = mongoContext;
            _SqlContext = sqlContext;
        }

        [HttpGet]
        public IActionResult Index(Guid noteGuid, Guid noteBoxGuid)
        {
            // Need error handling here as well
            NoteContentModel? note = _mongoContext.Database?.GetCollection<NoteContentModel>("notes").Find(n => n.NoteGuid == noteGuid).FirstOrDefault();
            ViewBag.NoteGuid = noteGuid;
            ViewBag.NoteBoxGuid = noteBoxGuid;
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
            notedata.CreatedAt= notedata.UpdatedAt = DateTime.Now;

            NoteMetadataModel metadata = new NoteMetadataModel(notedata.NoteName,noteBoxGuid);
            metadata.NoteGuid = notedata.NoteGuid;
            metadata.UpdatedAt = metadata.CreatedAt = DateTime.Now;
            
            _mongoContext.Database?.GetCollection<NoteContentModel>("notes").InsertOne(notedata);
            _SqlContext.NoteMetadata.Add(metadata);
            _SqlContext.SaveChanges();

            return RedirectToAction("Index", "NotesList", new { id = metadata.NoteBoxGuid });
        }

        [HttpPost]
        public IActionResult Edit(NoteContentModel updatedNote)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { noteGuid = updatedNote.NoteGuid });
            }

            var notesCollection = _mongoContext.Database.GetCollection<NoteContentModel>("notes");
            updatedNote.UpdatedAt = DateTime.Now;
            notesCollection.ReplaceOne(n => n.NoteGuid == updatedNote.NoteGuid, updatedNote);
            var metadata = _SqlContext.NoteMetadata.FirstOrDefault(n => n.NoteGuid == updatedNote.NoteGuid);
            if (metadata != null)
            {
                metadata.NoteName = updatedNote.NoteName;
                metadata.UpdatedAt = DateTime.Now;
                _SqlContext.SaveChanges();
            }

            return RedirectToAction("Index", new { noteGuid = updatedNote.NoteGuid });
        }



        public IActionResult DeleteNote( Guid NoteGuid, Guid NoteBoxGuid)
        {
            Console.WriteLine($"xxx {NoteGuid}");
            _mongoContext.Database?.GetCollection<NoteContentModel>("notes").DeleteOne<NoteContentModel>(c=>c.NoteGuid== NoteGuid);
            var metadata = _SqlContext.NoteMetadata.Where(n => n.NoteGuid == NoteGuid).FirstOrDefault();
            _SqlContext.NoteMetadata.Remove(metadata);
            _SqlContext.SaveChanges();
            return RedirectToAction("Index", "NotesList", new { id = NoteBoxGuid });


        }
    }
}
