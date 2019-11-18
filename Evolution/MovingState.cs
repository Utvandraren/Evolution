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
        Bug _bug;
        Random rnd;

        public MovingState(Bug bug)
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
            _bug.speed = rnd.Next(50, 100);
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
            _bug.speed -= 0.5f;

            if (_bug.speed <= 20.0f)
            {
                Enter();
            }
        }
    }
}
