using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class GoodBug : Bug
    {
        Context context;


        public GoodBug(Rectangle drawRect, Texture2D texture, Vector2 pos, Random rnd) : base(drawRect, texture, pos, rnd)
        {
            context = new Context(new IdleState(this), this);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Rotation          
            frmMov = Vector2.Normalize(context.nearestObjPos - pos);
            if (frmMov.Y > 0)
            {
                rotation = (float)(Math.Acos(frmMov.X) + Math.PI / 2);
            }
            else
            {
                rotation = -(float)(Math.Acos(frmMov.X) - Math.PI / 2);

            }

            context.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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
