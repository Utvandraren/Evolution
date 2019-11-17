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
        protected Vector2 pos;
        protected Rectangle collRect;


        public GameObject(Rectangle drawRect,Texture2D texture,Vector2 pos)
        {
            this.drawRect = drawRect;
            collRect = drawRect;
            this.texture = texture;
            this.pos = pos;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White);
        }

        public virtual bool IsColliding(Rectangle otherCollRect)
        {
            if (collRect.Intersects(otherCollRect))
            {
                return true;
            }
            return false;
        }

        public virtual void HandleCollision()
        {

        }
    }
}
