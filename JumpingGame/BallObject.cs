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
    class BallObject : SpriteObject
    {
        private GameHost _game;
        internal BallObject(GameHost game, Texture2D texture)
            : base(game, Vector2.Zero, texture)
        {
            _game = game;
            Position = new Vector2(_game.GraphicsDevice.Viewport.Bounds.Width, _game.GraphicsDevice.Viewport.Bounds.Height) / 2;
            Origin = new Vector2(texture.Bounds.Width, texture.Bounds.Height) / 2; 
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
    }
}
