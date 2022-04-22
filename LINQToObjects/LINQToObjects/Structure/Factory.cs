using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects.Structure
{
    internal class Factory
    {
        public string name { get; set; }

        public List<Project> projects = new List<Project> ();

        public Factory(string name, List<Project> projects)
        {
            this.name = name;
            this.projects = projects;
        }
        public override string ToString()
        {
            return string.Format("Name:\n {0} \nProjects:\n{1}", name, string.Join(", ", projects));
        }
    }
}
