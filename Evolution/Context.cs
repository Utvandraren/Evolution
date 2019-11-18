using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    class Context
    {
        private State _state = null;
        Bug _bug;

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

        public void Move()
        {
            TransitionTo(new MovingState(_bug));
        }
    }
}
