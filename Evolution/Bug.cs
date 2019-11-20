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
        public Vector2 direction;
        public float speed,rotation;
        public Random rnd;
        Context context;

        public Bug(Rectangle collRect,Rectangle drawRect,Texture2D texture, Vector2 pos,Random rnd) : base(drawRect, texture, pos)
        {
            //collRect = new Rectangle((int)pos.X, (int)pos.Y, (int)drawRect.Width , (int)drawRect.Height );

            this.rnd = rnd;
            rotation = (float)(Math.Atan2(direction.Y, direction.X));
            context = new Context(new IdleState(this),this);
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            context.Update();

            
                //rotation += (float)(Math.Atan2(direction.Y, direction.X) / (2 * Math.PI));

                //Vector2 oldDir = direction;
                //float dot = Vector2.Dot(Vector2.Zero, direction);
                //rotation += (float)Math.Acos(dot / (oldDir.Length() * direction.Length()));  //Försök 2
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White, rotation, new Vector2(75, 50), 1.0f, SpriteEffects.None, 1f);
            spriteBatch.Draw(texture, pos, collRect, Color.Purple, rotation, new Vector2(75, 50), 1.0f, SpriteEffects.None, 1f);
            //spriteBatch.Draw(texture, pos, collRect, Color.Purple);

        }

        public void NewRandomMovement()
        {
            speed = rnd.Next(30, 60);
            direction.X = rnd.Next(-1, 1);
            direction.Y = rnd.Next(-1, 1);            
        }

        public override void HandleCollision()
        {            
            
        }

        public void UpdatePerceptionData(List<GameObject> objList)
        {
            foreach (GameObject obj in objList)
            {
                if (Vector2.Distance(obj.pos, pos) < Vector2.Distance(context.nearestObjPos, pos))
                {
                    context.nearestObjPos = obj.pos;
                }
            }
        }

        public void resetTarget()
        {
            context.nearestObjPos = new Vector2(2000, 1000);
        }
    }
}
