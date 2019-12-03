using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Evolution.TinyBugAI;


namespace Evolution.TinyBugAI
{
    class Evade : FuzzyState
    {
        Random rnd;
        Vector2 target;
        float approachDist;

        public Evade(Bug bug) : base()
        {
            _bug = bug;
            rnd = _bug.rnd;
            Init();
            Enter();

        }

        public override float CalculateActivation()
        {
            activationLevel = approachDist / Vector2.Distance(context.nearestEnemy, _bug.pos);
            return activationLevel;
        }

        public override void CheckTransitions(int i)
        {
            throw new NotImplementedException();
        }

        public override void Enter()
        {
            if (context != null)
            {
                target = context.nearestObjPos;
            }

            _bug.speed = rnd.Next(120, 140);
            _bug.direction = -Vector2.Normalize(target - _bug.pos);
        }

        public override void Exit()
        {
        }

        public override void Init()
        {

        }

        public override void Update()
        {
            _bug.speed -= 0.5f;

            if (_bug.speed <= 40.0f)
            {
                Enter();
            }

            if (Vector2.Distance(context.nearestEnemy, _bug.pos) > 300)
            {
                Exit();
            }
        }
    }
}
