using MongoDB.Driver;

namespace SiteManagement.MongoDbApi
{
    public interface IDbClient
    {
        IMongoCollection<Card> GetCardsCollection();
    }
}
