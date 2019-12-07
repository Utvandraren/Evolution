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
        float safetyRadius;

        public Evade(Bug bug) : base()
        {
            _bug = bug;
            rnd = _bug.rnd;
            Init();
            Enter();
        }

        public override float CalculateActivation()
        {
            activationLevel = 1.0f - (safetyRadius / Vector2.Distance(context.nearestEnemy, _bug.pos) );
            CheckBounds();
            return activationLevel;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Init()
        {
            safetyRadius = 50;
        }

        public override void Update()
        {
            if (context != null)
            {
                target = context.nearestObjPos;
            }
            _bug.Direction += -Vector2.Normalize(target - _bug.pos) * activationLevel;

        }
    }
}
