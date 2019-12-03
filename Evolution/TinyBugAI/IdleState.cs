using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.TinyBugAI
{
    class IdleState : FuzzyState
    {
        //Bug _bug;
        Random rnd;
        Vector2 target;

        public IdleState(Bug bug)
        {
            _bug = bug;
            rnd = _bug.rnd;
            Init();
            Enter();
        }

        public override float CalculateActivation()
        {
            activationLevel = Vector2.Distance(context.nearestEnemy, _bug.pos) / 400;
            return activationLevel;
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
        }

        public override void Init()
        {
            target = new Vector2(rnd.Next(0, 1200), rnd.Next(0, 1000));
        }

        public override void Update()
        {
            if (_bug.speed < 10.0f)
            {
                Enter();
            }           
        }
    }
}
