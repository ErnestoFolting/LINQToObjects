using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQToObjects.Structure;

namespace LINQToObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CREATE PERSONS
            Person person1 = new Person("Pylypenko", "Nazar", 23);
            Person person2 = new Person("Ostapenko", "Taras", 27);
            Person person3 = new Person("Bagrych", "Ostap", 34);
            Person person4 = new Person("Hevlaha", "Stepan", 18);
            Person person5 = new Person("Gevnych", "Franklin", 45);

            // CREATE PROJECTS
            Project project1 = new Project("123-ASO", "1.Formula Prom", 23400,
                new DateTime(2016, 5, 28),
                new DateTime(2023, 3, 17),
                new List<Person> 
                {
                    person1, person2, person3
                });

            Project project2 = new Project("823-HSO", "2.Boom Dear", 178000.5,
                new DateTime(2014, 7, 13),
                new DateTime(2022, 6, 7),
                new List<Person>
                {
                    person2, person3, person5
                });

            Project project3 = new Project("261-IHO", "3.Formula Pear", 1089000,
                new DateTime(2017, 9, 10),
                new DateTime(2024, 8, 23),
                new List<Person>
                {
                    person1, person4
                });
            Project project4 = new Project("098-HOG", "4.Update Sphere", 17000,
                new DateTime(2019, 8, 9),
                new DateTime(2020, 8, 24),
                new List<Person>
                {
                    person4, person5
                });

            // ADD PROJECTS TO PEOPLE
            person1.participateIn = new List<Project>
            {
                project1,project3
            };
            person2.participateIn = new List<Project>
            {
                project1,project2
            };
            person3.participateIn = new List<Project>
            {
                project1,project2
            };
            person4.participateIn = new List<Project>
            {
                project3,project4
            };
            person5.participateIn = new List<Project>
            {
                project2,project4
            };

            // CREATE FACTORIES
            Factory factory1 = new Factory("1.Wool Products",new List<Project> { project1,project3 });
            Factory factory2 = new Factory("2.Hanry Laundries",new List<Project> { project2 });
            Factory factory3 = new Factory("3.Mekha Weapons",new List<Project> { project4 });

        }
    }
}
