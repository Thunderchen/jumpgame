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
    class CloudObject : SpriteObject
    {
        private GameHost _game;
        internal CloudObject(GameHost game, Texture2D texture)
            : base(game, Vector2.Zero, texture)
        {
            _game = game;
            PositionY = _game.GraphicsDevice.Viewport.Bounds.Height / 5.0f;
            PositionX = GameHelper.RandomNext(0, _game.GraphicsDevice.Viewport.Bounds.Width);
        }

        public override void Update(GameTime gameTime)
        {
            PositionX -= 5;
            if (PositionX < -SpriteTexture.Width)
            {
                PositionX = _game.GraphicsDevice.Viewport.Bounds.Width;
            }
            base.Update(gameTime);
        }
    }
}
