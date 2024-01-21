using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    /// <summary>
    /// Creates and fill the deck
    /// </summary>
    internal class DeckBootstap
    {
        public Deck Deck { get; private set; }

        public DeckBootstap()
        {
            List<Card> deck = FillTheDeck();
            deck = Shuffle(deck);
            Deck = new Deck(ConvertToArray(deck), ConvertToQueue(deck));
        }

        public static List<Card> Shuffle(List<Card> source)
        {
            return source?.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private Card[,] ConvertToArray(List<Card> cards)
        {
            Card[,] output = new Card[4, 9];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    output[i, j] = cards[j + 9 * i];
                }
            }

            return output;
        }

        private Queue<Card> ConvertToQueue(List<Card> cards)
        {
            return new Queue<Card>(cards);
        }

        private List<Card> FillTheDeck()
        {
            List<Card> deck = new List<Card>();

            deck = AddSuitToADeck(deck, Suit.Clubs);
            deck = AddSuitToADeck(deck, Suit.Hearts);
            deck = AddSuitToADeck(deck, Suit.Spades);
            deck = AddSuitToADeck(deck, Suit.Diamonds);

            return deck;
        }

        private List<Card> AddSuitToADeck(List<Card> source, Suit suit)
        {
            for(int i = 6; i < 15; i++)
            {
                Card card = new Card(suit, i, CreateACardName(i, suit));
                source.Add(card);
            }

            return source;
        }

        private string CreateACardName(int index, Suit suit)
        {
            string cardName = $"card_{suit}_".ToLower();
            //Check is is 10, Vallet, Queen, King or Ace
            if(index > 9)
            {
                switch(index)
                {
                    case 10:
                        cardName += "10";
                        break;
                    case 11:
                        cardName += "J";
                        break;
                    case 12:
                        cardName += "Q";
                        break;
                    case 13:
                        cardName += "K";
                        break;
                    case 14:
                        cardName += "A";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                cardName += $"0{index}";
            }

            return cardName;
        }


    }
}
