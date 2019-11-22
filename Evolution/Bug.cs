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
        Context context;

        public Bug(Rectangle drawRect,Texture2D texture, Vector2 pos,Random rnd) : base(drawRect, texture, pos)
        {
            this.rnd = rnd;
            rotation = (float)(Math.Atan2(direction.Y, direction.X));
            context = new Context(new IdleState(this),this);
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Rotation          
            frmMov = Vector2.Normalize(context.nearestObjPos - pos);
            if (frmMov.Y > 0)
            {
                rotation = (float)(Math.Acos(frmMov.X) + Math.PI/2);
            }
            else
            {
                rotation = -(float)(Math.Acos(frmMov.X) - Math.PI/2);

            }

            context.Update();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, drawRect, Color.White, rotation, new Vector2(75, 50), 1.0f, SpriteEffects.None, 1f);
            //spriteBatch.Draw(texture, collRect, Color.Purple); //DebugColl

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
