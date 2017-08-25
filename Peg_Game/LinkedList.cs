using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peg_Game
{
    class LinkedList
    {
        Node head = null;
        public LinkedList()
        {

        }

        public void Add(Node toAdd)
        {
            if(head == null)
            {
                head = toAdd;
            }
            else
            {
                Node sub = head;
                while (sub.Next!=null)
                {
                    sub = sub.Next;
                }
                sub.Next = toAdd;
            }
        }
        public int Length()
        {
            int temp = 0;
            Node tempN = head;
            while (tempN != null)
            {
                tempN = tempN.Next;
                temp++;
            }
            return temp;
        }
        public void Remove(int data)
        {
            if(data == 0)
            {
                head = head.Next;
            }
            else if (data + 1 == this.Length())
            {
                Node temp = head;
                while (temp.Next!=null)
                {
                    temp = temp.Next;
                }
                temp = null;
            }
            else
            {
                int count = 0;
                Node temp = head;
                Node prvs = null;
                while(count != data)
                {
                    prvs = temp;
                    temp = temp.Next;
                    count++;
                }
                Node holder = temp.Next;
                temp = null;
                prvs.Next = holder;
            }
        }
    }
}
