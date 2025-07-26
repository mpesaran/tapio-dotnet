using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class Email
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("projectId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string ProjectId { get; set; }

        [BsonElement("opportunityId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OpportunityId { get; set; }

        [BsonElement("mailBoxId")]
        public string? MailBoxId { get; set; }

        [BsonElement("subject")]
        public string? Subject { get; set; }

        [BsonElement("from")]
        public required string From { get; set; }

        [BsonElement("to")]
        public required List<string> To { get; set; }

        [BsonElement("cc")]
        public List<string>? Cc { get; set; }

        [BsonElement("bcc")]
        public List<string>? Bcc { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("isRead")]
        public bool IsRead { get; set; } = false;

        [BsonElement("isProcessed")]
        public bool IsProcessed { get; set; } = false;

        [BsonElement("isApproved")]
        public bool? IsApproved { get; set; }

        [BsonElement("isTapped")]
        public bool IsTapped { get; set; } = false;

        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; } = false;

        [BsonElement("isReplied")]
        public bool IsReplied { get; set; } = false;

        [BsonElement("isOutgoing")]
        public bool IsOutgoing { get; set; } = false;

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
