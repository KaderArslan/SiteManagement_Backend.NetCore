using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SiteManagement.MongoDbApi
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Card> _cards;
        public DbClient(IOptions<CardDbConfig> cardDbConfig)
        {
            var client = new MongoClient(cardDbConfig.Value.Connection_String);
            var database = client.GetDatabase(cardDbConfig.Value.Database_Name);
            _cards = database.GetCollection<Card>(cardDbConfig.Value.Cards_Collection_Name);
        }

        public IMongoCollection<Card> GetCardsCollection()
        {
            return _cards;
        }
    }
}
