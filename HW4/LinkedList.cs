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
            //No need to establish anything in the constructor
        }
        public int Count
        {
            get
            {
                return counter;
            }
        }

        public void Add(string data)//works fine
        {
            Node newNode = new Node(data); 
            //add a new node at the end of the list
            //if there is nothing in the list both head and tail are the newNode
            if (head == null)
            {
                head = newNode;
                tail = head;
                counter++;
                return;
            }
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
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
           
            return temp.Data;
           
        }

        public void Insert(string data, int index)
        {
            int counter1 = 0;
            Node newNode = new Node(data);
            if(index <=0)//works fine
            {
                Node save = head;
                head = newNode;
                if (save.Next != null)
                {
                    head.Next = save;
                    save.Previous = head;
                }
                counter++;
                return;
            }
            else
            {
                Node current = head;
                while (counter1 != index && current.Next != null)
                {
                    Node save2 = current;
                    current = current.Next;
                    counter1++;
                }
                if (index >= counter)
                {
                    Add(data);
                    counter++;
                    return;
                }
                Node save = current;//save to set it to the next
                Node save3 = current.Previous;
                current = newNode;
                current.Next = save;
                save.Previous = current;
                current.Previous = save3;
                save3.Next = current;
                //current.Next.Previous = current;//Might be unneccessary
                //current.Previous.Next = current;//same as above 
                counter++;
                //If the index in between the node list 
                //4 actions requierd to set the next and previous nodes
            }
        }

        public string Remove(int index)
        {
            int counter2 = 0;
            if (index < 0 || index > counter || head == null)
            {
                return null;
            }
            else if (index == 0)
            {
                string storage = head.Data;   
              Node store = head;
              head = head.Next;
              if (head != null)
              {
                  head.Previous = null;
              }
                counter--;
                return storage;
            }
            else if(counter-1 == index)
            {
                string saver = tail.Data;
                tail = tail.Previous;
                tail.Next = null;
                counter--;
                return saver;
            }
            else
            {
                Node tempH = head;
                while (index != counter2)
                {
                    Node save1 = tempH;
                    tempH = tempH.Next;
                    counter2++;
                }
                //below it doesn't work
                string saver = tempH.Data;
                Node right = tempH.Next;
                Node left = tempH.Previous;
                tempH = right;
                left.Next = right;
                tempH.Previous = left;

                counter--;
                return saver; 
            }
                
            
        }
    }
}
