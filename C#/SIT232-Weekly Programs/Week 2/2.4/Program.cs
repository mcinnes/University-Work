using System;

namespace _2._4
{
	class LibraryBook {

		public LibraryBook(string author, string title, string callNumber) {
			_author = author;
			_title = title;
			_callNumber = callNumber;
		}

		private string _author;
		public string author
        {
            get {return _author;}
            set {_author = value;}
        }

        private string _title;
		public string title
        {
            get {return _title;}
            set {_title = value;}
        }

        private string _callNumber;
		public string callNumber
        {
            get {return _callNumber;}
            set {_callNumber = value;}
        }

	}


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Authors Name");
            string author = Console.ReadLine();

            Console.WriteLine("Enter the Title of the Book");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the Call Number");
            string callNumber = Console.ReadLine();

            LibraryBook libraryBook = new LibraryBook(author, title, callNumber);

            Console.WriteLine(" Author: {0}", libraryBook.author);
            Console.WriteLine(" Title: {0}", libraryBook.title);
            Console.WriteLine(" Call Number: {0}", libraryBook.callNumber);


        }
    }
}
