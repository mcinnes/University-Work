using System;
namespace _5_2
{
	public class Item
{
    public Item(string deweyDecimal, string title, string publisher)
    {
        _DeweyDecimal = deweyDecimal;
        _Title = title;
        _Publisher = publisher;
    }
    private string _DeweyDecimal;
    private string _Title;
    private string _Publisher;
    
    public string DeweyDecimal { get { return _DeweyDecimal;}}
    public string Title { get { return _Title;}}
    public string Publisher { get { return _Publisher;}}

}
}
