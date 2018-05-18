using System;
using System.Collections.Generic;

namespace _5_2
{
	public class Patron
{    
    private List<Item> _itemList;

    public Patron()
    {
      _itemList = new List<Item>();
    }
    public List<Item> itemList { get { return _itemList;}}

    public void BorrowBook(Book book)
    {
        int bookCount = 0;
        foreach (var element in _itemList)
        {
            if (element is Book) {
                bookCount++;
            }
         }
                
        if (_itemList.Count >= 3){
            Console.WriteLine("Too many items borrowed, only 3 items can be borrowed at a time");
        } else if (bookCount >= 2) {
            Console.WriteLine("Too many books borrowed, only 2 books can be borrowed at a tiem");
        } else {
            _itemList.Add(book);
        }
      
    }
    public void BorrowPeriodical(Periodical periodical)
    {
        int periodicalCount = 0;
        foreach (var element in _itemList)
        {
            if (element is Periodical) {
                periodicalCount++;
            }
         }
                
        if (_itemList.Count >= 3){
            Console.WriteLine("Too many items borrowed, only 3 items can be borrowed at a time");
        } else if (periodicalCount >= 2) {
            Console.WriteLine("Too many periodicals borrowed, only 2 periodicals can be borrowed at a time");
        } else {
            _itemList.Add(periodical);
        }
        
    }
}
}
