using System.Collections.Generic;

namespace Cards
{
    internal class PlayerHand
    {
        private List<Card> _cards;

        private int _startAmountOfCards = 6;

        public PlayerHand()
        {
            //Get cards from a deck
        }

        public PlayerHand(int startAmountOfCards)
        {
            _startAmountOfCards = startAmountOfCards;
            //Get cards from a deck
        }
    }
}
