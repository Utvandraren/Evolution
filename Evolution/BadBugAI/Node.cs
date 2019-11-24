using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.BadBugAI
{
    class Node
    {
        public int ID;
        public Node trueBranch, falseBranch;

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
            if (ParseTreeAndAddTrueNode(root, existingNodeID, newNodeID))
            {
                Console.WriteLine("Added " + newNodeID + " as True-node of " + existingNodeID);
            }
            else
            {
                Console.WriteLine("Node " + existingNodeID + " not found!");
            }
        }

        private bool ParseTreeAndAddTrueNode(Node currentNode, int existingNodeID, int newNodeID)
        {
            if (currentNode.ID == existingNodeID)
            {
                if (currentNode.trueBranch == null)
                {
                    currentNode.trueBranch = new Node(newNodeID);
                }

                else
                {
                    Console.WriteLine("Replacing " + currentNode.trueBranch.ID + "linked to trueBranch" + existingNodeID);
                    currentNode.trueBranch = new Node(newNodeID);
                }
                return true;
            }
            else
            {
                if (currentNode.trueBranch != null)
                {
                    if (ParseTreeAndAddTrueNode(currentNode.trueBranch, existingNodeID, newNodeID))
                    {
                        return true;
                    }
                    else
                    {
                        if (currentNode.falseBranch != null)
                        {
                            return (ParseTreeAndAddTrueNode(currentNode.falseBranch, existingNodeID, newNodeID));
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
        }

        public void AddFalseNode(int existingNodeID, int newNodeID, String newQuestAns)
        {
            if (root == null)
            {
                Console.WriteLine("ERROR: No DT!");
                return;
            }

            // Search tree

            if (ParseTreeAndAddFalseNode(root, existingNodeID, newNodeID))
            {
                Console.WriteLine("Added node " + newNodeID + " onto \"no\" branch of node " + existingNodeID);
            }
            else Console.WriteLine("Node " + existingNodeID + " not found");
        }

        private bool ParseTreeAndAddFalseNode(Node currentNode, int existingNodeID, int newNodeID)
        {
            if (currentNode.ID == existingNodeID)
            {
                if (currentNode.falseBranch == null) currentNode.falseBranch = new Node(newNodeID);

                else
                {
                    Console.WriteLine("WARNING: Replacing " + "(id = " + currentNode.falseBranch.ID + ") linked to True-branch of node " + existingNodeID); currentNode.falseBranch = new Node(newNodeID);
                }
                return (true);
            }
            else
            {
                if (currentNode.trueBranch != null)
                {
                    if (ParseTreeAndAddFalseNode(currentNode.trueBranch, existingNodeID, newNodeID))
                    {
                        return (true);
                    }
                    else
                    {
                        if (currentNode.falseBranch != null)
                        {
                            return (ParseTreeAndAddFalseNode(currentNode.falseBranch, existingNodeID, newNodeID));
                        }
                        else
                        {
                            return (false);
                        }
                    }
                }
                else
                {
                    return (false);
                }
            }
        }

        private void Eval(Node currentNode)
        {
            //Console.WriteLine(currentNode.Eval + " (enter \"Y\" or \"N\")");
            String input = Console.ReadLine();
            if (input.Equals("Y")) ParseTree(currentNode.trueBranch);
            else
            {
                if (input.Equals("N")) ParseTree(currentNode.falseBranch);
                else
                {
                    Console.WriteLine("Please answer \"Y\" or \"N\"");
                    Eval(currentNode);
                }
            }
        }

        void ParseTree(Node currentNode)
        {
            if (currentNode.trueBranch == null)
            {
                if (currentNode.falseBranch == null)
                {
                    //Console.WriteLine(currentNode.Eval);
                }
                return;
            }
            if (currentNode.falseBranch == null)
            {
                return;
            }
            Eval(currentNode);
        }

        public void ParseTree()
        {
            ParseTree(root);
        }
    }
}
