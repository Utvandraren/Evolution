using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class MovingState : State
    {
        //Bug _bug;
        Random rnd;
        Vector2 target;

        public MovingState(Bug bug,Vector2 target)
        {
            this.target = target;
            _bug = bug;
            Init();
            Enter();
        }

        public override void CheckTransitions(int i)
        {
            
        }

        public override void Enter()
        {
            if (context != null)
            {
                target = context.nearestObjPos;
            }
            _bug.speed = rnd.Next(80, 100);
            _bug.direction = Vector2.Normalize(target - _bug.pos);
        }

        public override void Exit()
        {
            context.TransitionTo(new IdleState(_bug));
        }

        public override void Init()
        {
            rnd = _bug.rnd;
            
        }

        public override void Update()
        {
            _bug.speed -= 0.5f;

            if (_bug.speed <= 40.0f)
            {
                Enter();
            }

            if ((context.nearestObjPos.Length() - _bug.pos.Length()) > 300)
            {
                context.TransitionTo(new IdleState(_bug));
            }
        }
    }
}
