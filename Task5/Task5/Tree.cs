using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    public class Tree<T> where T : IComparable
    {
        private Node<T> _root;

        public void Add(T value)
        {
            _root = Insert(_root,value);
        }

        public void Delete(T value)
        {
            _root =Remove(_root,value);
        }

        public List<T> Print()
        {
            var list = new List<T>();
            ConvertTreeToList(_root,list);
            return list;
        }

        private void ConvertTreeToList(Node<T> node,List<T> list )
        {
            if(node == null)
                return;
            ConvertTreeToList(node.LeftNode,list);
            list.Add(node.Key);
            if(node.RightNode!=null)
                ConvertTreeToList(node.RightNode,list);

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

        private Node<T> Balance(Node<T> node) // балансировка узла p
        {
            node.RestoreHeight();
            if (node.BalanceFactor() == 2)
            {
                if (node.RightNode.BalanceFactor() < 0)
                    node.RightNode = RotateRight(node.RightNode);
                return RotateLeft(node);
            }
            if (node.BalanceFactor() == -2)
            {
                if (node.LeftNode.BalanceFactor() > 0)
                    node.LeftNode = RotateLeft(node.LeftNode);
                return RotateRight(node);
            }
            return node; // балансировка не нужна
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

        private Node<T> FindMinNode(Node<T> node) // поиск узла с минимальным ключом в дереве p 
        {
            return node.LeftNode != null ? FindMinNode(node.LeftNode) : node;
        }

        private Node<T> RemoveMin(Node<T> node) // удаление узла с минимальным ключом из дерева p
        {
            if (node.LeftNode == null)
                return node.RightNode;
            node.LeftNode = RemoveMin(node.LeftNode);
            return Balance(node);
        }

        private Node<T> Remove(Node<T> node, T value) // удаление ключа k из дерева p
        {
            if (node == null) return null;
            if (value.CompareTo(node.Key)==-1)
                node.LeftNode = Remove(node.LeftNode, value);
            else if (value.CompareTo(node.Key)==1)
                node.RightNode = Remove(node.RightNode, value);
            else //  k == p->key 
            {
                Node<T> firdtNode = node.LeftNode;
                Node<T>  secondNode = node.RightNode;
                node = null;
                if (secondNode == null) return firdtNode;
                Node<T> min = FindMinNode(secondNode);
                min.RightNode = RemoveMin(secondNode);
                min.LeftNode = firdtNode;
                return Balance(min);
            }
            return Balance(node);
        }
    }
}
