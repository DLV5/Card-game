using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

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
        private Card[,] _cards;

        private bool _wasCardsPrinted = false;

        public Deck(Card[,] cards)
        {
            _cards = cards;
        }

        //public Card GetNextCard()
        //{
        //    if (_currentDeckSize == 0)
        //    {
        //        Debug.WriteLine("Deck is empty!");
        //        return null;
        //    }

        //    Card card = _cards.Dequeue();
        //    _cards.Enqueue(card);

        //    return card;
        //}

        public void LoadCards(ContentManager content)
        {
            foreach (Card card in _cards)
            {
                card.LoadATexture(content);
            }
        }

        public void DrawACards(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Vector2 placeToDraw = GetAPlaceToDraw(i, j);
                    _cards[i,j].Draw(spriteBatch, placeToDraw);
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
