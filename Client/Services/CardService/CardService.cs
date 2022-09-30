using CardGameWeb.Shared.Models;
using System.Net.Http.Json;


namespace CardGameWeb.Client.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly HttpClient _http;

        public CardService(HttpClient http)
        {
            _http = http;
        }

        public List<JoinModel> JoinModels{ get; set; } = new List<JoinModel>();
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<CardGame> CardGames { get; set; } = new List<CardGame>();
        public List<Game> Games { get; set; } = new List<Game>();

        public async Task GetCards()
        {
            var result = await _http.GetFromJsonAsync<List<Card>>("api/card");
            if (result != null)
                Cards = result;
        }

        public async Task GetRandomCards(int number)
        {
            var result = await _http.GetFromJsonAsync<List<Card>>($"api/card/random?number={number}");
            if (result != null)
                Cards = result;

        }

        public async Task GetOneRandomCard()
        {
            var result = await _http.GetFromJsonAsync<List<Card>>($"api/card/onerandom");
            if (result != null)
                Cards = result;
        }

        public async Task GetCard(int id)
        {
            var result = await _http.GetFromJsonAsync<List<CardGame>>($"api/card/{id}");
            if (result != null)
                CardGames = result;

        }

        public async Task AddGame(Game game)
        {
            var result = await _http.GetFromJsonAsync<List<Game>>($"api/card/number={game}");
            if (result != null)
                Games = result;

  
        }

        public async Task History()
        {
            var result = await _http.GetFromJsonAsync<List<JoinModel>>($"api/card/history");
            if (result != null)
                JoinModels = result;
        }
    }
}
