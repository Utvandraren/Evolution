using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if ((context.nearestObjPos.Length() - _bug.pos.Length()) < 200)
            {
                context.TransitionTo(new MovingState(_bug,context.nearestObjPos));
            }
        }
    }
}
