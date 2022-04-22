using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects.Structure
{
    internal class Person
    {
        public string surname { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public List<Project> participateIn { get; set; }
        public Person(string Surname,string Name, int age)
        {
            this.surname = Surname;
            this.name = Name;
            this.age = age;
        }
        public override string ToString()
        {
            return string.Format("Surname:\n {0} \nName:\n{1} \n Age: \n {2} \n Projects: \n {3}", surname, name, age,string.Join(", ", participateIn));
        }
    }
}
