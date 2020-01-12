using System;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary Search Tree is built with node data is pre sorted by its value.
    /// If the new node's data is greater than current node's data, the new node will be added to the right node of the current node.
    /// If the new node's data is less than current node's data, the new node will be added to the left node of the current node.
    ///
    /// I am implementing only what is needed to demo the NearestCommonNode function.
    /// For demo, I am using recursive function.  This will have stack consequence when tree becoming too big.
    /// 
    /// </summary>
    class BinarySearchTree
    {
        public Node Root { get; set; }

        public Node FindNearestCommonParent(Node root, int first, int second)
        {
            Console.WriteLine("Find Nearest common parent between {0} and {1}", first, second);

            Node firstNode = new Node(first);
            Node secondNode = new Node(second);

            if (FindNode(root, firstNode) && FindNode(root, secondNode))
            {
                if(firstNode.Data < secondNode.Data)
                    return NearestCommonParent(root, firstNode, secondNode);
                else
                    return NearestCommonParent(root, secondNode, firstNode);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check if Node is in the tree or not
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeToFind"></param>
        /// <returns></returns>
        private bool FindNode(Node parentNode, Node nodeToFind)
        {
            if (parentNode != null)
            {
                if (nodeToFind.Data == parentNode.Data) 
                    return true;
                if (nodeToFind.Data < parentNode.Data)
                    return FindNode(parentNode.LeftNode, nodeToFind);
                else
                    return FindNode(parentNode.RightNode, nodeToFind);
            }

            return false;
        }

        /// <summary>
        /// Recursively traverse thru tree nodes to find the Nearest Common Parent in Binary Search Tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public  Node NearestCommonParent(Node node, Node left, Node right)
        {

            if (node == null)
                return null;

            // current node is greater than both left and right, the node we are seeking is on the left side
            if (node.Data > left.Data && node.Data > right.Data)
            {
                return NearestCommonParent(node.LeftNode, left, right);
            }
            // current node is smaller than both left and right, the node we are seeking is on the right side
            else if (node.Data < left.Data && node.Data < right.Data)
            {
                return NearestCommonParent(node.RightNode, left, right);
            }
            // found the node
            else
            {
                return node;
            }

        }

        /// <summary>
        /// Add val to leaf in the binary search tree
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Add(int val)
        {
            Node current = this.Root;
            Node before = current;

            // traverse to correct leaf node to add new value
            while (current != null)
            {
                before = current;   //save current node before traverse to next node
                if (val < current.Data)
                {
                    current = current.LeftNode; // new node needs to be added to left side
                }
                else if (val > current.Data)
                {
                    current = current.RightNode;    // new node needs to be added to right side
                }
                else
                {
                    return false;   // there is an existing node already
                }
            }

            // before node is a leaf node
            Node newNode = new Node(val);

            if (this.Root == null) //Tree is empty
            {
                this.Root = newNode;
            }
            else
            {
                if (val < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;

        }



        public void PrintTree()
        {
            Console.WriteLine("Binary Search Tree:");
            Console.WriteLine();
            PrintNode(Root, 4);
        }

        public void PrintNode(Node p, int padding)
        {
            int paddingOffset = 4;
            if (p != null)
            {
                if (p.RightNode != null)
                {
                    PrintNode(p.RightNode, padding + paddingOffset);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.RightNode != null)
                {
                    Console.WriteLine("/");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.WriteLine(p.Data.ToString() + " ");
                if (p.LeftNode != null)
                {
                    Console.WriteLine(" ".PadLeft(padding) + "\\");
                    PrintNode(p.LeftNode, padding + paddingOffset);
                }
            }
        }




    }
}