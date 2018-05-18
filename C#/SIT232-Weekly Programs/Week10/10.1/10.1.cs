using System;
using System.Collections.Generic;

namespace _10._1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string input;
             List<string> _List = new List<string>();
             bool cont = true;
              
            while (cont){
                Console.WriteLine("Enter term: ");
                input = Console.ReadLine().ToLower();
                
                
                
                foreach (string entry in _List)
                {
                    if (entry == input)
                    {
                        Console.WriteLine("Already in list, please try again");
                        break;
                    }
                    else if (entry.Contains(input))
                    {
                        Console.WriteLine("Similar term found: {0}", entry);
                    }
                }
                _List.Add(input);
                _List.Sort();
            }
        }
    }
}
