using CardGameWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWebTestings.Repositories
{
    public class CardRepositoryMock
    {
        public Game NewGame()
        {
            return new Game { Id = 1};
        }

        public Card NewCard()
        {
            return new Card { Id = 1, Name = "HS" };
        }

        public CardGame NewCardInGame()
        {
            return new CardGame { Id = 1, CardId = NewCard().Id, GameId = NewGame().Id };
        }


    }
}
