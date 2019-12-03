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
        private FuzzyState _state = null;
        public Bug _bug;
        public Vector2 nearestObjPos = new Vector2(2000, 2000);
        public Vector2 nearestEnemy = new Vector2(2000, 2000);

        public FuzzyContext(FuzzyState state, Bug bug)
        {
            this.TransitionTo(state);
            this._bug = bug;
        }

        public void TransitionTo(FuzzyState state)
        {
            this._state = state;
            this._state.SetContext(this);
        }

        public void Update()
        {
            _state.Update();
        }


    }
}
