using CardGameWeb.Client.Services.CardService;
using CardGameWeb.Server.Repository.CardRepository;
using CardGameWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardGameWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {    

        private readonly ICardRepository _cardRepo;
        public CardController(ICardRepository context)
        {
            _cardRepo = context;
        }

        [HttpGet]
        public async Task<ActionResult<Card>> GetCards()
        {
            var cards = await _cardRepo.GetCards();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardGame>> GetCard(int id)
        {
            var card = await _cardRepo.GetCardsInHandByHandId(id);
            if (card == null)
                return NotFound("No card here.");

            return Ok(card);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomCards(int number)
        {
            var card = await _cardRepo.GetRandomCards(number);
            return Ok(card);
        }

        [HttpGet("onerandom")]
        public async Task<IActionResult> RandomCard()
        {
            var cards = await _cardRepo.GetRandomCard();
            return Ok(cards);
        }

        [HttpGet("history")]
        public async Task<IActionResult> History()
        {
            var games = await _cardRepo.History();
            return Ok(games);
        }

    }
}
