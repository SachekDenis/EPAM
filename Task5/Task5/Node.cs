using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    /// <summary>
    /// Class Node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    internal class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public Node(T key)
        {
            Key = key;
            _height = 1;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        [DataMember]
        public T Key { get; private set; }
        /// <summary>
        /// Gets or sets the height of subtree with root in current node
        /// </summary>
        /// <value>The height.</value>
        [DataMember]
        private int _height;
        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        /// <value>The left node.</value>
        [DataMember]
        public Node<T> LeftNode { get; set; }
        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        /// <value>The right node.</value>
        [DataMember]
        public Node<T> RightNode { get; set; }

        /// <summary>
        /// Gets the height of the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Height.</returns>
        private int GetNodeHeight(Node<T> node)
        {
            return node != null ? node._height : 0;
        }

        /// <summary>
        /// Get the balance factor.
        /// </summary>
        /// <returns>Balance factor.</returns>
        public int GetBalanceFactor()
        {
            return GetNodeHeight(RightNode) - GetNodeHeight(LeftNode);
        }

        /// <summary>
        /// Restores the height.
        /// </summary>
        public void RestoreHeight()
        {
            int leftHeight = GetNodeHeight(LeftNode);
            int rightHeight = GetNodeHeight(RightNode);
            _height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
        }

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(Key, node.Key) &&
                   _height == node._height &&
                   EqualityComparer<Node<T>>.Default.Equals(LeftNode, node.LeftNode) &&
                   EqualityComparer<Node<T>>.Default.Equals(RightNode, node.RightNode);
        }

        public override int GetHashCode()
        {
            var hashCode = 619244618;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Key);
            hashCode = hashCode * -1521134295 + _height.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(LeftNode);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(RightNode);
            return hashCode;
        }
    }
}
