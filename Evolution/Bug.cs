using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class Bug : GameObject
    {
        protected Vector2 direction;
        protected float speed,rotation;
        protected Random rndSpeed;

        public Bug(Rectangle collRect,Rectangle drawRect,Texture2D texture, Vector2 pos,Random rnd) : base(drawRect, texture, pos)
        {
            rndSpeed = rnd;
            NewRandomMovement();
            rotation = (float)(Math.Atan2(direction.Y, direction.X));
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            speed -= 0.5f;

            if (speed <= 20.0f)
            {
                Vector2 oldDir = direction;
                NewRandomMovement();

                rotation += (float)(Math.Atan2(direction.Y, direction.X)/(2 * Math.PI));

                //float dot = Vector2.Dot(Vector2.Zero, direction);
                //rotation += (float)Math.Acos(dot / (oldDir.Length() * direction.Length()));  //Försök 2
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White, rotation, new Vector2(75, 50), 1.0f, SpriteEffects.None, 1f);
        }

        public void NewRandomMovement()
        {
            speed = rndSpeed.Next(50, 100);
            direction.X = rndSpeed.Next(-1, 1);
            direction.Y = rndSpeed.Next(-1, 1);            
        }

        public override void HandleCollision()
        {            

        }
    }
}
