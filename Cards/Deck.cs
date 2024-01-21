using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Cards
{
    internal class Deck
    {
        //private const int _deckSize = 36;

        //size in pixels
        private const int _cartTextureWidth = 136;
        private const int _cartTextureHeight = 180;


        private const int _marginLeft = 150;
        private const int _marginTop = 67;
        private const int _marginRight = 42;
        private const int _marginBottom = 48;

        private int _currentDeckSize;

        //This is for printing
        private Card[,] _cards;

        //Same deck used when we need to take a card
        private Queue<Card> _queueOfCards;

        private bool _wasCardsPrinted = false;

        public Deck(Card[,] cards, Queue<Card> queueOfCards)
        {
            _cards = cards;
            _queueOfCards = queueOfCards;
        }

        public Card GetNextCard()
        {
            if (_currentDeckSize == 0)
            {
                Debug.WriteLine("Deck is empty!");
                return null;
            }

            _currentDeckSize--;
            Card card = _queueOfCards.Dequeue();

            return card;
        }

        public void LoadCards(ContentManager content)
        {
            foreach (Card card in _cards)
            {
                card.UI.LoadATexture(content);
                card.UI.LoadSelectEffect(content, "SelectEffect");
            }
        }

        public void DrawACards(SpriteBatch spriteBatch, MouseState mouse)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Vector2 placeToDraw = GetAPlaceToDraw(i, j);
                    _cards[i,j].UI.Draw(spriteBatch, placeToDraw, mouse);
                }
            }
        }

        public Vector2 GetAPlaceToDraw(int row, int column)
        {
            return new Vector2(_marginLeft + (_cartTextureWidth + _marginRight) * column,
                _marginTop +  (_cartTextureHeight + _marginBottom) * row);
        }
    }
}
