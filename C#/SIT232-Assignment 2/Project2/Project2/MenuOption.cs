

namespace Project2
{
    class MenuOption
    {
        // attribute
        private MenuHandler _Handler;
        private string _Description;
        // define delegate
        public delegate void MenuHandler();
        // property
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public MenuHandler Handler
        {
            get { return _Handler; }
            set { _Handler = value; }
        }
        // constructor
        public MenuOption(string description, MenuHandler handler)
        {
            _Description = description;
            _Handler = handler;
        }
        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            return _Description;
        }
    }
}
