using System;
namespace Week8
{
    public class Person
    {
        private string _FirstName;
        private string _Surname;
        private string _AssignedStatus;
        private string _Assignment;
        
        public Person(string fName, string sName, string employmentStatus, string assignment)
        {
            _FirstName = fName;
            _Surname = sName;
            _AssignedStatus = employmentStatus;
            _Assignment = assignment;
            
        }
        public string FirstName { get { return _FirstName;}}
        public string Surname { get { return _Surname;}}
        public string AssignedStatus { get { return _AssignedStatus;}}
        public string Assignment { get { return _Assignment;}}
        public string Name { get { return _FirstName + " " + _Surname;}}

    }
}
