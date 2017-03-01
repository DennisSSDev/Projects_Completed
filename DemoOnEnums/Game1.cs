using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DemoOnEnums
{
    enum GameState
    {
        MAIN_MENU,
        GAME, 
        DEATH,
        INSTRUCTIONS
    };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GameState currentstate = GameState.MAIN_MENU;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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

            // TODO: use this.Content to load your game content here
        }

   
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        KeyboardState prev = Keyboard.GetState();
        KeyboardState ks;
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prev = ks;
            ks = Keyboard.GetState();
            // TODO: Add your update logic here
            
            if (ks.IsKeyDown(Keys.Space) && prev.IsKeyUp(Keys.Space))
            {
                switch (currentstate)
                {
                    case GameState.MAIN_MENU:
                        currentstate = GameState.GAME;
                        break;
                    case GameState.GAME:
                        currentstate = GameState.DEATH;
                        break;
                    case GameState.DEATH:
                        currentstate = GameState.INSTRUCTIONS;
                        break;
                    case GameState.INSTRUCTIONS:
                        currentstate = GameState.GAME;
                        break;
                    default:
                        break;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            switch (currentstate)
            {
                case GameState.MAIN_MENU:
                    GraphicsDevice.Clear(Color.Azure);
                    break;
                case GameState.GAME:
                    GraphicsDevice.Clear(Color.DeepPink);
                    break;
                case GameState.DEATH:
                    GraphicsDevice.Clear(Color.Black);
                    break;
                case GameState.INSTRUCTIONS:
                    GraphicsDevice.Clear(Color.Yellow);
                    break;
                default:
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
