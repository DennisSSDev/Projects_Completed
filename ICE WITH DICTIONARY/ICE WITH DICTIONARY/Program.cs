using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_WITH_DICTIONARY
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , DictionaryWithWords> namesOfStuff = new Dictionary<string, DictionaryWithWords>();
            DictionaryWithWords thing1 = new DictionaryWithWords();
            DictionaryWithWords thing2 = new DictionaryWithWords();
            DictionaryWithWords thing3 = new DictionaryWithWords();
            DictionaryWithWords thing4 = new DictionaryWithWords();

            thing1.definition = "a device for keeping insurance companies";
            thing2.definition = "is graceful, well mannered creature commonly fpound in IGME Labs";
            thing3.definition = "a person who does code very very fast";
            thing4.definition = "A person who does code very slowly";
            namesOfStuff.Add("car", thing1);
            namesOfStuff.Add("cat", thing2);
            namesOfStuff.Add("professor", thing3);
            namesOfStuff.Add("me", thing4);
            string end = "";
            while(end != "EXIT")
            {
                Console.WriteLine("Enter a word to locate: ");
                end = Console.ReadLine();
                if (namesOfStuff.ContainsKey(end) == true)
                {
                    Console.WriteLine(namesOfStuff[end]);
                }
                else if (end == "EXIT")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You done screwed up, type a correct key name");
                }
            }
            Console.WriteLine("Thank you for using this program");
        }
    }
}
