using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cards
{
    internal class CardUI
    {
        private static CardUI _currentlyHoldedCard;

        private Effect _selectEffect;
        private string _textureName;

        private Texture2D _texture;
        private int spriteZoom = 3;

        private Rectangle _currentCardPosition;
        //Used when player hold a card
        private Rectangle _temporaryCardPosition;

        private bool _isMouseHoverOverCard;

        //Card will be a little bit upper when mouse hovering over
        private int _selectedTopOffset = 20;       

        public CardUI(string textureName)
        {
            _textureName = textureName;
        }

        public void LoadATexture(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_textureName);
        }

        public void LoadSelectEffect(ContentManager content, string EffectName)
        {
            _selectEffect = content.Load<Effect>(EffectName);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, MouseState mouse)
        {
            _currentCardPosition = new Rectangle((int)location.X, (int)location.Y,
                _texture.Width * spriteZoom, _texture.Height * spriteZoom);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            OnMouseEnterCheck(mouse);

            if( _isMouseHoverOverCard && mouse.LeftButton == ButtonState.Pressed && 
                (_currentlyHoldedCard == null || _currentlyHoldedCard == this))
            {
                _temporaryCardPosition = new Rectangle(
                    mouse.X - _currentCardPosition.Width/2, 
                    mouse.Y - _currentCardPosition.Height/2,
                    _currentCardPosition.Width,
                    _currentCardPosition.Height);
                _currentlyHoldedCard = this;
            }
            else if(_isMouseHoverOverCard)
            {
                if(_currentlyHoldedCard == null)
                {
                    _selectEffect.CurrentTechnique.Passes[0].Apply();
                    _currentCardPosition.Y -= _selectedTopOffset;
                }
            }

            if(mouse.LeftButton == ButtonState.Released)
            {
                _currentlyHoldedCard = null;
                _temporaryCardPosition = Rectangle.Empty;
            }

            if(_temporaryCardPosition != Rectangle.Empty)
            {
                spriteBatch.Draw(_texture,
                _temporaryCardPosition,
                Color.White);
            } else
            {
                spriteBatch.Draw(_texture,
                _currentCardPosition,
                Color.White);
            }

            spriteBatch.End();
        }

        public void OnMouseEnterCheck(MouseState mouse)
        {
            if (_isMouseHoverOverCard && mouse.LeftButton == ButtonState.Pressed)
            {
                _isMouseHoverOverCard = _temporaryCardPosition.Contains(mouse.Position);

            }
            else
            {
                _isMouseHoverOverCard = _currentCardPosition.Contains(mouse.Position);
            }
        }
    }
}
