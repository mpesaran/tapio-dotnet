using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string UserId { get; set; }

        [BsonElement("startDate")]
        public required DateTime StartDate { get; set; }

        [BsonElement("filters")]
        public List<string> Filters { get; set; } = [];

        [BsonElement("blocked")]
        public List<string> Blocked { get; set; } = [];

        [BsonElement("lastEmailSync")]
        public DateTime LastEmailSync { get; set; }

        [BsonElement("inboxConnected")]
        public bool InboxConnected { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
