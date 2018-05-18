using System.Collections.Generic;

namespace Project2
{
    interface IMenuSet
    {
        // define sub-class property
        List<MenuOption> MenuOptions { get; }
    }
}
