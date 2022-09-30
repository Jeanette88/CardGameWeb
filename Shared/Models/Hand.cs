namespace CardGameWeb.Shared.Models
{
    public class Hand
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public List<CardHand> CardHands { get; set; }
    }
}