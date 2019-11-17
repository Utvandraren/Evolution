using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evolution
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bug bug;
        Texture2D bugText;
        List<GameObject> gameList;
        int nmbrBugs,nmbrBadBugs;
        Random rnd;

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
            nmbrBugs = 30;


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bugText = Content.Load<Texture2D>("bug");
            rnd = new Random();
            gameList = new List<GameObject>();
            bug = new Bug(new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, 100, 100), bugText, new Vector2(50, 50),rnd);
            for (int i = 0; i < nmbrBugs; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                gameList.Add(new Bug(new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, 100, 100), bugText, new Vector2(X, Y),rnd));

            }

            //for (int i = 0; i < nmbrBadBugs; i++)
            //{
            //    gameList.Add(new Bug(new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, 100, 100), bugText, new Vector2(50, 50)));

            //}

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();
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

            foreach (GameObject obj in gameList) //all objects
            {
                obj.Update(gameTime);
            }
            bug.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);
            spriteBatch.Begin();

            foreach (GameObject obj in gameList)  //all objects
            {
                obj.Draw(spriteBatch);
            }
            bug.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
