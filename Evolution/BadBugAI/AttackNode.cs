using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.BadBugAI
{
    class AttackNode : Node
    {
        Random rnd;
        Vector2 attackTarget;

        public AttackNode(int newId, BadBug newBug) : base(newId, newBug)
        {
            rnd = bug.rnd;
            attackTarget = bug.nearestGoodBug;
        }

        public override void Action()
        {
            bug.speed = rnd.Next(70, 90);
            bug.direction = Vector2.Normalize(bug.nearestGoodBug - bug.pos);
            bug.resetTarget();
           
        }

        public override bool Condition()
        {
            return (Vector2.Distance(bug.nearestGoodBug, bug.pos)) < 200;

        }
    }
}
