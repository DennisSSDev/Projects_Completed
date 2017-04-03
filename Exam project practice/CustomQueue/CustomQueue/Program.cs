using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
	class Program
	{
		static void Main(string[] args)
		{
            GameQueue newQueue = new GameQueue(new string[0]);
            newQueue.Enqueue("Bob");
            newQueue.Enqueue("Jack");
            newQueue.Enqueue("Fudge");
            newQueue.Enqueue("Gavvy");
            newQueue.Enqueue("Wavvy");
            newQueue.Enqueue("BobAgain");
            newQueue.Enqueue("Creativity");
            newQueue.Enqueue("None");
            newQueue.Enqueue("NoMorePLS");
            newQueue.Enqueue("OkGood");
            newQueue.Enqueue("abfkjsd");
            while(newQueue.IsEmpty == false)
            {
                Console.WriteLine(newQueue.Dequeue());
            }
        }
	}
}
