namespace CardGameWeb.Shared.Models
{
    public class CardHand
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int HandId { get; set; }
        public Card Card { get; set; }
        public Hand Hand { get; set; }

    }
}