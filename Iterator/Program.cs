using System;

namespace Iterator
{
    public class Client
    {
        static void Main()
        {

            Tree tree = BuildATree();
            var iterator = tree.CreateIterator();

            foreach (Node node in iterator.Next())
            {
                Console.WriteLine("Value: " + node.Val);
            }
        }

        public static Tree BuildATree()
        {
            Node root = new Node(1);
            Node node1 = new Node(2);
            Node node2 = new Node(3);
            Node node3 = new Node(4);
            Node node4 = new Node(5);
            Node node5 = new Node(6);
            root.Left = node1;
            root.Right = node2;
            node1.Left = node3;
            node1.Right = node4;
            node2.Right = node5;

            Tree tree = new Tree(root);
            return tree;
        }
    }
}
