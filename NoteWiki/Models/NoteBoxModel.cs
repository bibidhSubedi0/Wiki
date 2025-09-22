namespace NoteWiki.Models
{
    public class NoteBoxModel
    {
        public string BoxName { get; set; }
        public Guid UserGuid { get; set; }
        public Guid NoteBoxGuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public NoteBoxModel() { }

        public NoteBoxModel(string boxName, Guid userGuid)
        {
            BoxName = boxName;
            UserGuid = userGuid;
            NoteBoxGuid = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
    }
}
