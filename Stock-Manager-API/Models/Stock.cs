using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Stock_Manager_API.Models
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public int Amount { get; set; }

        public string Category { get; set; } = null!;
    }
}
