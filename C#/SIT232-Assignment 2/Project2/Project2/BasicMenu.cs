using System;
using System.Collections.Generic;

namespace Project2
{
    class BasicMenu : IMenuSet
    {
        // attribute
        private const string MENU_FORMAT_STRING = "\t{0,4}.   {1}";
        private List<MenuOption> _MenuOptions = new List<MenuOption>();
        // implement the IMenuSet
        public virtual List<MenuOption> MenuOptions {  get { return _MenuOptions; } }
      
    }
}
