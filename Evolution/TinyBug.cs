using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Evolution.TinyBugAI;


namespace Evolution
{
    class TinyBug : Bug
    {
        FuzzyContext context;

        public TinyBug(Rectangle drawRect,Texture2D texture, Vector2 pos,Random rnd) : base(drawRect, texture, pos, rnd)
        {
            collRect = new Rectangle((int)pos.X, (int)pos.Y , drawRect.Width, drawRect.Height );

            context = new FuzzyContext(this);
            context.AddState(new TinyBugAI.IdleState(this));
            context.AddState(new Moving(this));
            context.AddState(new Evade(this));

        }

        public override void Update(GameTime gameTime)
        {
            if (speed > 0)
            {
                speed -= 0.8f;
            }

            if (pos.X < -20) //Debug
            {
                System.Diagnostics.Debug.WriteLine(Direction);

            }

            base.Update(gameTime);
            context.Update();

        }

        public void UpdatePerceptionData(List<GameObject> objList, List<GameObject> badBugList)
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
