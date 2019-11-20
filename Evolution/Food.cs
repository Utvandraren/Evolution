using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class Food : GameObject
    {

        public Food( Rectangle drawRect, Texture2D texture, Vector2 pos) : base(drawRect, texture, pos)
        {
            collRect = drawRect;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void HandleCollision()
        {
            base.HandleCollision();
        }
    }
}
