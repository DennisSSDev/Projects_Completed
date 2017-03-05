using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
namespace WorkingHW2
{
    enum GameState//Main states of the game that determine if the player is in the menu, Gameplay or Or game over 
    {
        Menu,
        Game,
        GameOver
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;//SpriteFont for typing the characters while in menu and game over states

        /// <summary>
        /// Below this are all the attributes that are needed for creating the player and collectibles,
        /// Timer and Level counters,
        /// Random givers and etc,
        /// Basically all the under the hood counters and setters 
        /// </summary>

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
        /// <summary>
        /// NextLeel() allows the game to spawn the collectibles randomly with their textures set,
        /// reset the players position and reset the timer, all what you expect 
        /// when you clear a level and proceed to the next one
        /// </summary>
        public void NextLevel()
        {
            level++;
            timer = 10;//logic won't work, find out how to make this a working timer in RL
            adder = (int)Math.Round(level * 1.5);
            mainCharacter.LevelScore = 0;
            mainCharacter.X = GraphicsDevice.Viewport.Width / 2;
            mainCharacter.Y = GraphicsDevice.Viewport.Height / 2;
            listOfCollectibles.Clear();
            for (int i = 0; i < 4 + adder; i++)
            {
                listOfCollectibles.Add(new Collectible(giveRandom.Next(5, GraphicsDevice.Viewport.Width - 10),
                    giveRandom.Next(5, GraphicsDevice.Viewport.Height - 10),
                    20, 20));
                listOfCollectibles[i].CurTexture = collTex;
            }
        }
        /// <summary>
        /// ResetGame allows us to start the game from the beginning
        /// in case the player loses or the game breaks 
        /// </summary>
        public void ResetGame()
        {
            level = 0;
            mainCharacter.TotalScore = 0;
            NextLevel();
        }
        /// <summary>
        /// Screen Wrap keeps the player character
        /// within the playing bounds (from both X and Y axis)
        /// </summary>
        public void ScreenWrap()
        {
            if (mainCharacter.X > GraphicsDevice.Viewport.Width)//Might not work since checking for screen width
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
            else if (mainCharacter.Position.Y < -1)
            {
                mainCharacter.Y = GraphicsDevice.Viewport.Height;
            }
        }
        /// <summary>
        /// Determines what single key was pressed
        /// this method is used for starting the game and restarting after game over
        /// </summary>
        /// <param name="someKey">Takes a Key value to determine if it was pressed</param>
        /// <returns></returns>
        public bool SingleKeyPress(Keys someKey)//there has to be a key parameter
        {
            previousKbState = kbState;//might not be needed check during debug
            kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(someKey) && previousKbState.IsKeyUp(someKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method that I took from my Hackerman architecture 
        /// to ease the player controls
        /// Also WASD is used instead of the arrow keys
        /// </summary>
        public void PlayerControls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Vector2 revert = new Vector2(7, 7);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Vector2 revert = new Vector2(7, -7);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-15, -15);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-15, 15);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Vector2 revert = new Vector2(7, 0);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-15, 0);//A little of lore: initially the devs for sonic runners didn't have a stop or moe back button
                mainCharacter.X -= (int)revert.X;//Sonic was always running super fast forward, so why not make him super fast going to the right eh?
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Vector2 revert = new Vector2(0, -1 * 7);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Vector2 revert = new Vector2(0, 7);
                mainCharacter.X -= (int)revert.X;
                mainCharacter.Y -= (int)revert.Y;
            }
        }
        public Game1()//Constructor
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
            mainCharacter = new Player(10, 10, 50, 50);//Player initialized
            listOfCollectibles = new List<Collectible>();//List created for collectibles
            curState = GameState.Menu;//Game State automatically starts fromt the menu 
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
            mainCharacter.CurTexture = playerTex;//immidiately setting the main Character texture to the loaded texture
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
            switch (curState)//Switch that determines in what state is the game in
            {
                case GameState.Menu:
                    if (SingleKeyPress(Keys.Enter))//if you press the enter key, the game starts
                    {
                        curState = GameState.Game;
                        ResetGame();
                    }
                    break;
                case GameState.Game:
                    previousKbState = kbState;//might not be needed check during debug
                    kbState = Keyboard.GetState();
                    timer = timer - gameTime.ElapsedGameTime.TotalSeconds;//timer working 
                    PlayerControls();//call for the controls
                    ScreenWrap();//call for wrapping the player within the playing bounds 
                    for (int i = 0; i < listOfCollectibles.Count; i++)
                    {
                        if (listOfCollectibles[i].CheckCollision(mainCharacter))
                        {
                            listOfCollectibles[i].ActiveView = false;//Removes the collectible from visibility
                            mainCharacter.LevelScore++;
                            mainCharacter.TotalScore++;
                        }
                    }
                    if (timer <= 0)
                    {
                        curState = GameState.GameOver;//If the game time reaches 0 zero before items collected, you lose
                    }
                    if(mainCharacter.LevelScore == listOfCollectibles.Count)//condition for proceeding to the next level
                    {
                        NextLevel();
                    }
                    break;
                case GameState.GameOver:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        curState = GameState.Menu;
                    }
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
                case GameState.Menu://Draw the spriteFont
                    spriteBatch.DrawString(spriteFont, "Sanic Hearts", new Vector2(GraphicsDevice.Viewport.Width/2-50,
                        GraphicsDevice.Viewport.Height / 2-50), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Press Enter to Play", new Vector2(GraphicsDevice.Viewport.Width / 2-70,
                        GraphicsDevice.Viewport.Height / 2), Color.Black);
                    break;
                case GameState.Game:
                    spriteBatch.Draw(mainCharacter.CurTexture, mainCharacter.Position, Color.White);
                    for (int i = 0; i < listOfCollectibles.Count; i++)
                    {
                        listOfCollectibles[i].Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(spriteFont, ("Level: " + String.Format("{0:0.00}", level)),
                        new Vector2(650, 50), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Time: " + String.Format("{0:0.00}", timer)),
                        new Vector2(650, 90), Color.Black);
                    break;
                case GameState.GameOver:
                    spriteBatch.DrawString(spriteFont, "Game Over", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50,
                        GraphicsDevice.Viewport.Height / 2 - 50), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Level reached: " + String.Format("{0:0.00}", level)),
                        new Vector2(GraphicsDevice.Viewport.Width / 2 - 70, GraphicsDevice.Viewport.Height / 2), Color.Black);
                    spriteBatch.DrawString(spriteFont, ("Score: " + String.Format("{0:0.00}", mainCharacter.TotalScore)),
                        new Vector2(GraphicsDevice.Viewport.Width / 2 - 70,
                        GraphicsDevice.Viewport.Height / 2 + 30), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Press Enter to return to menu", new Vector2(GraphicsDevice.Viewport.Width / 2 - 110,
                        GraphicsDevice.Viewport.Height / 2+80), Color.Black);
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
