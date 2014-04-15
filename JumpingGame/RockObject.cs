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
    public class RockObject : SpriteObject
    {
        private GameHost _game;
        private float _speed;
        private float _lastRockX;

        public bool IsRockMove;
        public RockObject(GameHost game, Texture2D texture, float speed, float lastRockX)
            : base(game, Vector2.Zero, texture)
        {
            _game = game;
            _speed = speed;
            _lastRockX = lastRockX;

            IsRockMove = true;
            Origin = new Vector2(texture.Width / 2, 0);

            Position = new Vector2(_lastRockX, _game.GraphicsDevice.Viewport.Bounds.Height - this.BoundingBox.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (((JumpingGame)_game).RockMove)
            {
                PositionX -= _speed;
                if (PositionX < -this.SpriteTexture.Width)
                {
                    PositionX = _game.GraphicsDevice.Viewport.Bounds.Width + _speed;
                }
            }
        }

        public bool IsDisplayed
        {
            get
            {
                return (this.PositionX + SpriteTexture.Width / 2.0f) > 0 && (this.PositionX - SpriteTexture.Width) < _game.GraphicsDevice.Viewport.Bounds.Width;
            }
        }
    }
}
