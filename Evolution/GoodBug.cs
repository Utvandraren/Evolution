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
            //frmMov = Vector2.Normalize(context.nearestObjPos - pos);
            context.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void UpdatePerceptionData(List<GameObject> objList,List<GameObject> badBugList)
        {
            foreach (GameObject obj in objList)
            {
                if (Vector2.Distance(obj.pos, pos) < Vector2.Distance(context.nearestObjPos, pos))
                {
                    context.nearestObjPos = obj.pos;
                }
            }

            foreach (GameObject badBug in badBugList)
            {
                if (Vector2.Distance(badBug.pos, pos) < Vector2.Distance(context.nearestEnemy, pos))
                {
                    context.nearestEnemy = badBug.pos;
                }
            }
        }

        public void resetTarget()
        {
            context.nearestObjPos = new Vector2(2000, 1000);
        }
    }
}
