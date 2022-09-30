using CardGameWeb.Shared.Models;

namespace CardGameWeb.Server.Repository.CardRepository
{
    public interface ICardRepository
    {
        Task<Game> AddGame(Game game);  


        Task<List<Card>> GetCards();
        Task<List<Card>> GetRandomCards(int number);
        Task<Card> GetRandomCard();


        Task<List<CardGame>> GetCardByGameId(int id);
        Task<CardGame> GetCardByGameIdAndCardId(int gameId, int cardId);
        Task DeleteCardInGame(CardGame card);
        Task<CardGame> AddCardToGame(CardGame card);



        Task<CardHand> AddCardToHand(CardHand card);       
        Task<CardHand> GetCardInHandId(int cardId, int handId);
        Task<List<CardHand>> GetCardsInHandByHandId(int id);
        Task DeleteCardInHand(CardHand card);

        

        Task<Hand> AddHand(Hand hand);
        Task<Hand> GetHand(int id);
        Task<List<Hand>> GetHands();


        Task<List<JoinModel>> History();

    }
}
