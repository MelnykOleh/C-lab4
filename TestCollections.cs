
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab4Csharp
{
    class TestCollections
    {
        private List<Person> _persons;
        private List<string> _strings;
        private Dictionary<Person, Student> _personStudent;
        private Dictionary<string, Student> _stringStudent;

        public TestCollections(int count)
        {
            if (_persons == null) { _persons = new List<Person>(); }
            if (_strings == null) { _strings = new List<string>(); }
            if (_personStudent == null) { _personStudent = new Dictionary<Person, Student>(); }
            if (_stringStudent == null) { _stringStudent = new Dictionary<string, Student>(); }

            for (int i = 1; i <= count; i++)
            {
                Person person = GenerateStudent(i).Person;
                Student student = GenerateStudent(i);
                _persons.Add(person);
                _strings.Add(person.ToString());
                _personStudent.Add(person, student);
                _stringStudent.Add(person.ToString(), student);
            }
        }

        public static Student GenerateStudent(int i)
        {
            return new Student(new Person("Andriy" + i, "Rojalovskiy" + i, new DateTime(2001, 11, 16)), Education.Bachelor, 301);
        }

        public void TimeFinding(int count)
        {
            int start, end;
            Person person = GenerateStudent(0).Person;
            Student student = GenerateStudent(0);
            WriteLine("\n\nFirst element\n");

            WriteLine("Time in List<Person>\n");
            start = Environment.TickCount;
            _persons.Contains(person);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in List<string>\n");
            start = Environment.TickCount;
            _strings.Contains(person.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by key\n");
            start = Environment.TickCount;
            _personStudent.ContainsKey(person);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<string,Student> by key\n");
            start = Environment.TickCount;
            _stringStudent.ContainsKey(person.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by value\n");
            start = Environment.TickCount;
            _personStudent.ContainsValue(student);
            end = Environment.TickCount;
            WriteLine(end - start);



            WriteLine("\n\nCentral element\n");

            Person person1 = GenerateStudent(count / 2).Person;
            Student student1 = GenerateStudent(count / 2);
            WriteLine("Time in List<Person>\n");
            start = Environment.TickCount;
            _persons.Contains(person1);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in List<string>\n");
            start = Environment.TickCount;
            _strings.Contains(person1.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by key\n");
            start = Environment.TickCount;
            _personStudent.ContainsKey(person1);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<string,Student> by key\n");
            start = Environment.TickCount;
            _stringStudent.ContainsKey(person1.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by value\n");
            start = Environment.TickCount;
            _personStudent.ContainsValue(student1);
            end = Environment.TickCount;
            WriteLine(end - start);



            WriteLine("\n\nLast element\n");

            Person person2 = GenerateStudent(count - 1).Person;
            Student student2 = GenerateStudent(count - 1);
            WriteLine("Time in List<Person>\n");
            start = Environment.TickCount;
            _persons.Contains(person2);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in List<string>\n");
            start = Environment.TickCount;
            _strings.Contains(person2.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by key\n");
            start = Environment.TickCount;
            _personStudent.ContainsKey(person2);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<string,Student> by key\n");
            start = Environment.TickCount;
            _stringStudent.ContainsKey(person2.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by value\n");
            start = Environment.TickCount;
            _personStudent.ContainsValue(student2);
            end = Environment.TickCount;
            WriteLine(end - start);




            WriteLine("\n\nElement which isn't a collection\n");

            Person person3 = GenerateStudent(count).Person;
            Student student3 = GenerateStudent(count);
            WriteLine("Time in List<Person>\n");
            start = Environment.TickCount;
            _persons.Contains(person3);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in List<string>\n");
            start = Environment.TickCount;
            _strings.Contains(person3.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by key\n");
            start = Environment.TickCount;
            _personStudent.ContainsKey(person3);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<string,Student> by key\n");
            start = Environment.TickCount;
            _stringStudent.ContainsKey(person3.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("Time in Dictionary<Person,Student> by value\n");
            start = Environment.TickCount;
            _personStudent.ContainsValue(student3);
            end = Environment.TickCount;
            WriteLine(end - start);
        }

    }
}
