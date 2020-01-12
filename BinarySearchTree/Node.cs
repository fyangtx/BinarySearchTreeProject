namespace BinarySearchTree
{
    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }

        public Node(int val)
        {
            Data = val;
            LeftNode = null;
            RightNode = null;
        }
    }
}