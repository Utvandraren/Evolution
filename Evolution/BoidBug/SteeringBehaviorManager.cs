using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Evolution.BoidBug
{
    class SteeringBehaviorManager
    {
        List<SteeringBehavior> m_behaviors;
        List<SteeringBehavior> m_active;
        List<float> m_activeForce;
        int m_numBehaviors;
        SteeringControl m_parent;
        Vector2 m_totalSteeringForce;
        public Vector2 m_maxSteeringForceVector = new Vector2(1,1);
        float m_maxSteeringForce = 1;
        

        public SteeringBehaviorManager(SteeringControl parent = null)
        {
            m_behaviors = new List<SteeringBehavior>();
            m_active = new List<SteeringBehavior>();
            m_activeForce = new List<float>();

            m_parent = parent;
        }

        public virtual void Update(float dt)
        {
            if(m_behaviors.Count == 0)
            {
                return;
            }

            m_active.Clear();
            m_activeForce.Clear();

            //reset force
            m_totalSteeringForce = Vector2.Zero;

            bool needClamp = false;
            for (int i = 0; i < m_behaviors.Count; i++)
            {
                Vector2 steeringForce;
                steeringForce = Vector2.Zero;
                bool didSomething = m_behaviors[i].Update(dt, ref steeringForce);  

                if (didSomething)
                {
                    //keep track of the behaviors that actually
                    //did something this tick
                    m_active.Add(m_behaviors[i]);
                    m_activeForce.Add(steeringForce.Length());

                    //now we want combine the behaviors into
                    //the total steering force using
                    //whatever method we decide upon
                    bool keepGoing = false;

                    //This is for the “Simple weighted combination” method
                    //keepGoing = CombineForceWeighted(ref steeringForce, m_behaviors[i].m_weight);

                    keepGoing = CombineForcePrioritySum(ref steeringForce);

                    needClamp = true;

                    if (!keepGoing)
                    {
                        break;
                    }
                }
            }

            if (needClamp)
            {
                MathHelper.Clamp(m_totalSteeringForce.Length(), 0.0f, m_maxSteeringForce);
                //Vector2.Clamp(m_totalSteeringForce.Length(), Vector2.Zero, m_maxSteeringForceVector);
            }
        }

        public virtual void AddBehavior(SteeringBehavior behavior)
        {
            m_behaviors.Add(behavior);
        }

        public virtual void DisableBehavior(int index)
        {

        }

        public virtual void SetUpBehavior(int behaviorIndex, float weight, float propability, bool disable = false)
        {
            m_behaviors[behaviorIndex].m_weight = weight;
            m_behaviors[behaviorIndex].m_propability = propability;

        }

        public virtual void Reset()
        {

        }

        public virtual Vector2 GetFinalSteeringVector()
        {
            return m_totalSteeringForce;
        }

        public virtual void Draw()
        {

        }

        public virtual bool CombineForceWeighted(ref Vector2 steeringForce, float weight)
        {
            m_totalSteeringForce += steeringForce * weight;
            return true;
        }

        public virtual bool CombineForcePrioritySum(ref Vector2 steeringForce)
        {
            bool retVal = false;

            float totalforce = m_totalSteeringForce.Length();
            float forceLeft = m_maxSteeringForce - totalforce;

            if(forceLeft > 0.0f)
            {
                float newForce = steeringForce.Length();

                if(newForce < forceLeft)
                {
                    m_totalSteeringForce += steeringForce;
                }
                else
                {
                    m_totalSteeringForce += Vector2.Normalize(steeringForce) * forceLeft;
                }

                if((forceLeft - newForce) > 0)
                {
                    retVal = true;
                }
            }

            return retVal;
        }

        public virtual bool CombineForcePriorityDithered(Vector2 steeringForce, float weight, float randChance)
        {
            bool retval = true;

            //More to add? brhöver imnte lägga till

            return retval;
        }
    }
}
