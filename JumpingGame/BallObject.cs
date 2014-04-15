﻿using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
            Reset();
        }

        private int _jumpCount;
        private const int JUMPCOUNTMAX = 3;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {


            TouchCollection tc = TouchPanel.GetState();
            if (tc.Count == 1)
            {
                if (tc[0].State == TouchLocationState.Pressed && _jumpCount < JUMPCOUNTMAX)
                {
                    _isJumping = true;
                    _isFalling = false;
                    _jumpCount++;
                }
            }
            if (HasCrashed() != null)
            {
                _isFalling = true;
                _isJumping = false;
                _jumpCount = 3;
            }

            if (_isFalling && !_isJumping)
            {
                PositionY += 5;
                RockObject rockObj = HasLanded();
                if (rockObj != null)
                {
                    _isFalling = false;
                    _isJumping = false;
                    _jumpCount = 0;
                }
                else
                {
                    _isFalling = true;
                    _isJumping = false;
                }
            }else if(_isJumping && !_isFalling){
                PositionY -= 5;
                if (PositionY < _game.GraphicsDevice.Viewport.Bounds.Height * 0.3f)
                {
                    _isFalling = true;
                    _isJumping = false;
                }
        
            }
            else if (!_isJumping && !_isFalling)
            {
                RockObject rockObj = HasLanded();
                if (rockObj != null)
                {
                    _isFalling = false;
                    _isJumping = false;
                    _jumpCount = 0;
                }
                else
                {
                    _isFalling = true;
                    _isJumping = false;
                }
            }
            /**
            else
            {
                PositionY -= 5;
                if (PositionY < _game.GraphicsDevice.Viewport.Bounds.Height * 0.3f)
                {
                    _isFalling = true;
                }
            }*/


            if(this.PositionY > _game.GraphicsDevice.Viewport.Bounds.Height){
                Reset();
            }    
            base.Update(gameTime);
        }

        private bool _isFalling;
        private bool _isJumping;
        //TODO: switch isFaling
        public RockObject HasLanded()
        {
            RockObject[] rockObjects;
            RockObject rockObj;

            rockObjects = ((JumpingGame)_game).RockObjects;
            for (int i = 0; i < rockObjects.Length; ++i)
            {
                rockObj = rockObjects[i];
                if (rockObj != null && rockObj.IsDisplayed)
                {
                    //TODO: if landed?
                    if(this.PositionX + this.BoundingBox.Width >= rockObj.PositionX - rockObj.BoundingBox.Width/2 && this.PositionX <= rockObj.PositionX + rockObj.BoundingBox.Width/2 &&
                        this.PositionY >= rockObj.PositionY - 5.0f && this.PositionY <= rockObj.PositionY + 5.0f)
                    {
                        return rockObj;
                    }
                    
                }
            }
            return null;
        }

        public RockObject HasCrashed()
        {
            RockObject[] rockObjects;
            RockObject rockObj;

            rockObjects = ((JumpingGame)_game).RockObjects;
            for (int i = 0; i < rockObjects.Length; ++i)
            {
                rockObj = rockObjects[i];
                if (rockObj != null && rockObj.IsDisplayed)
                {
                    //TODO: if landed?
                    if (this.PositionX + this.BoundingBox.Width >= rockObj.PositionX - rockObj.BoundingBox.Width / 2 && 
                        this.PositionY >= rockObj.PositionY && this.PositionY >= 0)
                    {
                        return rockObj;
                    }

                }
            }
            return null;
        }

        public void Reset()
        {
            Position = new Vector2(_game.GraphicsDevice.Viewport.Bounds.Width, _game.GraphicsDevice.Viewport.Bounds.Height) / 2;
            Origin = new Vector2(0, this.BoundingBox.Height);
            _isFalling = true;
            _jumpCount = 0;
        }
    }
}
