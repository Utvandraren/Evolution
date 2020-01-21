using Evolution.BoidBug;
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
        Texture2D bugText,foodText,badBugText,TinyBugText;
        List<GameObject> bugList, badBugList, staticObjList, tinyBugList;
        List<Boig> boigList;
        int nmbrBugs,nmbrBadBugs,nmbrFoods,nmbrTinyBugs,nmbrBoigs;
        Random rnd;
        List<SteeringControl> strCtrlrs;


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
            nmbrBugs = 0;
            nmbrBadBugs = 0;
            nmbrTinyBugs = 0;
            nmbrFoods = 0;
            nmbrBoigs = 120;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bugText = Content.Load<Texture2D>("bug");
            badBugText = Content.Load<Texture2D>("badbug");
            TinyBugText = Content.Load<Texture2D>("tinybug");
            foodText = Content.Load<Texture2D>("Food");
            rnd = new Random();
            bugList = new List<GameObject>();
            badBugList = new List<GameObject>();
            staticObjList = new List<GameObject>();
            tinyBugList = new List<GameObject>();
            boigList = new List<Boig>();
            strCtrlrs = new List<SteeringControl>();

            for (int i = 0; i < nmbrBoigs; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                boigList.Add(new Boig(new Rectangle(0, 0, 20, 19), foodText, new Vector2(X, Y), rnd,boigList));
                //strCtrlrs.Add(new SteeringControl(boigList[i]));
            }

            for (int i = 0; i < nmbrFoods; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                staticObjList.Add(new Food(new Rectangle(0, 0, 20, 19), foodText, new Vector2(X, Y)));
            }

            for (int i = 0; i < nmbrBugs; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                bugList.Add(new GoodBug(new Rectangle(0, 0, bugText.Width, bugText.Height), bugText, new Vector2(X, Y), rnd));
            }

            for (int i = 0; i < nmbrBadBugs; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                badBugList.Add(new BadBug(new Rectangle(0, 0, badBugText.Width, badBugText.Height), badBugText, new Vector2(X, Y), rnd));
            }

            for (int i = 0; i < nmbrTinyBugs; i++)
            {
                int X = rnd.Next(1100);
                int Y = rnd.Next(700);
                tinyBugList.Add(new TinyBug(new Rectangle(0, 0, TinyBugText.Width, TinyBugText.Height), TinyBugText, new Vector2(X, Y), rnd));
            }

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

            //foreach (SteeringControl ctrls in strCtrlrs)
            //{
            //    ctrls.Update(gameTime.ElapsedGameTime.Seconds);
            //}

            foreach (Boig boig in boigList)
            {
                boig.Update(gameTime);
            }


            foreach (GoodBug bug in bugList) 
            {
                bug.Update(gameTime);
                bug.UpdatePerceptionData(staticObjList,badBugList);              
            }

            foreach (BadBug badBug in badBugList)
            {
                badBug.Update(gameTime);
                badBug.UpdatePerceptionData(bugList,tinyBugList);
            }

            foreach (TinyBug tiny in tinyBugList)
            {
                tiny.Update(gameTime);
                tiny.UpdatePerceptionData(staticObjList, badBugList);
            }

            foreach (BadBug badBug in badBugList)
            {
                foreach (GoodBug bug in bugList)
                {
                    if (badBug.IsColliding(bug))
                    {
                        bugList.Remove(bug);
                        badBug.resetTarget();
                        break;
                    }
                }

                foreach (TinyBug tiny in tinyBugList)
                {
                    if (badBug.IsColliding(tiny))
                    {
                        tinyBugList.Remove(tiny);
                        badBug.resetTarget();
                        break;
                    }
                }
            }

            foreach (GoodBug obj in bugList) 
            {
                foreach (Food food in staticObjList)
                {
                    if (food.IsColliding(obj))
                    {
                        staticObjList.Remove(food);
                        obj.resetTarget();
                        break;
                    }
                }
            }

            foreach (TinyBug tiny in tinyBugList)
            {
                foreach (Food food in staticObjList)
                {
                    if (food.IsColliding(tiny))
                    {
                        staticObjList.Remove(food);
                        tiny.resetTarget();
                        break;
                    }
                }
            }

            foreach (GameObject food in staticObjList) 
            {
                food.Update(gameTime);
            }
            
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

            foreach (Boig boig in boigList)
            {
                boig.Draw(spriteBatch);
            }

            foreach (GameObject obj in bugList)  
            {
                obj.Draw(spriteBatch);
            }
            foreach (Food food in staticObjList)
            {
                food.Draw(spriteBatch);
            }

            foreach (BadBug bug in badBugList)
            {
                bug.Draw(spriteBatch);
            }

            foreach (TinyBug tiny in tinyBugList)
            {
                tiny.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
