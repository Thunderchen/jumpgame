using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingGame
{
    class OceanObject : SpriteObject
    {
        private GameHost _game;
        internal OceanObject(GameHost game, Texture2D texture)
            : base(game, Vector2.Zero, texture)
        {
            _game = game;
            OriginY = texture.Height;
            PositionY = _game.GraphicsDevice.Viewport.Bounds.Height;
            ScaleX = _game.GraphicsDevice.Viewport.Bounds.Width * 1.0f / texture.Width;
            ScaleY = 1.0f;
        }

        private int _scaleYChangeCount = 0;
        private bool _scaleYIncrease = true;
        public override void Update(GameTime gameTime)
        {
            if (_scaleYIncrease)
            {
                ScaleY += 0.01f;
                _scaleYChangeCount++;
            }
            else
            {
                ScaleY -= 0.01f;
                _scaleYChangeCount++;
            }
            if (_scaleYChangeCount > 70)
            {
                _scaleYIncrease = !_scaleYIncrease;
                _scaleYChangeCount = 0;
            }
            base.Update(gameTime);
        }
    }
}
