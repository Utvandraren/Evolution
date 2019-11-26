using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.BadBugAI
{
    class IdleNode:Node
    {
        Random rnd;

        public IdleNode(int newId, BadBug newBug) : base(newId, newBug)
        {
            rnd = bug.rnd;
        }

        public override void Action()
        {
            bug.speed = rnd.Next(30, 60);
            bug.direction.X = rnd.Next(-1, 1);
            bug.direction.Y = rnd.Next(-1, 1);
        }

        public override bool Condition()
        {
            return bug.speed < 10.0f; 
        }
    }
}
