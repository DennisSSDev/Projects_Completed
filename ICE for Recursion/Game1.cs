using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace ICE_for_Recursion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D memeHold;
        SpriteFont counter;
        public Game1()
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
            memeHold = Content.Load<Texture2D>("Meme");
            counter = Content.Load<SpriteFont>("Count");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public int DrawNeatRecursiveThing(int x, int y, int width, int height, Color color)
        {
            int count = 1;
            spriteBatch.Draw(memeHold, new Rectangle(x, y, width, height), color);
            Random someRandom = new Random();
            int randomizer = someRandom.Next(1, 4);
            switch (randomizer)
            {
                case 1:
                    color = Color.White;
                    break;
                case 2:
                    color = Color.Red;
                    break;
                case 3:
                    color = Color.RoyalBlue;
                    break;
                default:
                    color = Color.White;
                    break;
            }
            if (width > 10 && height > 10)
            {
                
                count += DrawNeatRecursiveThing(x, y, width/2, height/2, color);
                count += DrawNeatRecursiveThing(GraphicsDevice.Viewport.Width-width / 2, GraphicsDevice.Viewport.Height-height / 2, width/2, height/2, color);
                
            }

            return count;

            

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            spriteBatch.DrawString(counter, String.Format("{0:0}", DrawNeatRecursiveThing(0, 0, 500, 500, Color.White)), new Vector2(750, 10), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
