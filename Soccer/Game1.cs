using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;

namespace Soccer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //field
        Texture2D fieldBox;
        Texture2D net;

        //Real Madrid
        Texture2D ronaldo7;
        Texture2D bale;
        Texture2D ramos;
        Texture2D morata;
        Texture2D navas;

        //Barcelona
        Texture2D messi;
        Texture2D neymar;
        Texture2D pique;
        Texture2D suarez;
        Texture2D terSteg;

        //ball texture
        Texture2D ball;

        //objects
        private Field field;
        private Ball ourBall;
        private GoalKeeper navas1;
        private GoalKeeper terStegen;

        //threading set
        Thread navasMove;
        Thread terMove;        
     
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 550;
            graphics.PreferredBackBufferHeight = 350;
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
            //field texture set
            fieldBox = Content.Load<Texture2D>("Box");
            net = Content.Load<Texture2D>("net");
            //Real Madrid texture set 
            ronaldo7 = Content.Load<Texture2D>("Ronaldo");
            bale = Content.Load<Texture2D>("Bale");
            ramos = Content.Load<Texture2D>("Ramos");
            morata = Content.Load<Texture2D>("Morata");
            navas = Content.Load<Texture2D>("Navas");

            //Barcelona texture set
            messi = Content.Load<Texture2D>("Messi");
            suarez = Content.Load<Texture2D>("Suarez");
            neymar = Content.Load<Texture2D>("Neymar");
            pique = Content.Load<Texture2D>("Pique");
            terSteg = Content.Load<Texture2D>("TerStegen");

            //ball texture set
            ball = Content.Load<Texture2D>("Soccer_ball");

            //field object operations
            field = new Field();
            field.Box = fieldBox;
            field.Net = net;
            field.SetUp();

            //ball object operations
            ourBall = new Ball();
            ourBall.ballTexture = ball;

            //goalkeeper object operations

                //navas
            navas1 = new GoalKeeper();
            navas1.X1 = 50;
            navas1.Y1 = 150;
            navas1.rectGoalKeeper = new Rectangle(navas1.X1, navas1.Y1, Field.width, Field.height);
            navas1.goalKTex = navas;
                //terStegen
            terStegen = new GoalKeeper();
            terStegen.X1 = 450;
            terStegen.Y1 = 150;
            terStegen.rectGoalKeeper = new Rectangle(terStegen.X1, terStegen.Y1, Field.width, Field.height);
            terStegen.goalKTex = terSteg;

            //thread control 
            
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
            int catch1 = 0;
            int catch2 = 0;
            catch1 = terStegen.GoalKMove();
            catch2 = navas1.GoalKMove();
            int X1 = catch1 + terStegen.rectGoalKeeper.X;//rework this
            int X2 = catch2 + navas1.rectGoalKeeper.X;

            Rectangle set1 = new Rectangle(X1, terStegen.rectGoalKeeper.Y, Field.width, Field.height);
            Rectangle set2 = new Rectangle(X2, navas1.rectGoalKeeper.Y, Field.width, Field.height);

            terStegen.rectGoalKeeper = set1;
            navas1.rectGoalKeeper = set2;
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
            field.Draw(spriteBatch);
            ourBall.Draw(spriteBatch);
            terStegen.Draw(spriteBatch);
            navas1.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
