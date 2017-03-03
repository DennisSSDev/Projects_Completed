using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
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
        Rectangle positionForN = new Rectangle(100, 100, 50, 100);
        Ship newChar;
        List<Rectangle> listOfRectangles;
        Random newObj = new Random();
        int t = 1;


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
            for(int i = 0; i <5 ; i++)
            {
                listOfRectangles.Add(new Rectangle(newObj.Next(50, 500), newObj.Next(50, 50), 100, 70));
            }
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
            newChar = new Ship(nathan, positionForN, new Vector2(0f, 0f));
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
                temp = newChar.ISpace;
                temp.X -= 5;
                newChar.ISpace = temp;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                newState = WalkingState.Right;
                Rectangle temp = new Rectangle();
                temp = newChar.ISpace;
                temp.X += 10;
                newChar.ISpace = temp;
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                newState = WalkingState.Up;
                Rectangle temp = new Rectangle();
                temp = newChar.ISpace;
                temp.Y -= 10;
                newChar.ISpace = temp;
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                newState = WalkingState.Down;
                Rectangle temp = new Rectangle();
                temp = newChar.ISpace;
                temp.Y += 10;
                newChar.ISpace = temp;
            }
            
            for (int i = 0; i < listOfRectangles.Count; i++)
            {
                for (int a = listOfRectangles.Count-1; a >= 0; a--)
                {
                    if(i == a)
                    {
                        continue;
                    }
                    else if (listOfRectangles[i].Intersects(listOfRectangles[a]))
                    {
                        Rectangle temp = listOfRectangles[i];
                        temp.Y = newObj.Next(newObj.Next(50,500));
                        temp.X = newObj.Next(newObj.Next(50, 500));
                        listOfRectangles[i] = temp;
                    }
                }
            }
            for (int i = 0; i < listOfRectangles.Count; i++)
            {
                Rectangle temp = listOfRectangles[i];
                temp.X -= t;

                if (GraphicsDevice.Viewport.Bounds.Left == listOfRectangles[i].X)
                {
                    t = -1;
                }
                else if(GraphicsDevice.Viewport.Bounds.Right == listOfRectangles[i].X)
                {
                    t = 1;
                }
                listOfRectangles[i] = temp;
            }

            if (GraphicsDevice.Viewport.Bounds.Left == newChar.ISpace.X + 20)
            {
                Rectangle temp = newChar.ISpace;

                temp.Offset(795f, 0);

                newChar.ISpace = temp;
            }
            if (GraphicsDevice.Viewport.Bounds.Right < newChar.ISpace.X)
            {
                Rectangle temp = newChar.ISpace;

                temp.Offset(-795f, 0);

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

            for (int a = 0; a < listOfRectangles.Count; a++)
            {
                if (newChar.ISpace.Intersects(listOfRectangles[a]))
                {
                    spriteBatch.Draw(newChar.Image, newChar.ISpace, Color.Red);
                }
            }
            for (int i = 0; i < listOfRectangles.Count; i++)
            {
                spriteBatch.Draw(sony, listOfRectangles[i], Color.White);

            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
