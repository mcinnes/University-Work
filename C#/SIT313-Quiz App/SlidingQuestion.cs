using System;
using System.Collections.Generic;
namespace JSONTest
{
    public class SlidingQuestion : Question
    {
        private List<string> _Options;
        private List<string> _OptionVisuals;
        //, List<string> options, List<string> optionVisuals
        public SlidingQuestion():base()
        {
            _Options = new List<string>();
            _OptionVisuals = new List<string>();
        }
        
        public List<string> Options
        {
            get { return _Options; }
        }
        public List<string> OptionVisuals
        {
            get { return _OptionVisuals; }
        }
        
    }
}
