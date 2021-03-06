using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Factory factory1 = new Factory("1.Wool Products", new List<Project> { project1, project3 });
            Factory factory2 = new Factory("2.Hanry Laundries", new List<Project> { project2 });
            Factory factory3 = new Factory("3.Mekha Weapons", new List<Project> { project4 });
            project1.factory = factory1;
            project3.factory = factory1;
            project2.factory = factory2;
            project4.factory = factory3;
            List<Factory> factories = new List<Factory> { factory1, factory2, factory3 };
            List<Person> people = new List<Person> { person1, person2, person3, person4, person5 };
            List<Project> projects = new List<Project> { project1, project2, project3, project4 };

            // 1. Participants in project
            Console.WriteLine("*****1. Participants in project");

            var q1 = project1.participants.Select(p => p);
            print(q1);

            // 2. Projects names in factory
            Console.WriteLine("*****2. Projects names in factory");

            var q2 = factory1.projects.Select(p => p.name);
            print(q2);

            // 3. Person's project codes and names
            Console.WriteLine("*****3. Person's project codes and names");

            var q3 = person3.participateIn.Select(p => new { p.code, p.name });
            print(q3);

            // 4. Factories with more than 1 project 
            Console.WriteLine("*****4. Factories with more than 1 project");

            var q4 = factories.Where(f => f.projects.Count > 1);
            print(q4);

            // 5. People ordered by ascending of their surnames
            Console.WriteLine("*****5. People ordered by ascending of their surnames");

            var q5 = people.OrderBy(p => p.surname);
            print(q5);

            // 6. Ordered by ascending of number of their projcets and surnames people
            // who are involved in more than 1 project 
            Console.WriteLine("*****6. Ordered by ascending of number of their projcets and surnames people who are involved in more than 1 project");

            var q6 = people
                .Where(p => p.participateIn.Count > 1)
                .OrderBy(p => p.participateIn.Count)
                .ThenBy(p => p.surname);
            print(q6);

            // 7. Name and cost of top 1 cost project
            Console.WriteLine("*****7. Name and cost of top 1 cost project");

            var q7 = projects
                .OrderByDescending(p => p.cost)
                .Select(p => new { p.name, p.cost })
                .First();
            Console.WriteLine(q7);

            // 8. Factories join projects 
            Console.WriteLine("*****8. Factories join projects");

            var q8 = factories
                .Join(projects, f => f, p => p.factory,
                (f, p) => new { Factory = f.name, Project = p.name });
            print(q8);

            // 9. Projects ordered by ascending of execution time
            Console.WriteLine("*****9. Projects ordered by ascending of execution time");

            var q9 = from p in projects
                     let time = (p.endTime.Subtract(p.startTime)).Days
                     orderby time
                     select new { projectName = p.name, timeInDays = time };
            print(q9);

            // 10. Project group by factory they are being execute on
            Console.WriteLine("*****10. Project group by factory they are being execute on");

            var q10 = from p in projects
                      group p by p.factory.name;
            foreach (var group in q10)
            {
                Console.WriteLine("Factory: " + group.Key + "\n");
                foreach (var el in group)
                {
                    Console.WriteLine(el + " ");
                }
            }

            // 11. Skip first people under 30 age 
            Console.WriteLine("*****11. Skip first people under 30 age");

            var q11 = people.SkipWhile(p => p.age < 30);
            print(q11);


            // 12. Factories that names match the format
            Console.WriteLine("*****12. Factories that names match the format");

            var q12 = from f in factories
                      where Regex.IsMatch(f.name, @"[12].")
                      select f.name;
            print(q12);

            // 13. Average cost of project
            Console.WriteLine("*****13. Average cost of project");

            var q13 = (from p in projects
                       select p.cost).Average();
            Console.WriteLine(q13);

            // 14. Count number of projects grouped by years
            Console.WriteLine("*****14. Count number of projects grouped by years");

            var q14 = from p in projects
                      group p by p.startTime.Year into temp
                      select new { Year = temp.Key, Count = temp.Count() };
            print(q14);

            // 15. People that are under 25 and over 40 y.o.
            Console.WriteLine("*****15. People that are under 25 and over 40 y.o.");

            var q15 = (from p in people
                       where p.age > 40
                       select p).Concat
                      (from p in people
                       where p.age < 25
                       select p);
            print(q15);

        }
        public static void print<T>(IEnumerable<T> lst)
        {
            foreach (T t in lst)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
    }
}