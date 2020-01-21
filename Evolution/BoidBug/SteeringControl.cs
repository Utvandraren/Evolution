using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Evolution.BoidBug
{
    class SteeringControl
    {
        protected SteeringBehaviorManager m_behaviorManager;

        public float m_safetyRadius;
        public BadBug m_nearestBadBug;
        public Boig m_bug;

        public SteeringControl(Boig bug = null)
        {
            m_bug = bug;

            m_behaviorManager = new SteeringBehaviorManager(this);
            m_behaviorManager.AddBehavior(new SteerApproach(this));
            m_behaviorManager.AddBehavior(new SteerWander(this));
            m_behaviorManager.AddBehavior(new SteerPursuit(this));
            m_behaviorManager.AddBehavior(new SteerArrive(this));
            m_behaviorManager.AddBehavior(new SteerEvade(this));

            m_behaviorManager.Reset();

            m_behaviorManager.SetUpBehavior(4, 1f, 1.0f);   //evade
            m_behaviorManager.SetUpBehavior(3, 1.0f, 1.0f); //arrive
            m_behaviorManager.SetUpBehavior(2, 1.0f, 1.0f);   //pursue
            m_behaviorManager.SetUpBehavior(1, 1f, 1.0f);    //wander
            m_behaviorManager.SetUpBehavior(0, 1f, 1.0f);     //approach

            //m_behaviorManager.AddBehavior(new SteerApproach(this));
            //m_behaviorManager.AddBehavior(new SteerWander(this));
            //m_behaviorManager.AddBehavior(new SteerArrive(this));

            //m_behaviorManager.Reset();

            //m_behaviorManager.SetUpBehavior(0, 3f, 1.0f);
            //m_behaviorManager.SetUpBehavior(1, 3f, 1.0f);
            //m_behaviorManager.SetUpBehavior(2, 3f, 1.0f);

        }

        public void Update(float dt)
        {
            if (m_bug == null)
            {
                m_behaviorManager.Reset();
                return;
            }

            UpdatePerceptions(dt);
            m_behaviorManager.Update(dt);
            Vector2 totalSteeringForce = m_behaviorManager.GetFinalSteeringVector();

            m_bug.Direction += totalSteeringForce;
        }

        public void UpdatePerceptions(float dt)
        {

        }

        public void Init()
        {

        }

        public void Draw()
        {

        }

        public void Reset()
        {

        }



    }
}
