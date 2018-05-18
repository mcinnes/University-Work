using System;

namespace _5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Patron patron = new Patron();
            
            Book book = new Book("796.6", "The Univeristy of Chicago Press", "Cycling Science", "Max Glaskin");
            Periodical periodical = new Periodical("231.2", "MAD Publishing", "MAD Magazine", "623");
            
            patron.BorrowBook(book);            
            patron.BorrowPeriodical(periodical);            
            patron.BorrowBook(book);            
            patron.BorrowBook(book);            
            patron.BorrowPeriodical(periodical);

            Console.WriteLine("\nBorrowed items:");
            foreach (var element in patron.itemList)
            {
                Console.WriteLine(element.Title);
            }
}
    }
}
