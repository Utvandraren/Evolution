using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Evolution.BoidBug
{
    class SteeringBehavior
    {
        public Vector2 steeringResult;

        public SteeringControl m_parent;
        public float m_weight;
        public float m_propability;
        public bool m_disable;
        public float m_lastForceMagApplied;


        public SteeringBehavior(SteeringControl parent = null)
        {
            m_parent = parent;
            m_disable = false;
            m_lastForceMagApplied = 0.0f;

        }

        public virtual bool Update(float dt,ref Vector2 totalForce)
        {
            return false;
        }

        public virtual void Reset()
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void SteerTowards(Vector2 target, ref Vector2 result)
        {
            Vector2 desired = target - m_parent.m_bug.pos;
            float targetDistance = desired.Length();
            if (targetDistance > 0)
            {
                desired = Vector2.Normalize(desired) * m_parent.m_bug.speed;
                result = desired - m_parent.m_bug.m_velocity;
            }
            else
            {
                result = Vector2.Zero;
            }
        }

        public virtual Vector2 SteerAway(Vector2 target)
        {
            Vector2 desired = m_parent.m_bug.pos - target;
            float targetDistance = desired.Length();

            if(targetDistance > 0)
            {
                desired = Vector2.Normalize(desired) * m_parent.m_bug.maxSpeed;
                return desired - m_parent.m_bug.m_velocity;
            }
            else
            {
                return Vector2.Zero;
            }
        }

        
    }
}
