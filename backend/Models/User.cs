using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("fullName")]
        public string? FullName { get; set; }

        [BsonElement("email")]
        [BsonRequired]
        public required string Email { get; set; }

        [BsonElement("refresh_token")]
        public string? RefreshToken { get; set; }

        [BsonElement("token_cache")]
        public string? TokenCache { get; set; }

        [BsonElement("lastProject")]
        public string? LastProject { get; set; }

        [BsonElement("onBoarded")]
        public bool OnBoarded { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public void UpdateFullName(string newName)
        {
            FullName = newName.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

    }
}