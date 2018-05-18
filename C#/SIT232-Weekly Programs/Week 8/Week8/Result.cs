using System;
namespace Week8
{
    public class Result
    {
        private Person _Person;
        private string _Skill;
        private string _Proficiency;
        
        public Result(Person person, string skill, string proficiency)
        {
            _Person = person;
            _Skill = skill;
            _Proficiency = proficiency;
        }
        
        public Person Person { get { return _Person;}}
        public string Skill { get { return _Skill;}}
        public string Proficiency { get { return _Proficiency;}}

        public override string ToString()
        {
            return string.Format("Person: {0}, {1}\n Assignment Status: {2}\n Assignment: {3}\n Skill: {4}, Proficiency: {5}\n\n", Person.Surname, Person.FirstName,Person.AssignedStatus, Person.Assignment, Skill, Proficiency);
        }
    }
}
