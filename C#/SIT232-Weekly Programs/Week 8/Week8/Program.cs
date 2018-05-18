using System;
using System.Collections.Generic;

namespace Week8
{
    class Program
    {
        private List<Result> _SkillsList = new List<Result>();

        static void Main(string[] args)
        {
            var p = new Program();
            p.createData();
            p.search();
            
        }
        void createData()
        {
        
        Person dave = new Person("Dave", "Robertson", "Assigned", "Advanced Networking Skills");
        _SkillsList.Add(new Result(dave, "Database", "Expert"));
        _SkillsList.Add(new Result(dave, "Networking", "Editor"));

        Person stewart = new Person("Stewart", "Smith", "Unassigned", null);
            _SkillsList.Add(new Result(stewart, "Programming", "Expert"));
            _SkillsList.Add(new Result(stewart, "Computer History", "Mentor"));
        
        Person amelia = new Person("Amelia", "Jade", "Assigned", "C++ Begginers Guide");
            _SkillsList.Add(new Result(amelia, "Database", "Mentor"));
            _SkillsList.Add(new Result(amelia, "Programming", "Expert"));
            
        //Console.WriteLine(_ResultList.FindAll(item => item.Skill == "Database"));
       // List<Result> results = _SkillsList.FindAll(item => item.Skill == "Database");
           
        }
        void search()
        {
            List<Result> results = new List<Result>();
            Console.WriteLine("Please choose what type of search you would like to make\n 1 for NAME search\n 2 for SKILL search");

            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);
            string searchTerm;
            switch (choice)
            {
            case 1:
                Console.WriteLine("Please enter a name to search for");
                searchTerm = Console.ReadLine();
                results = _SkillsList.FindAll(item => item.Person.Name == searchTerm);
                break;
            case 2:
                 Console.WriteLine("Please enter a skill to search for");
                searchTerm = Console.ReadLine();
                results = _SkillsList.FindAll(item => item.Skill == searchTerm);
                break;
            }
                                Console.WriteLine();

             foreach (Result r in results){
                Console.WriteLine(r);
            }
        }
        
        
    }
}
