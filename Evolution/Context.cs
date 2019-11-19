using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution
{
    class Context
    {   
        private State _state = null;
        public Bug _bug;
        public Vector2 nearestObjPos = new Vector2(1000,1000);

        public Context(State state,Bug bug)
        {
            this.TransitionTo(state);
            this._bug = bug;
        }

        public void TransitionTo(State state)
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
