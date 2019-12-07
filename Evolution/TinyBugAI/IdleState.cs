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
        float activationTreshold;

        public IdleState(Bug bug)
        {
            _bug = bug;
            rnd = _bug.rnd;
            Init();
            Enter();
        }

        public override float CalculateActivation()
        {
            activationLevel =  (Vector2.Distance(context.nearestEnemy, _bug.pos) / activationTreshold) + (Vector2.Distance(context.nearestObjPos, _bug.pos) / activationTreshold);
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
            NewTarget();
            activationTreshold = 10000;
        }

        public override void Update()
        {
            NewTarget();
            //_bug.Direction += new Vector2(rnd.Next(-1, 1), rnd.Next(-1, 1)) * activationLevel;
            _bug.Direction += Vector2.Normalize(target - _bug.pos) * activationLevel;

        }

        public void NewTarget()
        {
            target = new Vector2(rnd.Next(0, 1200), rnd.Next(0, 800));
        }
    }
}
