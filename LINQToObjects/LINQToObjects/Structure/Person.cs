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
        public List<Project> participateIn { get; set; } = new List<Project>();
        public Person(string Surname,string Name, int age)
        {
            this.surname = Surname;
            this.name = Name;
            this.age = age;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Surname:\n{0}\nName:\n{1}\nAge:\n{2}\n", surname, name, age));
            var names = participateIn.Select(p => p.name);
            sb.AppendLine(string.Format("Projects:\n{0}\n", string.Join(" ", names)));
            return sb.ToString();
        }
    }
}
