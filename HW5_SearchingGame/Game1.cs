using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace HW5_SearchingGame
{
    /// <summary>
    /// This class serves only for:
    /// *Creating objects for threading
    /// *Loading in Textures
    /// *Checking wether the win condition is met
    /// *Drawing all the movement
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Texture2D dafy;
        Texture2D bugs;
        Rectangle boxSize;
        
        Random ran = new Random();
        GameBoard obj;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";//decide to change the game to these dimensions
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 400;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);//Loading in all the textures here
            square = Content.Load<Texture2D>("square");
            boxSize = new Rectangle(0, 0, 50, 50);
            obj = new GameBoard();//gameBoard taht does all the work
            
            dafy = Content.Load<Texture2D>("Dafy");
            bugs = Content.Load<Texture2D>("bugs");
            obj.Texture = square;
            obj.Player.image = bugs;//Assign the textures
            obj.Target.texOfTarget = dafy;
            //obj.StartGame();                                                <---- unneccessary method
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
            //Win conditions

            if (obj.Player.dead)
            {
                this.Exit();
            }
            if (obj.Target.Dead)
            {
                this.Exit();
            }
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Draw out all the movements
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            obj.drawBoard(spriteBatch);
            spriteBatch.Draw(obj.Player.image, obj.Player.playerObj, Color.White);
            spriteBatch.Draw(obj.Target.texOfTarget, obj.Target.targetObj, Color.White);
            
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
