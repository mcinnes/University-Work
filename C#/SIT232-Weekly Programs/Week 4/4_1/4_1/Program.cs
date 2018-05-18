using System;
using System.Collections.Generic;
            
namespace _4_1
{
    class Program
    {
        static void Main(string[] args)
        {
			Book book1 = new Book("Schildt, H.", "C# 4.0: The Complete Reference", "Osborne Media", 2001);
			Book book2 = new Book("Deitel, P. and Deitel, H.", "Visual C# 2012: How to Program", "Pearson", 2014);

			Order order1 = new Order();
			order1.Add(book2);

			Order order2 = new Order("Freddie");
			order2.Add(book2);

			List<Book> Orders = new List<Book>();
			Orders.Add(book1);
			Orders.Add(book2);

			Order order3 = new Order(Orders);

			DisplayOrder(order1);
			DisplayOrder(order2);
			DisplayOrder(order3);

        }
		public static void DisplayOrder(Order order)
		{
			Console.WriteLine(order.ToString());

			foreach (Book book in order.Books)
				Console.WriteLine("-- {0}", book.ToString());
		}
    }
}
