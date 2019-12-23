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
    public class Node<T>
    {
        public Node(T key)
        {
            Key = key;
            _height = 1;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public T Key { get; set; }
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

        private int GetNodeHeight(Node<T> node)
        {
            return node != null ? node._height : 0;
        }

        public int BalanceFactor()
        {
            return GetNodeHeight(RightNode) - GetNodeHeight(LeftNode);
        }

        public void RestoreHeight()
        {
            int leftHeight = GetNodeHeight(LeftNode);
            int rightHeight = GetNodeHeight(RightNode);
            _height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
        }
    }
}
