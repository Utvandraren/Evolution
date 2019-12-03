using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.TinyBugAI
{
    class Moving : FuzzyState
    {
        //Bug _bug;
        Random rnd;
        Vector2 target;
        float approachDist;

        public Moving(Bug bug)
        {
            _bug = bug;
            Init();
            Enter();
        }

        public override float CalculateActivation()
        {
            activationLevel = approachDist / Vector2.Distance(context.nearestObjPos, _bug.pos);
            return activationLevel;
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

        }

        public override void Init()
        {
            rnd = _bug.rnd;

        }

        public override void Update()
        {

            if (_bug.speed <= 30.0f)
            {
                Enter();
            }

            

        }
    }
}
