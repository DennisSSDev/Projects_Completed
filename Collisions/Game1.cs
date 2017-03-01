using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Collisions
{
    enum WalkingState
    {
        Left,
        Right,
        Up,
        Down,
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D nathan;
        Texture2D sony;
        WalkingState newState;
        KeyboardState keyboard;
        Rectangle positionForN = new Rectangle(100, 100, 100, 200);
        Rectangle positionForS;
        Vector2 newVector;
        Ship newChar;
        List<Rectangle> listOfRectangles;



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
            listOfRectangles = new List<Rectangle>();
            listOfRectangles.Add(new Rectangle(GraphicsDevice.Viewport.Width - 100, GraphicsDevice.Viewport.Height - 100, 100, 50));
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
            nathan = Content.Load<Texture2D>("Nathan");
            sony = Content.Load<Texture2D>("Sony");
            newChar = new Ship(nathan, positionForN, newVector);
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
            
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                newState = WalkingState.Left;
                Rectangle temp = new Rectangle();
                
                temp.X = newChar.ISpace.X;
                temp.Y = newChar.ISpace.Y;
                temp.Height = newChar.ISpace.Height;
                temp.Width = newChar.ISpace.Width;
                temp.X -= 1;
                temp.Y -= 1;
                newChar.ISpace = temp;

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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(newChar.Image,newChar.ISpace, Color.White);
            spriteBatch.Draw(sony, listOfRectangles[0], Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
