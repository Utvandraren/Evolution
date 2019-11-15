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

        public Bug(Rectangle collRect,Rectangle drawRect,Texture2D texture, Vector2 pos) : base(collRect, drawRect, texture, pos)
        {
            speed = 10.0f;
            //direction = new Vector2(1, 0);
            rotation = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //rotation += 0.02f;
            //drawRect.X = (int)(pos.X);
            //drawRect.Y = (int)(pos.Y);
            //collRect.X = (int)(pos.X);
            //collRect.Y = (int)(pos.Y);


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White, rotation, new Vector2(75, 50), 1.0f, SpriteEffects.None, 1f);
        }


    }
}
