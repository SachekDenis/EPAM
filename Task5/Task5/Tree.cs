using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    public class Tree<T> : IEnumerable<T> where T : IComparable
    {
        private Node<T> _root;

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _root = Insert(_root, value);
            Count++;
        }

        public void Delete(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _root = Remove(_root, value);
        }

        public T Find(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            Node<T> node = FindNode(_root, value);
            if (node != null)
                return node.Key;
            else
                return default;
        }

        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            return FindNode(_root, value) != null;
        }

        private Node<T> FindNode(Node<T> node, T value)
        {
            if (node == null || value.CompareTo(node.Key) == 0)
                return node;
            if (value.CompareTo(node.Key) == -1)
                return FindNode(node.LeftNode, value);
            else
                return FindNode(node.RightNode, value);
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> tmpNode = node.LeftNode;
            node.LeftNode = tmpNode.RightNode;
            tmpNode.RightNode = node;
            node.RestoreHeight();
            tmpNode.RestoreHeight();
            return tmpNode;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> tmpNode = node.RightNode;
            node.RightNode = tmpNode.LeftNode;
            tmpNode.LeftNode = node;
            node.RestoreHeight();
            tmpNode.RestoreHeight();
            return tmpNode;
        }

        private Node<T> Balance(Node<T> node)
        {
            node.RestoreHeight();
            if (node.GetBalanceFactor() == 2)
            {
                if (node.RightNode.GetBalanceFactor() < 0)
                    node.RightNode = RotateRight(node.RightNode);
                return RotateLeft(node);
            }
            if (node.GetBalanceFactor() == -2)
            {
                if (node.LeftNode.GetBalanceFactor() > 0)
                    node.LeftNode = RotateLeft(node.LeftNode);
                return RotateRight(node);
            }
            return node;
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
                return new Node<T>(value);
            if (value.CompareTo(node.Key) == -1)
                node.LeftNode = Insert(node.LeftNode, value);
            else
                node.RightNode = Insert(node.RightNode, value);
            return Balance(node);
        }

        private Node<T> FindMinNode(Node<T> node)
        {
            return node.LeftNode != null ? FindMinNode(node.LeftNode) : node;
        }

        private Node<T> RemoveMin(Node<T> node)
        {
            if (node.LeftNode == null)
                return node.RightNode;
            node.LeftNode = RemoveMin(node.LeftNode);
            return Balance(node);
        }

        private Node<T> Remove(Node<T> node, T value)
        {
            if (node == null) return null;
            if (value.CompareTo(node.Key) == -1)
                node.LeftNode = Remove(node.LeftNode, value);
            else if (value.CompareTo(node.Key) == 1)
                node.RightNode = Remove(node.RightNode, value);
            else
            {
                // Finded node
                // Reduce count only if finded node
                Count--;
                Node<T> firstNode = node.LeftNode;
                Node<T> secondNode = node.RightNode;
                node = null;
                if (secondNode == null) return firstNode;
                Node<T> min = FindMinNode(secondNode);
                min.RightNode = RemoveMin(secondNode);
                min.LeftNode = firstNode;
                return Balance(min);
            }
            return Balance(node);
        }


        private IEnumerable<T> PreOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                yield return node.Key;

                foreach (var key in PreOrderTraversal(node.LeftNode))
                {
                    yield return key;
                }

                foreach (var key in PreOrderTraversal(node.RightNode))
                {
                    yield return key;
                }
                //PreOrderTraversal(node.LeftNode);
                //PreOrderTraversal(node.RightNode);
            }
        }

        private IEnumerator<T> InOrderTraversal()
        {
            if (_root != null)
            {
                // Stack to save missing nodes.
                Stack<Node<T>> stack = new Stack<Node<T>>();

                Node<T> current = _root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        // Put everything except the leftmost node on the stack.
                        // We will return the leftmost node with yield.
                        while (current.LeftNode != null)
                        {
                            stack.Push(current);
                            current = current.LeftNode;
                        }
                    }

                    yield return current.Key;

                    if (current.RightNode != null)
                    {
                        current = current.RightNode;

                        goLeftNext = true;
                    }
                    else
                    {

                        // If we can't go right, we have to get the parent node
                        // from the stack, process it and go to its right child.
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrderTraversal(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
