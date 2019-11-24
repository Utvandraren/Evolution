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
        public Bug bug;
        Vector2 nearestBugPos;
        Node root;

        public Node(int newId)
        {
            this.ID = newId;
        }

        public void SetRoot(int newID)
        {
            root = new Node(newID);
        }

        public void AddTrueNode(int existingNodeID, int newNodeID)
        {
            if (root == null)
            {
                return;
            }

            trueBranch = new Node(newNodeID);
           
        }
       
        public void AddFalseNode(int existingNodeID, int newNodeID, String newQuestAns)
        {
            if (root == null)
            {
                return;
            }

            falseBranch = new Node(newNodeID);

        }

        private void Eval(Node currentNode)
        {

        }

       
    }
}
