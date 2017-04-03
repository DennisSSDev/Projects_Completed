using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
    class GameQueue : IQueue
    {
        private String[] names;
        public GameQueue(String[] pNames)
        {
            this.names = pNames;
        }
        public int Count
        {
            get
            {
                return names.Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if(names.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Dequeue()
        {
            string removed = names[0];
            String[] temp = new String[names.Length - 1];
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = names[i+1];
            }
            names = temp;
            return removed;
        }

        public void Enqueue(string str)
        {
            String[] temp = new String[names.Length + 1];
            for(int i = 0; i < names.Length; i++)
            {
                temp[i] = names[i];
            }
            temp[temp.Length - 1] = str;
            names = temp;
        }

        public string Peek()
        {
            return names[0];
        }
    }
}
