using CardGameWeb.Client.Services.CardService;
using CardGameWeb.Server.Data;
using CardGameWeb.Shared.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace CardGameWeb.Server.Repository.CardRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;

        public CardRepository(DataContext context)
        {
            _context = context;
        }


        // --------------------Card

        public async Task<List<Card>> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return cards;
        }

        public async Task<List<Card>> GetRandomCards(int number)
        {
            var card = await _context.Cards.OrderBy(h => Guid.NewGuid()).Take(number).ToListAsync();
            return card;
        }

        public async Task<Card> GetRandomCard()
        {
            var cards = await GetCards();

            Random rand = new Random();
            var card = new Card();

            for (int i = 0; i < cards.Count; i++)
            {
                int number = rand.Next(0, cards.Count);
                card = cards[number];
            }
            return card;
        }

        // --------------------Game

        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        //-----------------------CardGame

        public async Task<List<CardGame>> GetCardByGameId(int id)
        {
            var cards = await _context.CardGames.Where(x => x.GameId == id).ToListAsync();
            return cards;
        }

        public async Task<CardGame> GetCardByGameIdAndCardId(int gameId, int cardId)
        {
            var card = await _context.CardGames.FirstOrDefaultAsync(x => x.GameId == gameId
             && x.CardId == cardId);
            return card;
        }

        public async Task DeleteCardInGame(CardGame card)
        {
            _context.CardGames.Remove(card);
            await SaveChanges();
        }

        public async Task<CardGame> AddCardToGame(CardGame card)
        {
            _context.CardGames.Add(card);
            await SaveChanges();
            return card;
        }


        // ------------------------ Hand

        public async Task<Hand> AddHand(Hand hand)
        {
            _context.Hands.Add(hand);
            await _context.SaveChangesAsync();
            return hand;
        }
        public async Task<Hand> GetHand(int id)
        {
            var hand = await _context.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .FirstOrDefaultAsync(x => x.Id == id);

            return hand;
        }

        public async Task<List<Hand>> GetHands()
        {
            var hands = await _context.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .Include(x => x.Game)
                .Take(40)
                .ToListAsync();

            return hands;
        }

        //--------------------- CardHand

        public async Task<CardHand> AddCardToHand(CardHand card)
        {
            _context.CardHands.Add(card);
            await SaveChanges();
            return card;
        }
  
        public async Task<List<CardHand>> GetCardsInHandByHandId(int id)
        {
            var cards = await _context.CardHands.Where(x => x.HandId == id).ToListAsync();
            return cards;
        }
   
        public async Task<CardHand> GetCardInHandId(int cardId, int handId)
        {
            var card = await _context.CardHands.FirstOrDefaultAsync(x =>
               x.CardId == cardId && x.HandId == handId);
            return card;
        }

        public async Task DeleteCardInHand(CardHand card)
        {
            _context.CardHands.Remove(card);
            await SaveChanges();
        }


        public async Task<List<JoinModel>> History()
        {

            var games = await (from h in _context.Cards

                               join hg in _context.CardGames on h.Id equals hg.Id
                               join g in _context.Games on hg.GameId equals g.Id
                               //join c in _context.Hands on g.Id equals c.GameId

                               select new JoinModel
                               {
                                   Games = hg.GameId,
                                   Name = h.Name,
                                   GameId = hg.GameId,
                                   CardId = hg.CardId,
                                   ImgName = h.ImgName,
                                   
                                  

                               }).OrderByDescending(g => g.GameId).ToListAsync();

            return games;

        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
