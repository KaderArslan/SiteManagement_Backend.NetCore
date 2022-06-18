using MongoDB.Bson.Serialization.Attributes;

namespace SiteManagement.MongoDbApi
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CardCVC { get; set; }
        public double CardPayment { get; set; }
    }
}
