using System;
namespace JSONTest
{
    public class ScaleQuestion : Question
    {
        private float _Start;
        private float _End;
        private string _GradientStart;
        private string _GradientEnd;
        
        public ScaleQuestion(int id, string text, string help, int weighting, string answer, float start, float end, string gradientStart, string gradientEnd):base(id, text,help,weighting,answer)
        {
            _Start = start;
            _End = end;
            _GradientEnd = gradientEnd;
            _GradientStart = gradientStart;
        }
        
        public float Start
        {
            get { return _Start; }
        }
        public float End
        {
            get { return _End; }
        }
        public string GradientStart
        {
            get { return _GradientStart; }
        }
        public string GradientEnd
        {
            get { return _GradientEnd; }
        }
    }
}
