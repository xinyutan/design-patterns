using System;
using System.Collections.Generic;

namespace Strategy
{
    public class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int val)
        {
            Val = val;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// Interface for strategy
    /// </summary>
    public interface ITraversal
    {
        void Traverse(TreeNode node);
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class PreOrderTraversal : ITraversal
    {
        public void Traverse(TreeNode head)
        {
            if (head == null) 
            {
                return;
            }
            Console.WriteLine("Value: {0}", head.Val);
            Traverse(head.Left);
            Traverse(head.Right);
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class InOrderTraversal : ITraversal
    {
        public void Traverse(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            Traverse(head.Left);
            Console.WriteLine("Value: {0}", head.Val);
            Traverse(head.Right);
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class PostOrderTraversal : ITraversal
    {
        public void Traverse(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            Traverse(head.Left);
            Traverse(head.Right);
            Console.WriteLine("Value: {0}", head.Val);
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class BFSTraversal : ITraversal
    {
        public void Traverse(TreeNode head)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (head == null)
            {
                return;
            }
            queue.Enqueue(head);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.WriteLine("Value: {0}", node.Val);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class Tree
    {
        private TreeNode _head;
        private ITraversal _traversal;

        public Tree(TreeNode head)
        {
            _head = head;
        }

        public void SetTraversalMethod(ITraversal traversal)
        {
            _traversal = traversal;
        }

        public void Print()
        {
            Console.WriteLine("\nTraversing the tree using {0}...", _traversal.GetType().Name);
            _traversal.Traverse(_head);
        }
    }
}
