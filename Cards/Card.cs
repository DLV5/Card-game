using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

        private string _textureName;

        private Texture2D _texture;
        private int spriteZoom = 3;

        public Card(Suit suit, int id, string textureName)
        {
            Suit = suit;
            Id = id;
            _textureName = textureName;
        }

        public void LoadATexture(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_textureName);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture,
                new Rectangle((int)location.X, (int)location.Y,
                _texture.Width * spriteZoom, _texture.Height * spriteZoom),
                Color.White);
            spriteBatch.End();
        }
    }
}
