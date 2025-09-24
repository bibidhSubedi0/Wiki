using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        protected Guid GetUserGuid(string email, AppDbContext context)
        {
            //var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            return _context.Users.FirstOrDefault(c => c.Email == email)?.UserID??throw new Exception("User not found");
        }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Get all the notes listed.
            var noteboxes = _context.NoteBoxes.ToList();
            return View(noteboxes);
        }

        public IActionResult Create(NoteBoxModel noteBox)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("dsfasdfsdfasdfasds");
                return RedirectToAction("Index", "Home"); 
            }
            noteBox.NoteBoxGuid = Guid.NewGuid();
            noteBox.CreatedAt = DateTime.Now;
            noteBox.LastUpdatedAt = DateTime.Now;
            try {
                //var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var email = "hello@gmail.com";
                noteBox.UserGuid = GetUserGuid("hello@gmail.com", _context);
            }
            catch
            {
                // will deal with ui later
                return RedirectToAction("Index", "Home");
            }
            _context.NoteBoxes.Add(noteBox);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // Seed
        public async Task<IActionResult> AddNoteBox()
        {
            var newNoteBox = new NoteBoxModel("Operating Systems", Guid.NewGuid());
            try
            {
                await _context.NoteBoxes.AddAsync(newNoteBox);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Content("Error inserting note: " + ex.Message);
            }

            return Content("Added");
        }


    }
}
