using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWeb.Shared.Models
{
    public class CardGame
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card? Card { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}
