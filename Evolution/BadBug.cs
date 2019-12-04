using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Evolution.BadBugAI;

namespace Evolution
{
    class BadBug : Bug
    {
        Node rootNode,idleNode,attackNode;
        public Vector2 nearestGoodBug;

        public BadBug(Rectangle drawRect, Texture2D texture, Vector2 pos, Random rnd) : base(drawRect, texture, pos, rnd)
        {
            collRect = new Rectangle((int)pos.X - drawRect.Width / 2, (int)pos.Y , drawRect.Width / 4, drawRect.Height / 4);

            rootNode = new Node(1, this);
            idleNode = new IdleNode(2, this);
            attackNode = new AttackNode(3, this);
            rootNode.AddTrueNode(attackNode);
            rootNode.AddFalseNode(idleNode);
            idleNode.AddTrueNode(attackNode);
            attackNode.AddTrueNode(idleNode);

            nearestGoodBug = new Vector2(2000, 2000);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            rootNode.Eval();

            speed -= 0.8f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void UpdatePerceptionData(List<GameObject> objList)
        {
            foreach (GameObject bug in objList)
            {
                if (Vector2.Distance(bug.pos, pos) < Vector2.Distance(nearestGoodBug, pos))
                {
                    nearestGoodBug = bug.pos;
                }
            }
        }

        public void resetTarget()
        {
            nearestGoodBug = new Vector2(2000, 2000);
        }

    }
}
