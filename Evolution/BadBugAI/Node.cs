using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Evolution.BadBugAI
{
    class Node
    {
        public int ID;
        public Node trueBranch, falseBranch;
        public BadBug bug;
        Node root;

        public Node(int newId, BadBug newBug)
        {
            this.ID = newId;
            bug = newBug;
        }

        public virtual void SetRoot(int newID)
        {
            root = new Node(newID,bug);
        }

        public virtual void AddTrueNode(Node newNode)
        {
            trueBranch = newNode;
        }
       
        public virtual void AddFalseNode(Node newNode)
        {
            falseBranch = newNode;
        }

        public virtual void Eval()
        {
            if (trueBranch != null)
            {
                if (trueBranch.Condition())
                {
                    trueBranch.Eval();
                    return;
                }
            }

            if (falseBranch != null)
            {
                if (falseBranch.Condition())
                {
                    falseBranch.Eval();
                    return;

                }
            }

            Action(); // Gör detta om ingen av brancherna är sanna
           
        }

        public virtual bool Condition()
        {
            return true;
        }

        public virtual void Action()
        {
        }
    }
}
