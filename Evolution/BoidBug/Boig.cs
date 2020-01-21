using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Evolution.BoidBug
{
    class Boig : Bug
    {
        public float maxSpeed = 100.0f;
        List<Boig> boigList;
        public GameObject nearestBoig;
        SteeringControl strCtrl;
        float approachRadius = 60;

        public Boig(Rectangle drawRect, Texture2D texture, Vector2 pos, Random rnd, List<Boig> boigs) : base( drawRect,  texture,  pos, rnd)
        {
            boigList = boigs;
            direction = Vector2.One;
            speed = 40;
            strCtrl = new SteeringControl(this);
            m_Size = 5;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            direction = m_velocity;
            speed = maxSpeed;
            //pos += m_velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            strCtrl.Update(gameTime.ElapsedGameTime.Seconds);
        }

        public GameObject GetClosestGameObj()
        {
            bool foundSomething = true;
            foreach (GameObject boig in boigList)
            {
                if(boig == this)
                {
                    continue;
                }

                else if(nearestBoig == null)
                {
                    nearestBoig = boig;
                }

                else if (Vector2.Distance(boig.pos, pos) < Vector2.Distance(nearestBoig.pos, pos))
                {
                    foundSomething = true;
                    nearestBoig = boig;
                }
            }

            if (foundSomething)
            {
                return nearestBoig;
            }
            else
            {
                return null;
            }
            
        }

        public void ResetTarget()
        {
            //nearestBoig = new Vector2(2000, 1000);
        }
    }
}
