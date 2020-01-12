using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class Program
    {
        /// <summary>
        /// I choose not to create unit tests for this simple program.
        /// Just to implement the functions for binary search tree to build, display and find Nearest Common Parent. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            //Test Nearest Common Node function here.

            //1. build binary search tree

            // integer list to be used to build binary search tree
            List<int> list = new List<int>() {20, 7, 25, 3, 11, 10, 15, 100, 36, 78, 31, 21, 19};
            var tree = BuildTree(list);


            //2. display binary search tree
            tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine();

            //3. run tests
            RunTests(tree);
        }

        private static void RunTests(BinarySearchTree tree)
        {
            // one of the node is not in the tree
            int first = 10;
            int second = 14;
            Node result = tree.FindNearestCommonParent(tree.Root, first, second);
            PrintResult(result);

            // both nodes in the tree
            first = 10;
            second = 15;
            result = tree.FindNearestCommonParent(tree.Root, first, second);
            PrintResult(result);

            // both nodes in the tree
            first = 15;
            second = 7;
            result = tree.FindNearestCommonParent(tree.Root, first, second);
            PrintResult(result);

            // both nodes in the tree
            first = 25;
            second = 3;
            result = tree.FindNearestCommonParent(tree.Root, first, second);
            PrintResult(result);

            // both nodes in the tree
            first = 25;
            second = 15;
            result = tree.FindNearestCommonParent(tree.Root, first, second);
            PrintResult(result);
        }

        private static BinarySearchTree BuildTree(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0},", item);
            }

            Console.WriteLine("Building binary with the following integers: {0}", sb.ToString().Trim(','));

            BinarySearchTree tree = new BinarySearchTree();
            foreach (int item in list)
                tree.Add(item);
            return tree;
        }

        private static void PrintResult(Node result)
        {
            string strResult = $"\tNearest common node is: {((result == null) ? "[Not Found]" : result.Data.ToString())}";
            Console.WriteLine(strResult);
        }
    }
}
