using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
namespace HWnumber2
{
    enum GameState
    {
        Menu,
        Game, 
        GameOver
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        
        Player mainCharacter;
        List<Collectible> listOfCollectibles;

        Texture2D playerTex;
        Texture2D collTex;
        int level = 1;
        double timer = 0;
        KeyboardState kbState;
        KeyboardState previousKbState;
        int adder = 0;
        Random giveRandom = new Random();
        GameState curState;
        public void NextLevel()
        {
            level++;
            timer = 10;//logic won't work, find out how to make this a working timer in RL
            adder = (int)Math.Round(level * 1.5);
            mainCharacter.LevelScore = 0;
            mainCharacter.X = GraphicsDevice.Viewport.Width / 2;
            mainCharacter.Y = GraphicsDevice.Viewport.Height / 2;
            listOfCollectibles.Clear();
            for(int i = 0; i < 4 + adder; i++)
            {
                listOfCollectibles.Add(new Collectible(giveRandom.Next(5,GraphicsDevice.Viewport.Width-10),
                    giveRandom.Next(5,GraphicsDevice.Viewport.Height-10), 
                    20,20));
                listOfCollectibles[i].CurTexture = collTex;
            }
        }
        public void ResetGame()
        {
            level = 0;
            mainCharacter.TotalScore = 0;
            NextLevel();
        }
        public void ScreenWrap()
        {
            if (mainCharacter.Position.X > GraphicsDevice.Viewport.Width)//Might not work since checking for screen width
            {
                mainCharacter.X = 0;
            }
            else if (mainCharacter.Position.X < -2)
            {
                mainCharacter.X = GraphicsDevice.Viewport.Width;
            }

            if (mainCharacter.Position.Y > GraphicsDevice.Viewport.Height)
            {
                mainCharacter.Y = 0;
            }
            else if(mainCharacter.Position.Y < -1)
            {
                mainCharacter.Y = GraphicsDevice.Viewport.Height;
            } 
        }
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
            base.Update(gameTime);
            curState = GameState.Menu;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
