using MongoDB.Driver;
using System.Collections.Generic;

namespace SiteManagement.MongoDbApi
{
    public class CardServices : ICardServices
    {
        private readonly IMongoCollection<Card> _cards;
        public CardServices(IDbClient dbClient)
        {
            _cards = dbClient.GetCardsCollection();
        }

        //---get
        public List<Card> GetCards()
        {
            return _cards.Find(card => true).ToList();
        }

        public Card GetCard(int id)
        {
            return _cards.Find(card => card.CardId == id).First();
        }

        //---post
        public Card AddCard(Card card)
        {
            _cards.InsertOne(card);
            return card;
        }

        public Card AddCards(Card card)
        {
            _cards.InsertOne(card);
            return card;
        }

        //---delete
        public void DeleteCard(int id)
        {
            _cards.DeleteOne(card => card.CardId == id);
        }

        //---update
        public Card UpdateCard(Card card)
        {
            GetCard(card.CardId);
            _cards.ReplaceOne(c => c.CardId == card.CardId, card);
            return card;
        }
    }
}
