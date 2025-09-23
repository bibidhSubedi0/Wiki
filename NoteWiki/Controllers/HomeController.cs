using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteWiki.Data;
using NoteWiki.Models;

namespace NoteWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

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
