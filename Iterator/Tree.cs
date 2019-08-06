using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    /// <summary>
    /// Item
    /// </summary>
    public class Node
    {
        public int Val { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node(int val)
        {
            Val = val;
            Right = null;
            Left = null;
        }
    }

    /// <summary>
    /// Interface for Aggregate
    /// </summary>
    public interface ITree
    {
        ITreeIterator CreateIterator();
    }

    /// <summary>
    /// Interface for Iterator
    /// </summary>
    public interface ITreeIterator
    {
        Node First();
        IEnumerable<Node> Next();
        bool IsDone();
    }

    /// <summary>
    /// ConcreteClass for Aggregate
    /// </summary>
    public class Tree : ITree
    {
        public Node Head { get; }

        public Tree(Node head)
        {
            Head = head;
        }
        public ITreeIterator CreateIterator()
        {
            return new PreOrderIterator(this);  
        }
    }

    /// <summary>
    /// ConcreteClass for Iterator
    /// </summary>
    public class PreOrderIterator : ITreeIterator
    {
        private readonly Tree _tree;

        public PreOrderIterator(Tree tree)
        {
            _tree = tree;
        }

        public Node First() => _tree.Head;

        public bool IsDone() => throw new NotImplementedException();

        public IEnumerable<Node> Next()
        {
            Stack NodeStack = new Stack();
            NodeStack.Push(_tree.Head);

            while (NodeStack.Count > 0)
            {
                var node = (Node)NodeStack.Pop();
                yield return node;
                if (node.Right != null)
                {
                    NodeStack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    NodeStack.Push(node.Left);
                }
            }
        }
    }
}