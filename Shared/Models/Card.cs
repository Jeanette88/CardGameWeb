using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWeb.Shared.Models
{
    public class Card
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? ImgName { get; set; }

        public List<CardGame>? CardGames { get; set; }
        public List<CardHand>? CardHands { get; set; }
        
    }
}
