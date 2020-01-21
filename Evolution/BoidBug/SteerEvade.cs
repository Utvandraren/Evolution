using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Evolution.BoidBug
{
    class SteerEvade : SteerPursuit
    {
        bool m_evadedLastUpdate = false;
        float EV_SPEED_BUFFER = 100;

        public SteerEvade(SteeringControl parent = null) : base(parent)
        {

        }

        public override bool Update(float dt, ref Vector2 totalForce)            //TODO fixa till att boigerna undviker andra boiger
        {
            bool adjustment = false;

            //Move away from the nearest objekt that your interested in
            SteeringControl parent = m_parent;
            GameObject objToEvade = parent.m_bug.GetClosestGameObj();
            Boig bug = parent.m_bug;

            if(objToEvade != null)
            {
                //ensure minimum distance
                float minDist;
                if (m_evadedLastUpdate)
                {
                    minDist = 40.0f;
                }
                else
                {
                    minDist = 20.0f;
                }

                float speed = bug.m_velocity.Length();
                float spdAdj = MathHelper.Lerp(speed / bug.maxSpeed, 0.0f, EV_SPEED_BUFFER);
                float adjSafetyRadius = minDist + spdAdj + objToEvade.m_Size;

                Vector2 steeringForce;
                steeringForce = Vector2.Zero;

                Vector2 deltaPos = objToEvade.pos - bug.pos;

                //is the nearest too close?
                if(deltaPos.Length() < adjSafetyRadius)
                {
                    float dotVelocity = Vector2.Dot(bug.m_velocity, objToEvade.m_velocity);

                    //if the other guy is "to my front and were moving towards each other"
                    Vector2 targetPos = objToEvade.pos;
                    if(Vector2.Dot(deltaPos,bug.m_velocity) < 0 || dotVelocity > -0.93)
                    {
                        Vector2 bugVel = bug.m_velocity;
                        bugVel.Normalize();
                        bugVel *= bug.speed;
                        float combinedSpeed = (bugVel + objToEvade.m_velocity).Length();
                        float predictionTime = deltaPos.Length() / combinedSpeed;
                        targetPos = objToEvade.pos + (objToEvade.m_velocity * predictionTime);
                        deltaPos = targetPos - bug.pos;
                    }

                    //opposite of pursuit
                    SteerAway(targetPos);
                    totalForce += steeringForce;
                    adjustment = true;
                }
            }

            m_evadedLastUpdate = adjustment;
            return adjustment;

        }
    }
}
