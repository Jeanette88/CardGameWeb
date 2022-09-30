using CardGameWeb.Shared.Models;

namespace CardGameWeb.Client.Services.CardService
{
    public interface ICardService
    {

        List<Card> Cards { get; set; }
        List<CardGame> CardGames { get; set; }
        List<Game> Games{ get; set; }
        List<JoinModel> JoinModels { get; set; }


        Task AddGame(Game game);
        Task GetCards();
        Task GetCard(int id);
        Task GetRandomCards(int number);
        Task GetOneRandomCard();

        Task History();




    }
}
