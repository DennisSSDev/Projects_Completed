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
        public LinkedList()//constructor for init
        {
            //No need to establish anything in the constructor, just here to not cause errors in c#
        }
        public int Count//keeps track of how many words are in the doublylinked list
        {
            get
            {
                return counter;
            }
        }

        public void Add(string data)//regular add method for linked list but will change the tail if the head isn't null
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

        public void Clear()//clears the list of all members
        {
            tail = null;
            head = tail;
            counter = 0;
        }

        public string GetElement(int index)//returns a link's data at the apropriate index, if the index is null, returns null
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
        public void Insert(string data, int index)//inserts a node at the appropriate index
        {
            int counter1 = 0;
            Node newNode = new Node(data);
            if(index <=0)//if the index sets the value at 0 or below it, will set the head to the new node and change the next node to the old node if there 
            {//already existed a head (wasn't null)
                if(head == null)//if there is nothing at the head, add the new node and set the tail and the head to the same value
                {
                    Add(data);
                    return;
                }
                Node store = head;
                head = newNode;
                head.Next = store;
                store.Previous = head;

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
                if (index >= counter-1)
                {
                    Add(data);
                   
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

        public string Remove(int index)//Removes the node from the list at the specified index
        {
            int counter2 = 0;
            if (index < 0 || index > counter || head == null)//in case the index is completely invalid, or the head is not set to anything,
                //there won't be anyhting to remove
            {
                return null;
            }
            else if (index == 0)//if the index lands at the head
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
            else if(counter-1 == index)//in case the index lands at the tail, reomeve the tail and reassign nodes
            {
                string saver = tail.Data;
                tail = tail.Previous;
                tail.Next = null;
                counter--;
                return saver;
            }
            else//if it's neither tail, nor head, continue traversing through the list until hit the satisfying index and remove the node at that spot
            //reassign the nodes accordingly
            {
                Node tempH = head;
                while (index != counter2)
                {
                    Node save1 = tempH;
                    tempH = tempH.Next;
                    counter2++;
                }
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
