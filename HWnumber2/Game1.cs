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
        KeyboardState previousKbState = Keyboard.GetState();
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

        public bool SingleKeyPress(Keys someKey)//there has to be a key parameter
        {
            previousKbState = kbState;//might not be needed check during debug
            kbState = Keyboard.GetState();
          
            if(kbState.IsKeyDown(someKey) && previousKbState.IsKeyUp(someKey))
            {  
                return true;    
            }
            else
            {
                return false;
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
            mainCharacter = new Player(10, 10, 50, 50);
            listOfCollectibles = new List<Collectible>();
            curState = GameState.Menu;
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
            spriteFont = Content.Load<SpriteFont>("spriteFont");
            playerTex = Content.Load<Texture2D>("Sanic");
            collTex = Content.Load<Texture2D>("heart");
            mainCharacter.CurTexture = playerTex;


            
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
            switch (curState)
            {
                case GameState.Menu:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        curState = GameState.Game;
                        ResetGame();
                    }
                    break;
                case GameState.Game:
                    previousKbState = kbState;//might not be needed check during debug
                    kbState = Keyboard.GetState();
                    if(gameTime.ElapsedGameTime.TotalSeconds == 1)
                    {
                        timer--;
                    }
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
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
            spriteBatch.Begin();
            switch (curState)
            {
                case GameState.Menu:
                    spriteBatch.DrawString(spriteFont, "Sanic Hearts", new Vector2(200, 200), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Press Enter to Play", new Vector2(200, 250), Color.Black);
                    break;
                case GameState.Game:
                    spriteBatch.Draw(mainCharacter.CurTexture, mainCharacter.Position, Color.White);
                    for(int i = 0; i<listOfCollectibles.Count; i++)
                    {
                        spriteBatch.Draw(listOfCollectibles[i].CurTexture, listOfCollectibles[i].Position, Color.White);
                    }
                    spriteBatch.DrawString(spriteFont, ("Level: " + String.Format("{0:0.00}", level)),
                        new Vector2(500, 50), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Time: " + String.Format("{0:0.00}", timer)),
                        new Vector2(500, 90), Color.Black);
                    break;
                case GameState.GameOver:
                    spriteBatch.DrawString(spriteFont, "Game Over", new Vector2(400, 400), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Level reached: " + String.Format("{0:0.00}", level)),
                        new Vector2(400, 460), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Score: " + String.Format("{0:0.00}", timer )),
                        new Vector2(400, 520), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Press something to return to menu", new Vector2(400, 580), Color.Black);
                    break;//Don't forget to put actual score once done with update method
                default:
                    break;
            }



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
