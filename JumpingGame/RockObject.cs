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
    class RockObject : SpriteObject
    {
        private GameHost _game;
        private float _speed;
        private float _lastRockX;
        internal RockObject(GameHost game, Texture2D texture, float speed, float lastRockX)
            : base(game, Vector2.Zero, texture)
        {
            _game = game;
            _speed = speed;
            _lastRockX = lastRockX;
            Origin = new Vector2(texture.Width / 2, texture.Height);

            Position = new Vector2(_lastRockX, _game.GraphicsDevice.Viewport.Bounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            PositionX -= _speed;
            if (PositionX < -this.SpriteTexture.Width)
            {
                PositionX = _game.GraphicsDevice.Viewport.Bounds.Width + _speed;
            }
        }
    }
}
