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
            //activationLevel = (Vector2.Distance(context.nearestEnemy, _bug.pos) / approachDist) + approachDist / Vector2.Distance(context.nearestObjPos, _bug.pos);
            activationLevel = approachDist / Vector2.Distance(context.nearestObjPos, _bug.pos);
            //activationLevel = 1.0f - ( Vector2.Distance(context.nearestObjPos, _bug.pos) / approachDist);

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
            rnd = _bug.rnd;
            approachDist = 1000;
        }

        public override void Update()
        {
            if (context != null)
            {
                target = context.nearestObjPos;
            }

            _bug.Direction += Vector2.Normalize(target - _bug.pos) * activationLevel;

        }
    }
}
