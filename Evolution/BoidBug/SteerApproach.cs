using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Evolution.BoidBug
{
    class SteerApproach : SteeringBehavior
    {
        public Vector2 m_currentTarget;

        public SteerApproach(SteeringControl parent = null) : base(parent)
        {

        }

        public override bool Update(float dt,ref Vector2 totalForce)   
        {
            bool adjustment = false;
            bool found = Findtarget();

            if (found)
            {
                
                Vector2 steeringForce = Vector2.Zero;
                SteerTowards(m_currentTarget,ref steeringForce);
                totalForce += steeringForce;

                adjustment = true;
            }

            return adjustment;
        }

        virtual public bool Findtarget()
        {
            bool retVal = false;

            //SteeringControl parent = m_parent;

            GameObject objToApproach = m_parent.m_bug.GetClosestGameObj();


            if (objToApproach != null)
            {
                m_currentTarget = objToApproach.pos;
                retVal = true;
            }

            return retVal;
        }
    }
}
