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

        public void Add(string data)//works fine, not sure if tail == head is neccessary
        {
            Node newNode = new Node(data);
            //add a new node when there are no nodes 
            //add a new node at the end of the list
            if (head == null)
            {
                head = newNode;
                tail = head;
                counter++;
                return;
            }
            
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            tail = newNode;
            current.Next = newNode;
            current.Next = tail;
            counter++;
            
        }

        public void Clear()
        {
            tail = null;
            head = tail;
            counter = 0;
        }//works fine

        public string GetElement(int index)//works fine
        {
            Node temp = head;
            int count = 0;
            while (count != index)
            {
                temp = temp.Next;
                count++;
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
            int counter1 = 0;
            Node tempH = head;
            Node newNode = new Node(data);
            if(index <=0)//works fine
            {
                Node temp = head;

                head = newNode;

                head.Next = temp;
                counter++;
                return;
            }
            while(tempH != null)
            {
                if(counter1 == index)
                {

                    Node store1 = tempH;
                    Node store2 = tempH.Next;
                    Node store3 = tempH.Previous;
                    tempH = newNode;
                    tempH.Next = store2;
                    tempH.Previous = store1;
                    store1.Previous = store3;
                    counter++;
                    return;
                }
                tempH = tempH.Next;
                counter1++;
            }
            Add(data);
        }

        public string Remove(int index)
        {
            
            int counter2 = 0;
            Node tempH = head;
            if (index < 0 || index > counter)
            {
                return null;
            }
            else if (index == 0)
            {
                if(head != null)
                {
                    string storage = tempH.Data;

                    tempH = tempH.Next;
                    tempH.Previous = null;
                    counter--;
                    return storage;
                }
                else
                {
                    return null;
                }
                
            }
            while(tempH != null || index != counter2)
            {
                tempH = tempH.Next;
                counter2++;
            }
            if(tempH == null)
            {
                return null;
            }
            if(tempH.Next == null)
            {
                string saver = tempH.Data;
                tail = tempH.Previous;
                tempH = null;
                tail.Next = null;
                counter--;
                return saver;
            }
            else
            {
                string saver = tempH.Data;
                Node right = tempH.Next;//the tailer
                Node left = tempH.Previous;//the starter
                tempH = left;
                tempH.Next = right;
                counter--;
                return saver; 
            }
                
            
        }
    }
}
