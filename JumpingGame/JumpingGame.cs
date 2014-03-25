using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace JumpingGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class JumpingGame : GameHost
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public JumpingGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures.Add("Ball", this.Content.Load<Texture2D>("Ball"));
            Textures.Add("Rock", this.Content.Load<Texture2D>("Rock"));
            ResetGame();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.UpdateAll(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            DrawSprites(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void ResetGame()
        {
            GameObjects.Add(new BallObject(this, Textures["Ball"]));
            LastRockX = 0;
            GameObjects.Add(new RockObject(this, Textures["Rock"], 3.0f, LastRockX));
            GameObjects.Add(new RockObject(this, Textures["Rock"], 3.0f, LastRockX));
            GameObjects.Add(new RockObject(this, Textures["Rock"], 3.0f, LastRockX));
        }

        private float _lastRockX;

        internal float LastRockX
        {
            get
            {
                //TODO: change 100 to rock width
                _lastRockX += (this.GraphicsDevice.Viewport.Bounds.Width + 100) / 3.0f;
                return _lastRockX;
            }
            set
            {
                _lastRockX = value;
            }
        }
    }
}
