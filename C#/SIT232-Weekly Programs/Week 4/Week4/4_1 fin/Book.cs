using System;
namespace _4_1
{
	public class Book
{
	private string _Authors;
	private string _Title;
	private string _Publisher;
	private int _Year;

	public Book(string authors, string title, string publisher, int year)
	{
			_Authors = authors;
			_Title = title;
			_Publisher = publisher;
			_Year = year;
	}

	public string Authors { get {return _Authors;}}
	public string Title { get { return _Title; } }
	public string Publisher { get { return _Publisher; } }
	public int Year { get { return _Year; } }

	public override string ToString()
	{
		return string.Format("{0}, {1}, {2}, {3}\n", _Authors, _Title, _Publisher, _Year);
	}

}
}
