using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class GameObject
    {
        protected Rectangle drawRect;
        protected Texture2D texture;
        public Vector2 pos;
        protected Rectangle collRect;


        public GameObject(Rectangle drawRect,Texture2D texture,Vector2 pos)
        {
            this.drawRect = drawRect;
            collRect = new Rectangle((int)drawRect.X + (int)drawRect.X / 2, (int)drawRect.Y + (int)drawRect.Y / 2, (int)drawRect.Width / 2, (int)drawRect.Height / 2);
            this.texture = texture;
            this.pos = pos;
        }

        public virtual void Update(GameTime gameTime)
        {
            collRect.X = (int)pos.X;
            collRect.Y = (int)pos.Y;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White);
        }

        public virtual bool IsColliding(GameObject obj)
        {           
            return collRect.Intersects(obj.collRect);
        }

        public virtual void HandleCollision()
        {

        }
    }
}
