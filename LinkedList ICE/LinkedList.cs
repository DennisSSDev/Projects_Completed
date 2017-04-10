using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_ICE
{
    class LinkedList
    {
        //put a node property at the head of the list 

        public Node Head { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Add(string data)
        {
            Node newNode = new Node(data);
            //add a new node when there are no nodes 
            //add a new node at the end of the list
            if(Head == null)
            {
                Head = newNode;
                return;
            }
            
                Node current = Head;
                while (current.Link != null)
                {
                    current = current.Link;
                }
            current.Link = newNode;
            

        }

        public string GetData(int index)
        {
            int loopToFindLink = 0;
            Node curHead = Head;
            while(loopToFindLink <= index)
            {
                if (curHead.Link != null)
                {
                    return null;
                }
                curHead = curHead.Link;
                loopToFindLink++;
            }
            return curHead.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Traverse()
        {
            if(Head == null)
            {
                return;
            }
            Node cur = Head;
            while (cur != null)
            {
                Console.WriteLine(cur);
                cur = cur.Link;
            }
        }

        public void Clear()
        {
            Head = null;
        }
        public void Insert(int index, string dataInsert)
        {
            Node curHead = Head;
            try
            {
              
                int count = 0;
                while(count <= index)//work on this 
                {
                    
                    if(count == index)
                    {
                        curHead.Data = dataInsert;
                    }
                    curHead = curHead.Link;
                    count++;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       /* public void InsertSorted(string data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            Node cur = Head;
            while (cur != null)
            {
                if()
                cur = cur.Link;
            }
        }*/

    }
}
