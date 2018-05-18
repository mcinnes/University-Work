using System;

namespace hwapp
{
    class Program
    {
        static void Main(string[] args)
        {
	Console.Write("Please enter your title (Mr, Mrs, Ms, etc: "); 
	string title = Console.ReadLine();

	Console.Write("Please enter your family name: "); 
	string familyName = Console.ReadLine();

	Console.Write("Please enter your given names: "); 
	string givenNames = Console.ReadLine();

	Console.Write("Please enter your country of birth: "); 
	string birthPlace = Console.ReadLine();

	Console.Write("Please enter any languages you speak: "); 
	string languages = Console.ReadLine();

	Console.WriteLine("**************************************************\n");
	Console.WriteLine("	Field 			Value\n");
	Console.WriteLine("**************************************************\n");
	Console.WriteLine("	Name:			{0} {1} {2}\n",title, givenNames, familyName);
	Console.WriteLine("	Born in:		{0}\n",birthPlace);
	Console.WriteLine("	Speaks:			{0}\n",languages);
	Console.WriteLine("**************************************************\n");        }
    }
}
