using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3Practise_Binary_tree
{
    class Tree
    {
        Node root = null;
        int level1 = 0;
        char pole = '|';
        public Tree()
        {

        }
        public void Insert(int data)
        {
            if(root == null)
            {
                root = new Node(data);
            }
            else
            {
                Insert(data, root);
            }
            
        }
        public void Print()
        {
            Print(root, level1);
        }
        private void Insert(int data, Node node)
        {
            if (data >= node.Data)
            {
                if(node.Right == null)
                {
                    node.Right = new Node(data);
                    return;
                }
                Insert(data, node.Right);
            }
            else if (data < node.Data)
            {
                if(node.Left == null)
                {
                    node.Left = new Node(data);
                    return;
                }
                node = node.Left;
                Insert(data, node);
            }
        }
        private void Print(Node node, int level)
        {
            if(node == null)
            {
                return;
            }
                for (int i = 1; i <= level; i++)
                {
                    Console.Write(pole);
                }
            Console.Write(node.Data + "\n");
            Print(node.Left, level+1);
            
            Print(node.Right, level+1);
            }
        
    }
}
