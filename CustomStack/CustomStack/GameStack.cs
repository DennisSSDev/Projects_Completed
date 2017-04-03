using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class GameStack : IStack
    {
        private string[] stack;
        public GameStack(string[] stack)
        {
            this.stack = stack;
        }
        public string[] Array()
        {
            return stack;
        }
        public int Count
        {
            get
            {
                return stack.Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if(stack.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Peek()
        {
            return stack[stack.Length - 1];
        }

        public string Pop()
        {
            string temp1 = stack[stack.Length - 1];
            
            string[] temp = new String[stack.Length - 1];

            for (int i = 0; i < stack.Length-1; i++)
            {
                temp[i] = stack[i];
            }
            stack = temp;
            return temp1;
        }

        public void Push(string str)
        {
            string[] temp = new string[stack.Length + 1];
            for (int i = 0; i < stack.Length; i++)
            {
                temp[i] = stack[i];
            }
            stack = temp;
            stack[stack.Length - 1] = str;
        }
    }
}
