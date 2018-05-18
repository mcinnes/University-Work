using System;
namespace _5_2
{
	public class Periodical : Item
{
    public Periodical(string deweyDecimal, string publisher, string title, string edition) : base(deweyDecimal, title, publisher)
    {
        _Edition = edition;
    }
    private string _Edition;
    public string Edition { get { return _Edition;}}
}
}
