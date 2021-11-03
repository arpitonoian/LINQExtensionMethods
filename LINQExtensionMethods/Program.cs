using System;
using System.Collections.Generic;
using MyLINQ;

namespace LINQExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "SystemShock 2" };
            List<Student> studentList = new List<Student>() {
    new Student() { Id = 1, Name = "John", Age = 18} ,
    new Student() { Id = 2, Name = "Steve",  Age = 17} ,
    new Student() {Id = 3, Name = "Bill",  Age = 17} ,
    new Student() {Id = 4, Name = "Ram" , Age = 20} ,
    new Student() { Id = 5, Name = "Gegham" , Age = 20 },
    new Student() { Id = 6, Name = "Ani" , Age = 21 },
    new Student() { Id = 7, Name = "Ashot" , Age = 21 },
     new Student() { Id = 8, Name = "Valod", Age = 18 }
            };
            OrderByExample(studentList);
            Console.WriteLine();

            ToListExample(currentVideoGames);
            Console.WriteLine();

            SelectAndWhereExample(currentVideoGames);
            Console.WriteLine();

            ToDictionaryExample(studentList);
            Console.WriteLine();

           GroupByExample(studentList);
            Console.WriteLine();
        }

        static void ToListExample(string[] videoGames)
        {
            Console.WriteLine("type =" + videoGames.GetType());
            var game = videoGames.ToListExt();
            Console.WriteLine("new type =" + game.GetType());
        }

        static void ToDictionaryExample(List<Student> students)
        {
            var dictionary = students.ToDictionaryExt(x => x.Id);
            foreach (var d in dictionary)
            {
                Console.WriteLine(
                    "Key {0} : {1}, {2}",
                    d.Key,
                    d.Value.Name,
                    d.Value.Age);
            }
        }
        static void SelectAndWhereExample(string[] videoGames)
        {
            var game = videoGames.WhereExt(x => x.Contains(" ")).SelecteExt(x => x);
            Console.WriteLine("Filters elements");
            foreach (var i in game)
            {
                Console.WriteLine(i + " ");
            }
        }

        static void OrderByExample(List<Student> students)
        {
            var sortAscending = students.OrderByExt(x => x.Name);
            var sortDescending = students.OrderByDescExt(x => x.Name);


            Console.WriteLine("Order students by name(ascending)");
            foreach (var s in sortAscending)
            {
                Console.WriteLine("id " + s.Id + " Name " + s.Name + " Age " + s.Age);
            }

            Console.WriteLine();
            Console.WriteLine("Order students by name(descending)");

            foreach (var s in sortDescending)
            {
                Console.WriteLine("id " + s.Id + " Name " + s.Name + " Age " + s.Age);
            }
        }

        static void GroupByExample(List<Student> students)
        {
            var groupByStudent = students.GroupByExt(x => x.Age);
            foreach (var p in groupByStudent)
            {
                Console.Write(p.Key+" age students-> ");

                foreach (var s in students)
                {
                    if (s.Age == p.Key)
                    {
                        Console.Write(s.Name+", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
