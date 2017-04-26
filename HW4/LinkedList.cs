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
            Node newNode = new Node(data);
            if(index <=0)//works fine
            {

                Node save = head;
                head = newNode;
                head.Next = save;
                counter++;
                return;
            }
            else if (index >= counter)
            {
                Add(data);
            }
            else
            {
                Node current = head;
                while (counter1 != index)
                {
                    Node save2 = current;
                    current = current.Next;
                    current.Previous = save2;
                }
                Node save = current;//save to set it to the next
                current = newNode;
                current.Next = save;
                current.Previous = save.Previous;
                current.Next.Previous = current;//Might be unneccessary
                current.Previous.Next = current;//same as above 
                //If the index in between the node list 
                //4 actions requierd to set the next and previous nodes
            }
        }

        public string Remove(int index)
        {
            
            int counter2 = 0;
            if (index < 0 || index > counter)
            {
                return null;
            }
            else if (index == 0)
            {
                if(head != null)
                {
                    Node tempH1 = head;
                    string storage = tempH1.Data;
                    head = head.Next;
                    head.Previous = null;
                    counter--;
                    return storage;
                }
                else if(head == null)
                {
                    return null;
                } 
            }
            Node tempH = head;
            while (index != counter2)
            {
                Node save1 = tempH;
                tempH = tempH.Next;
                tempH.Previous = save1;
                counter2++;
            }
            if(tempH == null)
            {
                return null;
            }
            else if(tempH == tail)
            {
                string saver = tempH.Data;
                Node saver2 = tempH.Previous;
                tail = tempH.Previous;
                tail.Next = null;
                counter--;
                return saver;
            }
            else
            {
                //below it doesn't work
                string saver = tempH.Data;
                Node right = tempH.Next;
                Node left = tempH.Previous;
                tempH = right;
                tempH.Previous = left;

                counter--;
                return saver; 
            }
                
            
        }
    }
}
