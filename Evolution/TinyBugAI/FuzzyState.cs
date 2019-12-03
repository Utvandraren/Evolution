using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.TinyBugAI
{
     class FuzzyState
     {
        protected float activationLevel;
        protected FuzzyContext context;
        public Bug _bug;


        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
        public virtual void Init() { activationLevel = 0.0f; }
        public virtual void CheckTransitions(int i) {  }
        public virtual float CalculateActivation()
        {
            return activationLevel;
        }

        public virtual void CheckLowerBound(float lbound = 0.0f)
        {
            if (activationLevel < lbound)
            {
                activationLevel = lbound;
            }
        }

        public virtual void CheckUpperBound(float uBound = 1.0f)
        {
            if (activationLevel > uBound)
            {
                activationLevel = uBound;
            }
        }

        public virtual void CheckBounds(float lb = 0.0f, float ub = 1.0f)
        {
            CheckLowerBound(lb);
            CheckUpperBound(ub);
        }


        public void SetContext(FuzzyContext context)
        {
            this.context = context;
        }



     }
}
