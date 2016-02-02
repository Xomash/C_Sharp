using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Initialize();
            Console.WriteLine("So we have such a students:");
            students.Sort((Student student1, Student student2) =>
            student1.GetMiddle().CompareTo(student2.GetMiddle()));
            int n = 0;
            foreach (Student s in students)
            {
                Console.WriteLine(++n+(") ")+s.ToString());
            }
            Console.ReadKey();
        }

        public static List<Student> Initialize()
        {
            Student a = new Student("Khomandiak", 74, 98, 91, 95);
            Student b = new Student("Yanivskiy", 91, 97, 83, 89);
            Student c = new Student("Betsko", 61, 65, 63, 69);
            Student d = new Student("Tverdokhlib", 61, 91, 81, 85);
            Student e = new Student("Klymentovska", 75, 92, 82, 93);
            List<Student> students = new List<Student>();
            students.Add(a);
            students.Add(b);
            students.Add(c);
            students.Add(d);
            students.Add(e);
            return students;
        }
    }
}
