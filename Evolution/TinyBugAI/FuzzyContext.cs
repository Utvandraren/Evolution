using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.TinyBugAI
{
    class FuzzyContext
    {
        private List<FuzzyState> _state = new List<FuzzyState>();
        private List<FuzzyState> active_state = new List<FuzzyState>();
        private List<FuzzyState> notActive_state = new List<FuzzyState>();

        public Bug _bug;
        public Vector2 nearestObjPos = new Vector2(2000, 2000);
        public Vector2 nearestEnemy = new Vector2(2000, 2000);

        public FuzzyContext( Bug bug)
        {
            this._bug = bug;
        }

        public void AddState(FuzzyState state)
        {
            this._state.Add(state);
            state.SetContext(this);

        }

        public void Update()
        {
            active_state.Clear();

            foreach (FuzzyState state in _state)
            {
                if (state.CalculateActivation() > 0)
                {
                    active_state.Add(state);
                }
                else
                {
                    notActive_state.Add(state);
                }
            }

            if (notActive_state.Count() > 0)
            {
                foreach (FuzzyState state in notActive_state)
                {
                    state.Exit();
                }
            }

            if (active_state.Count() > 0)
            {
                foreach (FuzzyState state in active_state)
                {
                    state.Update();
                }
            }
            
        }

        public bool NothingHere()
        {
            if (!isCloseToFood() && !InDanger())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSafeToEat()
        {
            if (isCloseToFood() && !InDanger())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isCloseToFood()
        {
            return (Vector2.Distance(nearestObjPos, _bug.pos) < 300);
        }

        public bool InDanger()
        {
            return (Vector2.Distance(nearestEnemy, _bug.pos) < 200);
        }

    }
}
