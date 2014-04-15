using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


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
            Textures.Add("Ocean", this.Content.Load<Texture2D>("Ocean"));
            Textures.Add("Cloud", this.Content.Load<Texture2D>("Cloud"));
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
            // back button pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            base.UpdateAll(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            DrawSprites(gameTime, spriteBatch, Textures["Cloud"]);
            DrawSprites(gameTime, spriteBatch, Textures["Ball"]);
            DrawSprites(gameTime, spriteBatch, Textures["Rock"]);
            DrawSprites(gameTime, spriteBatch, Textures["Ocean"]);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private RockObject[] _rockObjects;
        public RockObject[] RockObjects
        {
            get
            {
                return this._rockObjects;
            }
        }
        public RockObject[] InitiateRockObjects()
        {
            if (_rockObjects == null || _rockObjects.Length < 3)
            {
                _rockObjects = new RockObject[3];
                for (int i = 0; i < 3; ++i)
                {
                    _rockObjects[i] = new RockObject(this, Textures["Rock"], 5.0f, LastRockX);
                }
            }
            return _rockObjects;
        }
        private void ResetGame()
        {
            LastRockX = 0;
            InitiateRockObjects();

            GameObjects.Add(new BallObject(this, Textures["Ball"]));
            for (int i = 0; i < RockObjects.Length; ++i)
            {
                GameObjects.Add(RockObjects[i]);
            }
            GameObjects.Add(new OceanObject(this, Textures["Ocean"]));
            GameObjects.Add(new CloudObject(this, Textures["Cloud"]));
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
