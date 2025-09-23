using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace NoteWiki.Models
{
    public class NoteContentModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid NoteGuid { get; set; }  // Unique identifier for the note
        [BsonElement("NoteName")]
        public string NoteName { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }  // The actual content of the note
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }  // Timestamp of content creation
        [BsonElement("updatedAt")]
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

