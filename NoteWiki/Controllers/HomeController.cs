using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _sqlContext;
        private readonly MongoContext _mongoContext;


        //protected Guid GetUserGuid(AppDbContext context)
        //{
        //    var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        //    return _sqlContext.Users.FirstOrDefault(c => c.Email == email)?.UserID ?? throw new Exception("User not found");
        //}
        protected Guid GetUserGuid(string email, AppDbContext context)
        {
            return _sqlContext.Users.FirstOrDefault(c => c.Email == email)?.UserID??throw new Exception("User not found");
        }


        public HomeController(AppDbContext context, MongoContext mongoContext)
        {
            _sqlContext = context;
            _mongoContext = mongoContext;
        }


        public IActionResult Index()
        {
            var noteboxes = _sqlContext.NoteBoxes.ToList();
            return View(noteboxes);
        }

        [HttpPost]
        public IActionResult Create(NoteBoxModel noteBox)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home"); 
            }

            noteBox.NoteBoxGuid = Guid.NewGuid();
            noteBox.CreatedAt = DateTime.Now;
            noteBox.LastUpdatedAt = DateTime.Now;

            // Will need error handling here
            //var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var email = "hello@gmail.com";
            noteBox.UserGuid = GetUserGuid(email, _sqlContext);
            
            _sqlContext.NoteBoxes.Add(noteBox);
            _sqlContext.SaveChanges();
            return RedirectToActionPermanent("Index", "Home");
        }


        public IActionResult Options(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }


        public IActionResult RemoveBox(Guid id)
        {
            NoteBoxModel? noteBox = _sqlContext.NoteBoxes.FirstOrDefault(c => c.NoteBoxGuid == id);
            List<NoteMetadataModel> notesMetadataList = _sqlContext.NoteMetadata.Where(n => n.NoteBoxGuid == id).ToList();
            
            foreach (var note in notesMetadataList)
            {
                // Will need some error handling here
                _mongoContext.Database?.GetCollection<NoteContentModel>("notes").DeleteOne(m => m.NoteGuid == id);
            }

            // Error handling here also
            _sqlContext.NoteMetadata.RemoveRange(notesMetadataList);
            _sqlContext.NoteBoxes.Remove(noteBox);
            _sqlContext.SaveChanges();
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}
