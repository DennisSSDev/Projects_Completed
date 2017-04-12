﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_ICE
{
    class LinkedList
    {
        //put a node property at the head of the list 
        public int Count { get; set; }
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
            if(index < 0)
            {
                return null;
            }
            while(curHead.Link != null)
            {
                if (loopToFindLink == index)
                {
                    return curHead.Data;
                }
                curHead = curHead.Link;
                loopToFindLink++;
            }
            return null;
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
            Node newNode = new Node(dataInsert);
            try
            {
                if (index < 0)
                {
                    throw new Exception();
                }
              
                int count = 0;
                while(curHead.Link != null)//work on this 
                {
                    
                    if(count == index)
                    {
                        Node someNode = curHead.Link;
                        curHead.Link = newNode;
                        newNode.Link = someNode;
                        
                    }
                    curHead = curHead.Link;
                    count++;
                }
                if (count < index)
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void InsertSorted(string data)
        {
            
            Node newNode = new Node(data);
            Node curHead = Head;
            if (Head == null)
            {
                Head = newNode;
                Count++;
                return;
            }
            else if(Head != null)
            {
                while (Head != null)
                {
                    if (newNode.Data.CompareTo(Head.Data) <= 0)
                    {
                        Node someNode = Head;
                        Head = newNode;
                        Head.Link = someNode;
                        return;
                    }
                    if (Head.Link == null && Head.Data.CompareTo(newNode.Data) > 0)
                    {
                        Head.Link = newNode;
                        return;
                    }
                    Head = Head.Link;
                    
                }
            }
            
        }

    }
}
