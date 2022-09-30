using CardGameWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWebTestings.Repositories
{
    public class CardRepository
    {
        public List<Game> games = new List<Game>();
        public List<Card> cards = new List<Card>();
        public List<CardGame> cardGames = new List<CardGame>();
        public List<Hand> hands = new List<Hand>();
        public List<CardHand> cardHands = new List<CardHand>();
        public List<Enum> enums = new List<Enum>();

        public List<Card> GetCards()
        {
            return cards;
        }

        public Game AddGame(Game game)
        {
            games.Add(game);

            return game;
        }

        public List<CardGame> GetCardsByGameId(int id)
        {
            return cardGames.Where(x => x.GameId == id).ToList();
        }
        public Game SearchGame(int id)
        {
            return games.FirstOrDefault(x => x.Id == id);

        }

        public List<Enum> GetEnums()
        {
            return enums;
        }

        public List<Card> AddCards()
        {
            List<string> suits = new List<string> { "spades", "diamonds", "clubs", "hearts" };
            List<string> values = new List<string> { "ace", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "jack", "queen", "king" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    var cardName = value + " " + suit;
                    cards.Add(new Card { Id = 2, Name = cardName });
                }
            }

            return cards;
        }
    }
}
