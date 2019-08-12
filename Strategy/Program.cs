using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode head = BuildATree();
            Tree tree = new Tree(head);

            InOrderTraversal inOrderTraversal = new InOrderTraversal();
            PreOrderTraversal preOrderTraversal = new PreOrderTraversal();
            PostOrderTraversal postOrderTraversal = new PostOrderTraversal();
            BFSTraversal bfsTraversal = new BFSTraversal();

            tree.SetTraversalMethod(inOrderTraversal);
            tree.Print();

            tree.SetTraversalMethod(preOrderTraversal);
            tree.Print();

            tree.SetTraversalMethod(postOrderTraversal);
            tree.Print();

            tree.SetTraversalMethod(bfsTraversal);
            tree.Print();
        }

        static TreeNode BuildATree()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;

            node3.Left = node5;
            node3.Right = node6;

            return node1;
        }
    }
}
