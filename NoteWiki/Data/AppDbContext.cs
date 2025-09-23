using Microsoft.EntityFrameworkCore;
using NoteWiki.Models;

namespace NoteWiki.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteBoxModel> NoteBoxes { get; set; }
        public DbSet<NoteMetadataModel> NoteMetadata { get; set; }

    }
}
