using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace NoteWiki.Models
{
    public class NoteContentModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid NoteGuid { get; set; }
        [BsonElement("NoteName")]
        public string NoteName { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } 
        public NoteContentModel(Guid noteGuid, string content, string noteName)
        {
            NoteGuid = noteGuid;
            Content = content;
            NoteName = noteName;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public NoteContentModel() { }
    }
}

