using System;

namespace _4_2
{
    class Program
    {
        static readonly BookStock[] books = new BookStock[3];

        static void Main(string[] args)
        {

            books[0] = new BookStock(5, "Visual C#: How to Program", 134.95);
            books[1] = new BookStock(50, "Database Systems", 119.95);
            books[2] = new BookStock(500, "HTML & XHTML: The Complete Reference", 72.00);

            ProduceReport();
            
        }
        public static void ProduceReport()
        {
            string asterisks = new string('*', 54);
            Console.WriteLine(asterisks);
            Console.WriteLine(String.Format("|{0,4}| {1,-36}| {2,-8}|", "Qty", "Description", "Cost"));
            Console.WriteLine(asterisks);
             foreach (BookStock book in books)
             {
                Console.WriteLine(String.Format("|{0,4}| {1,-36}| ${2,-7}|", book.Quantity, book.Description, book.Price));
             }
            Console.WriteLine(asterisks);

        }
    }
    
    public class BookStock
    {
            private int _Quantity;
            private string _Description;
            private double _Price;
    
        public BookStock(int quantity, string description, double price)
            {
                _Quantity = quantity;
                _Description = description;
                _Price = price;
            }
            
        public int Quantity { get {return _Quantity;}}
        public string Description { get {return _Description;}}
        public double Price { get {return _Price;}}
    
    }
}
