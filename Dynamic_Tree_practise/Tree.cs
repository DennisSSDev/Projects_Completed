using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Tree_practise
{
    class Tree
    {
        Node obj;
        int lvl = 0;
        public Tree()
        {

        }
        private void Insert(int data, Node node)
        {
            if (node.Data > data)
            {
                if(node.Left == null)
                {
                    node.Left = new Node() { Data = data };
                }
                else
                {
                    Insert(data, node.Left);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new Node() { Data = data };

                }
                else
                {
                    Insert(data, node.Right);
                }
            }
        }
        private void Print(Node node, int level)
        {
            if(node == null)
            {
                return;
            }
            for (int i = 0; i <= level; i++)
            {
                Console.Write('|');
            }


            Console.Write(node.Data + "\n");
            

            Print(node.Left, level + 1);

            
            Print(node.Right, level + 1);
            
            
                
       
        }
        public void Print()
        {
            Print(obj, lvl);
        }
        public void Insert(int data)
        {
            if(obj == null)
            {
                obj = new Node(){ Data = data };
            }
            else
            {
                Insert(data, obj);
            }
        }
    }
}
