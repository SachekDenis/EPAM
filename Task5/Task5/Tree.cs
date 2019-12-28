using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    [DataContract]
    public class Tree<T> : IEnumerable<T> where T : IComparable
    {
        [DataMember]
        private Node<T> _root;

        public Tree()
        {}

        [DataMember]
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
            // if height of right subtree bigger on 2
            if (node.GetBalanceFactor() == 2)
            {
                if (node.RightNode.GetBalanceFactor() < 0)
                    node.RightNode = RotateRight(node.RightNode);
                return RotateLeft(node);
            }
            // if height of left subtree bigger on 2
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
            // search node
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

        public override bool Equals(object obj)
        {
            return obj is Tree<T> tree &&
                   EqualityComparer<Node<T>>.Default.Equals(_root, tree._root) &&
                   Count == tree.Count;
        }

        public override int GetHashCode()
        {
            var hashCode = 1677102654;
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(_root);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
