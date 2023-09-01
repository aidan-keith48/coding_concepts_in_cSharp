using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace disposableObjectExample
{
    public class Student
    {
        private int studentID;
        private string name;
        private int age;

        public Student(int studentID, string name, int age)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Age = age;
        }

        public int StudentID { get => studentID; set => studentID = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public static void display()
        {
            Student[] studentsArray =
            {
            new Student(1, "Alice", 20),
            new Student(2, "Bob", 21),
            new Student(3, "Carol", 19),
            new Student(4, "David", 22),
            new Student(5, "Eve", 20),
            new Student(6, "Frank", 23),
            new Student(7, "Grace", 19),
            new Student(8, "Henry", 21),
            new Student(9, "Isabel", 22),
            new Student(10, "Jack", 20)
            };

            Student[] teenager = studentsArray.Where(s => s.age > 12 && s.age < 20).ToArray();

            for(int i = 0; i< teenager.Length;i++)
            {
                Console.WriteLine($"Student Name: {teenager[i].Name.ToString()} ");

            }

            Student Alice = studentsArray.Where(s=> s.Name == "Alice").FirstOrDefault();
            Console.WriteLine("\nBill-------ID =" + Alice.studentID);

            Student student5 = studentsArray.Where (s => s.studentID == 5).FirstOrDefault();
            Console.WriteLine("\nStudent5------ID = " + student5.studentID);


            var studentInfo = from s in studentsArray
                              where s.age > 15
                              select s;

            studentInfo.ToList().ForEach(x => Console.WriteLine("Student ID: " + x.studentID + " Name: " + x.Name + " Age: " + x.age));
        }

        public static void StandardQuery()
        {
            int[] numbers = {5,23,65,3434,6,34,656565,232};

            IEnumerable<int> numQuery1 =
                        from num in numbers
                        where num % 2 == 0
                        orderby num
                        select num;

            IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(num => num);

            foreach(int i in numQuery1)
            {
                Console.Write(i + "This is numQuery1");

            }

            Console.WriteLine(System.Environment.NewLine);
            foreach(int i in numQuery2)
            {
                Console.WriteLine(i + "This is numQuery2");
            }
        }


    }
}
