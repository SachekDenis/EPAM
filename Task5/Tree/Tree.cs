using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    /// <summary>
    /// Class Tree.
    /// Implements the <see cref="System.Collections.Generic.IEnumerable{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    [DataContract]
    public class Tree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// The root
        /// </summary>
        [DataMember]
        private Node<T> _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree{T}"/> class.
        /// </summary>
        public Tree()
        {}

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        [DataMember]
        public int Count { get; private set; }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _root = Insert(_root, value);
            Count++;
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Delete(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _root = Remove(_root, value);
        }

        /// <summary>
        /// Finds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
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

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            return FindNode(_root, value) != null;
        }

        /// <summary>
        /// Finds the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="value">The value.</param>
        /// <returns>The node.</returns>
        private Node<T> FindNode(Node<T> node, T value)
        {
            if (node == null || value.CompareTo(node.Key) == 0)
                return node;
            if (value.CompareTo(node.Key) == -1)
                return FindNode(node.LeftNode, value);
            else
                return FindNode(node.RightNode, value);
        }

        /// <summary>
        /// Right rotate of subtree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node.</returns>
        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> tmpNode = node.LeftNode;
            node.LeftNode = tmpNode.RightNode;
            tmpNode.RightNode = node;
            node.RestoreHeight();
            tmpNode.RestoreHeight();
            return tmpNode;
        }

        /// <summary>
        /// Lefts rotate of subtree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node.</returns>
        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> tmpNode = node.RightNode;
            node.RightNode = tmpNode.LeftNode;
            tmpNode.LeftNode = node;
            node.RestoreHeight();
            tmpNode.RestoreHeight();
            return tmpNode;
        }

        /// <summary>
        /// Balances the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node.</returns>
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

        /// <summary>
        /// Inserts the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="value">The value.</param>
        /// <returns>The node.</returns>
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

        /// <summary>
        /// Finds the minimum node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node.</returns>
        private Node<T> FindMinNode(Node<T> node)
        {
            return node.LeftNode != null ? FindMinNode(node.LeftNode) : node;
        }

        /// <summary>
        /// Removes the minimum.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node.</returns>
        private Node<T> RemoveMin(Node<T> node)
        {
            if (node.LeftNode == null)
                return node.RightNode;
            node.LeftNode = RemoveMin(node.LeftNode);
            return Balance(node);
        }

        /// <summary>
        /// Removes the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="value">The value.</param>
        /// <returns>The node.</returns>
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


        /// <summary>
        /// Preorder traversal.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IEnumerable.</returns>
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

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrderTraversal(_root).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is Tree<T> tree &&
                   EqualityComparer<Node<T>>.Default.Equals(_root, tree._root) &&
                   Count == tree.Count;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = 1677102654;
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(_root);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
