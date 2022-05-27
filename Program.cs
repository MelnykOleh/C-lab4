using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab4Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection1 = new StudentCollection("collection1");
            StudentCollection studentCollection2 = new StudentCollection("collection2");


            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            studentCollection1.StudentCountChanged += journal1.StudCountChanged;
            studentCollection1.StudentReferenceChanged += journal1.StudCountChanged;


            studentCollection1.StudentCountChanged += journal2.StudCountChanged;
            studentCollection1.StudentReferenceChanged += journal2.StudCountChanged;
            studentCollection2.StudentCountChanged += journal2.StudCountChanged;
            studentCollection2.StudentReferenceChanged += journal2.StudCountChanged;

            studentCollection1.AddDefaults();
            studentCollection1.AddStudents(new Student[] { new Student(new Person("Vitaliy", "Komenda", new DateTime(2004, 9, 24)), Education.Bachelor, 301) });
            studentCollection1.Remove(1);
            studentCollection1[0] = new Student(new Person(), Education.Bachelor, 302);

            studentCollection2.AddDefaults();
            studentCollection2.AddStudents(new Student[] { new Student(new Person("Vitaliy", "Komenda", new DateTime(2004, 9, 24)), Education.Bachelor, 301) });
            studentCollection2.Remove(2);
            studentCollection2[1] = new Student(new Person(), Education.Bachelor, 302);

            WriteLine($"Journal 1\n\n{journal1}");
            WriteLine($"Journal 2\n\n{journal2}");
        }

    }
}
