using System.Collections.Generic;

namespace SiteManagement.MongoDbApi
{
    public interface ICardServices
    {
        //---get
        List<Card> GetCards();
        Card GetCard(int id);
        //---post
        Card AddCard(Card card);
        Card AddCards(Card card);
        //---delete
        void DeleteCard(int id);
        //---update
        Card UpdateCard(Card card);


    }
}
