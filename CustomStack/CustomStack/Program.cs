using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
	class Program
	{
		static void Main(string[] args)
		{
            GameStack playingStack = new GameStack(new string[0]);
            for(int i = 0; i < 10; i++)
            {
                playingStack.Push("Shooting weapon" + i);
            }
            Console.WriteLine(playingStack.Peek());
            string read = "";
            bool isEmpty = false;
            while(isEmpty == false)
            {
                read = Console.ReadLine();
                if (read == "push")
                {
                    Console.WriteLine("What command you'd like to push");
                    read = Console.ReadLine();
                    playingStack.Push(read);
                }
                else if (read == "pop")
                {
                    Console.WriteLine(playingStack.Pop());
                    
                }
                else if(read == "list")
                {
                    foreach (var item in playingStack.Array())
                    {
                        Console.WriteLine(item);
                    }
                }
                
                if (playingStack.IsEmpty == true)
                {
                    isEmpty = true;
                }
            }
            
		}
	}
}
