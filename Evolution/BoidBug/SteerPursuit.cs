using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.BoidBug
{
    class SteerPursuit : SteerApproach
    {
        public SteerPursuit(SteeringControl parent = null) : base(parent)
        {

        }

        public override bool Findtarget()
        {
            bool retval = false;

            //if the guy you are pursuing is essentially in your path then just approach

            SteeringControl parent = m_parent;
            GameObject objPursure = m_parent.m_bug.GetClosestGameObj();

            if(objPursure != null)
            {
                Boig bug = m_parent.m_bug;

                //if the other guy is “to my front” and
                //we’re moving towards each other...

                float dotVelocity = Vector2.Dot(bug.m_velocity, objPursure.m_velocity);
                Vector2 deltaPos = objPursure.pos - bug.pos;
                Vector2 targetPos = objPursure.pos;

                if(Vector2.Dot(deltaPos, bug.m_velocity) < 0 || dotVelocity > -0.93)
                {
                    Vector2 bugVel = bug.m_velocity;
                    bugVel = Vector2.Normalize(bugVel) * bug.maxSpeed;
                    float combinedSpeed = (bugVel + objPursure.m_velocity).Length();
                    float predictiontime = deltaPos.Length() / combinedSpeed;
                    targetPos = objPursure.pos + (objPursure.m_velocity * predictiontime);
                }

                m_currentTarget = targetPos;
                retval = true;              
            }

            return retval;
        }
    }
}
