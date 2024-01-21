using System.Collections.Generic;

namespace Cards
{
    internal class PlayerHand
    {
        private Deck _deck;

        private List<Card> _cardsInHand;

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

        private void FillTheHand()
        {
            for (int i = 0; i < _startAmountOfCards; i++)
            {
                _cardsInHand[i] = _deck.GetNextCard();
            }
        }
    }
}
