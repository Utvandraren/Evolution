using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Evolution.BoidBug
{
    class SteerArrive : SteerPursuit
    {
        public SteerArrive(SteeringControl parent = null) : base(parent)
        {

        }

        public override bool Update(float dt, ref Vector2 totalForce)
        {
            bool adjustment = false;
            bool found = Findtarget();

            if (found)
            {
                Vector2 targetDelta = m_currentTarget - m_parent.m_bug.pos;
                float distTarget = targetDelta.Length();

                if(distTarget > 0)
                {
                    //debugging info...Shows the targetting x on the arrivve target
                    m_parent.m_bug.nearestBoig.pos = m_currentTarget;//kan bli problem här..   läg till en ´target vector som controllerklassen använder?
                    float speed = m_parent.m_bug.maxSpeed * (distTarget / 80);   //AI_MAX_SPEED_TRY
                    speed = MathHelper.Min(speed, m_parent.m_bug.maxSpeed);
                    targetDelta.Normalize();
                    targetDelta *= speed;
                    totalForce += targetDelta - m_parent.m_bug.m_velocity;
                    adjustment = true;
                }
            }

            return adjustment;
        }
    }
}
