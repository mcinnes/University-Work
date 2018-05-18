using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace _4_1
{
	public class Order
{
	private const string DEFAULT_CUSTOMER = "UNKNOWN";
	private readonly string _Customer;
	private List<Book> _Books;

	public Order()
	{
		_Books = new List<Book>();

		_Customer = DEFAULT_CUSTOMER;

	}
	public Order(string customer)
	{
		_Books = new List<Book>();
		_Customer = customer;
	}

	public Order(List<Book> books)
	{
			_Customer = DEFAULT_CUSTOMER;

			_Books = books;
	}
	public string Customer { get { return _Customer; } }

	public ReadOnlyCollection<Book> Books
	{
		get { return _Books.AsReadOnly(); }
	}
	
	public void Add(Book book)
	{
			_Books.Add(book);
	}
	public override string ToString()
	{
		return string.Format("Order for {0} containing {1} books\n", _Customer, _Books.Count);
	}

	}


}
