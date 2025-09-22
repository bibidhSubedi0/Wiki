namespace NoteWiki.Models
{
    public class NoteMetadataModel
    {

        public Guid NoteGuid { get; set; }
        public string NoteName { get; set; }
        public Guid NoteBoxGuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public NoteMetadataModel() { }

        public NoteMetadataModel(string name, Guid boxguid)
        {
            NoteGuid = Guid.NewGuid();
            NoteName = name;
            NoteBoxGuid = boxguid;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
