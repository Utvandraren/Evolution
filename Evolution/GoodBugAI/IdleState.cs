using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Evolution.GoodBugAI;


namespace Evolution
{
    class IdleState : State
    {
        //Bug _bug;
        Random rnd;


        public IdleState(Bug bug)
        {
            _bug = bug;
            Init();
            Enter();
        }

        public override void CheckTransitions(int i)
        {
        }

        public override void Enter()
        {
           _bug.speed = rnd.Next(30, 60);
           _bug.direction.X = rnd.Next(-1, 1);
           _bug.direction.Y = rnd.Next(-1, 1);
        }

        public override void Exit()
        {
            this.context.TransitionTo(new IdleState(_bug));
        }

        public override void Init()
        {
            rnd = _bug.rnd;

        }

        public override void Update()
        {
            _bug.speed -= 0.8f;

            if (_bug.speed < 10.0f)
            {
                Enter();
            }
           
            if (Vector2.Distance(context.nearestEnemy, _bug.pos) < 200)
            {
                context.TransitionTo(new EvadeState(_bug, context.nearestEnemy));
            }
            else if ((context.nearestObjPos.Length() - _bug.pos.Length()) < 300)
            {
                context.TransitionTo(new MovingState(_bug, context.nearestObjPos));
            }
        }
    }
}
