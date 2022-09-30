using CardGameWeb.Shared.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWebTestings.Repositories
{
    public class CardRepositoryTeast
    {
        CardRepository cardRepo = new CardRepository();
        CardRepositoryMock mock = new CardRepositoryMock();
   

        [Fact]
        public void AddGameTest()
        {
            // Arrange
            var newGame = mock.NewGame();

            // Act
            cardRepo.AddGame(newGame);

            var game = cardRepo.SearchGame(newGame.Id);

            // Assert
            Assert.NotNull(game);
            Assert.Equal(newGame.Id, game.Id);
        }


        [Fact]
        public void AddAndGetCardsTest()
        {
            // Arrange 
            cardRepo.AddCards();

            //Act
            var cards = cardRepo.GetCards();

            // Assert
            Assert.NotNull(cards);
            Assert.Equal(52, cards.Count());
        }


    }
}
