using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class LinkedList : IList
    {
        Node head;
        Node tail;
        int counter = 0;
        public LinkedList()
        {

        }
        public int Count
        {
            get
            {
                return counter;
            }
        }

        public void Add(string data)
        {
            Node newNode = new Node(data);
            if(tail == null)
            {
                tail = newNode;
                head = tail;
                counter++;
            }
            else
            {
                while (tail!=null)
                {
                    tail = tail.Next;
                }
                tail = newNode;
                counter++;
            }
        }

        public void Clear()
        {
            tail = null;
            head = tail;
            counter = 0;
        }

        public string GetElement(int index)
        {
            Node temp = head;
            int count = 0;
            while (count != index && temp != null)//think about this 
            {
                temp = temp.Next;
            }
            if(temp == null)
            {
                return null;
            }
            else
            {
                return temp.Data;
            }
        }

        public void Insert(string data, int index)
        {
            throw new NotImplementedException();
        }

        public string Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
