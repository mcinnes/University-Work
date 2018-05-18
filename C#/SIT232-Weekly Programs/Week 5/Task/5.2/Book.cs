using System;
namespace _5_2
{
	public class Book : Item
{
    public Book(string deweyDecimal, string publisher, string title, string author) : base(deweyDecimal, title, publisher)
    {
        _Author = author;
    }
    private string _Author;
    public string Author { get { return _Author;}}
}
}
