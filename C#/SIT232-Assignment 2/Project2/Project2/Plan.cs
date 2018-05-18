

namespace Project2
{
    class Plan
    {
        // atributes
        private string _Name;
        private decimal _Amount;
        private decimal _CallValue;
        private double _Data;
        // Properties
        public string Name {  get { return _Name; } }
        public decimal Amount {  get { return _Amount;  } }
        public decimal CallValue { get { return _CallValue; } }
        private double Data { get { return _Data; } }
        // custom constructor acts as default as well as Custom constructor
        public Plan(string name = "M Plan", decimal amt = 91, decimal call=800, double data=3) // default M
        {
            _Name = name;
            _Amount = amt;
            _CallValue = call;
            _Data = data;
        }
        // copy constructor
        public Plan(Plan plan)
        {
            _Name = plan.Name;
            _Amount = plan.Amount;
            _CallValue = plan.CallValue;
            _Data = plan.Data;

        }
        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            return string.Format("{0} - Plan Cost: {1:C} - Call Allowance: {2:c} Data Allowance: {3} GB"
                                    , _Name, _Amount, _CallValue, _Data);
        }
    }
}
