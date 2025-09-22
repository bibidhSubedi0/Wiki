namespace NoteWiki.Models
{
    public class NoteContentModel
    {
        public Guid NoteGuid { get; set; }  // Unique identifier for the note

        public string Content { get; set; }  // The actual content of the note

        public DateTime CreatedAt { get; set; }  // Timestamp of content creation

        public DateTime UpdatedAt { get; set; }  // Timestamp of last content update
        public NoteContentModel(Guid noteGuid, string content)
        {
            NoteGuid = noteGuid;
            Content = content;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}

