using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    /// <summary>
    /// Class Node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        public T Key { get; private set; }
        /// <summary>
        /// Gets or sets the height of subtree with root in current node
        /// </summary>
        /// <value>The height.</value>
        private int _height;
        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        /// <value>The left node.</value>
        public Node<T> LeftNode { get; set; }
        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        /// <value>The right node.</value>
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
    }
}
