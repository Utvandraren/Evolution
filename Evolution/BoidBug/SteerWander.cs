using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.BoidBug
{
    class SteerWander : SteeringBehavior
    {
        Random rnd;
        float m_thetaValue;
        Vector2 m_circlePosition;
        float m_wanderCircleDistance;
        float m_wanderCircleRadius;


        public SteerWander(SteeringControl parent = null) : base(parent)
        {
            rnd = new Random();
        }

        public override bool Update(float dt, ref Vector2 totalForce)
        {
            bool adjustment = false;

            SteeringControl parent = m_parent;
            Boig bug = m_parent.m_bug;
            Vector2 steeringForce = Vector2.Zero;

            float delta = 0.15f;

            m_thetaValue += (rnd.Next() * 2 * delta) - delta;

            m_circlePosition = bug.m_velocity;
            m_circlePosition.Normalize();
            m_circlePosition *= m_wanderCircleDistance;
            m_circlePosition += bug.pos;
            Vector2 circleTarget = new Vector2(m_wanderCircleRadius * (float)Math.Cos(m_thetaValue), m_wanderCircleRadius * (float)Math.Sin(m_thetaValue));
            Vector2 target = m_circlePosition + circleTarget;
            SteerTowards(target,ref steeringForce);

            float distanceToObject = steeringForce.Length();
            if(distanceToObject != null)
            {
                totalForce += steeringForce + parent.m_bug.m_velocity;
                adjustment = true;
                //m_targetPosition = target;
            }

            return adjustment;
            
        }
    }
}
