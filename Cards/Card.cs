namespace Cards
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades,
    }

    internal class Card
    {
        public Suit Suit {  get; private set; }
        public int Id { get; private set; }
        public CardUI UI { get; private set; }

        public Card(Suit suit, int id, string textureName)
        {
            Suit = suit;
            Id = id;
            UI = new CardUI(textureName);
        }      
    }
}
