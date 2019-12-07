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
        public Vector2 direction,frmMov;
        public float speed,rotation;
        public Random rnd;

        public Bug(Rectangle drawRect,Texture2D texture, Vector2 pos,Random rnd) : base(drawRect, texture, pos)
        {
            this.rnd = rnd;
            rotation = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
            frmMov = direction;
            if (frmMov.Y > 0)
            {
                rotation = (float)(Math.Acos(frmMov.X) + Math.PI / 2);
            }
            else
            {
                rotation = -(float)(Math.Acos(frmMov.X) - Math.PI / 2);
            }

            //Flyttar in insekterna in i fönstret om de börjar röra sig utanför
            if (pos.X > 1200)
            {
                pos.X -= 1200;
            }
            else if(pos.X < 0)
            {
                pos.X = 1200;
            }
            if (pos.Y > 800)
            {
                pos.Y -= 800;
            }
            else if (pos.Y < 0)
            {
                pos.Y = 800;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White, rotation, new Vector2(drawRect.Width/2, drawRect.Height / 2), 1.0f, SpriteEffects.None, 1f);
            //spriteBatch.Draw(texture, collRect, Color.Purple); //DebugColl

        }

        public override void HandleCollision()
        {            
            
        }

        public Vector2 Direction
        {
            get { return direction; }

            set
            {
                direction = value;

                if (direction.X > 1)
                {
                    direction.X = 1;
                }
                if (direction.X < 0)
                {
                    direction.X = 0;
                }
                if (direction.Y > 1)
                {
                    direction.Y = 1;
                }
                if (direction.Y < 0)
                {
                    direction.Y = 0;
                }
            }
        }

        public virtual void resetTarget()
        {
        }

    }
}
