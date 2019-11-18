using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    class AttackState : State
    {
        Bug _bug;

        public AttackState(Bug bug)
        {

        }

        public override void CheckTransitions(int i)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            this.context.TransitionTo(new IdleState(_bug));

        }

        public override void Init()
        {
        }

        public override void Update()
        {
        }
    }
}
