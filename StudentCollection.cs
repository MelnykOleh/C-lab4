using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Csharp
{
    class StudentCollection
    {
        private List<Student>? _students;
        private string _nameCollection;

        public StudentCollection(string nameCollection)
        {
            _nameCollection = nameCollection;
        }

        public delegate void StudentListHandler(object sender, StudentListHandlerEventArgs args);

        public event StudentListHandler StudentCountChanged;

        public event StudentListHandler StudentReferenceChanged;

        
        public string NameCollection
        {
            get
            {
                return _nameCollection;
            }
        }

        public bool Remove(int j)
        {
            if (_students != null && j < _students.Count && j >= 0 && _students.Count != 0)
            {

                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, TypeChange.StudentDeleted, j));
                _students.Remove(_students[j]);
                return true;
            }

            else
            {
                return false;
            }
        }

        public Student this[int i]
        {
            get
            {
                if (_students != null && _students.Count > i && i >= 0 && _students.Count != 0)
                {
                    return _students[i];
                }
                else
                {
                    return new Student();
                }
            }

            set
            {
                if (_students != null && _students.Count > i && i >= 0 && _students.Count != 0)
                {
                    _students[i].Group = value.Group;

                    StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, TypeChange.StudentUpdated, i));
                }
            }
        }



        public void AddDefaults()
        {
            if (_students == null)
            {
                _students = new List<Student>();
            }

            _students.Add(new Student());
            _students.Add(new Student(new Person("Pavlo", "Maksumiv", new DateTime(2001, 04, 03)), Education.Master, 308) { Exams = new List<Exam>() { new Exam(), new Exam("Geography", 2, new DateTime(2022, 6, 8)) } });
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, TypeChange.StudentAdded, _students.Count - 1));

        }

        public void AddStudents(Student[] students)
        {
            if (_students == null)
            {
                _students = new List<Student>();
            }

            int j = 0;
            while (j < students.Length)
            {
                _students.Add(students[j]);
                j++;
            }
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, TypeChange.StudentAdded, _students.Count - 1));
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            if (_students != null)
            {
                foreach (Student stud in _students)
                {
                    res.Append($"Info about student:\n{stud.Person}\nEducation: {stud.Educate}\nGroup: {stud.Group}\n\nList exams:\n\n");
                    if (stud.Exams != null)
                    {
                        foreach (Exam ex in stud.Exams)
                        {
                            res.Append(ex);
                        }
                    }
                    res.Append("\nList tests:\n\n");
                    if (stud.Tests != null)
                    {
                        foreach (Test test in stud.Tests)
                        {
                            res.Append(test);
                        }
                    }
                    res.Append("\n");
                }
                return $"Info about all students:\n{res}";
            }
            else
            {
                return "List is null";
            }
        }

        public string ToShortString()
        {
            StringBuilder res = new StringBuilder();

            if (_students != null && _students.Count != 0)
            {
                foreach (Student stud in _students)
                {
                    res.Append($"Info about student:\n{stud.Person}\nEducation: {stud.Educate}\nGroup: {stud.Group}\nAverage grade: {stud.AverageGrade}\nNumber tests: ");
                    if (stud.Tests == null)
                    {
                        res.Append("0\nNumber exams: ");
                    }
                    else
                    {
                        res.Append($"{stud.Tests.Count}\nNumber exams: ");
                    }

                    if (stud.Exams == null)
                    {
                        res.Append("0\n\n");
                    }
                    else
                    {
                        res.Append($"{stud.Exams.Count}\n\n");
                    }
                }
                return $"Info about students: {res}";
            }
            else
            {
                return "List is null";
            }
        }

        public void SortBySurname()
        {

            if (_students != null)
            {
                _students.Sort();
            }
        }

        public void SortByDate()
        {
            if (_students != null)
            {
                _students.Sort(new Person());
            }
        }

        public void SortByGrade()
        {
            if (_students != null)
            {
                _students.Sort(new StudentComparer());
            }
        }

        public double MaxGrade
        {
            get
            {
                if (_students == null || _students.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return _students.Max(x => x.AverageGrade);
                }
            }
        }

        public IEnumerable<Student> TypeEducation
        {
            get
            {
                if (_students == null || _students.Count == 0)
                {
                    return Enumerable.Empty<Student>();
                }
                return _students.Where(student => student.Educate == Education.Master);

            }
        }

        public List<Student> AverageMarkGroup(double value)
        {
            return (_students?.GroupBy(stud => stud.AverageGrade).FirstOrDefault(x => x.Key == value) ?? Enumerable.Empty<Student>()).ToList(); 
        }
    }
}
