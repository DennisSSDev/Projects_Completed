using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3_LinkedList
{
    class LinkedList
    {
        private Node head = null;
        public int total = 0;
        public int Total { get { return total; } }
        public LinkedList()
        {

        }
        public void Add(string data)
        {
            if(head == null)
            {
                head = new Node(data);
                total++;
            }
            else
            {
                Node temp = head;
                while (temp.Link != null)
                {
                    temp = temp.Link;
                }
                temp.Link = new Node(data);
                total++;
            }
        }
        public void Traverse()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Link;
            }
        }

        public void Insert(int index, string data)
        {
            int count = 0;
            if(index<0 || index >= total)
            {
                Console.WriteLine("your index is not valid");
                return;
            }
            else if(index == 0)
            {
                Node save = head;
                head = new Node(data);
                head.Link = save;
                total++;
            }
            else
            {
                Node temp = head;
                while(count != index)
                {
                    if(count+1 == index)
                    {
                        Node save = temp.Link;
                        temp.Link = new Node(data);
                        temp.Link.Link = save;
                        total++;
                        return;
                    }
                    temp = temp.Link;
                    count++;
                }

            }
        }
        public void Delete(int index)
        {
            if(index<0 || index >= total)
            {
                Console.WriteLine("Index out of range");
            }
            else if(index == 0)
            {
                head = head.Link;
            }
            else
            {
                int count = 0;
                Node temp = head;
                while (count != index)
                {
                    if(count+1 == index)
                    {
                        temp.Link = temp.Link.Link;
                        total--;
                        return;
                    }
                    temp = temp.Link;
                    count++;
                }
            }
        }
    }
}
