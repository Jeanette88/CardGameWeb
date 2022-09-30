using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWeb.Shared.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<CardGame> CardGames { get; set; }
    }
}
