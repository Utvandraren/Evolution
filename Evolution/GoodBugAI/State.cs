using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    abstract class State
    {
        protected Context context;
        public Bug _bug;

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void Init();
        public abstract void CheckTransitions(int i);

        public void SetContext(Context context)
        {
            this.context = context;
        }


    }
}
