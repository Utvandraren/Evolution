using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.TinyBugAI
{
    abstract class FuzzyState
    {
        protected FuzzyContext context;
        public Bug _bug;

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void Init();
        public abstract void CheckTransitions(int i);

        public void SetContext(FuzzyContext context)
        {
            this.context = context;
        }


    }
}
