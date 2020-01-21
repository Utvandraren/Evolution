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
        protected Rectangle collRect;
        protected Texture2D texture;
        public Vector2 pos;
        public Vector2 m_velocity;
        public int m_Size;


        public GameObject(Rectangle drawRect,Texture2D texture,Vector2 pos)
        {
            this.drawRect = drawRect;
            this.texture = texture;
            this.pos = pos;
            collRect = drawRect;
        }

        public virtual void Update(GameTime gameTime)
        {
            collRect.X = (int)pos.X-drawRect.Width/8;
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
