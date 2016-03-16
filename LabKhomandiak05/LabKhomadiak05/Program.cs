using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace LabKhomandiak03
{
    class Program
    {
        static void Main(string[] args)
        { 
            var students = initialize();
            binarySerialize(students);

            IEnumerable<Student> iStudent = students.Where(a => a.averageMark > 86).Select(s => s).OrderBy(c=>c.course);
            Console.WriteLine(iStudent.Count());
            Console.WriteLine("Ordered by course");
            foreach (Student s in iStudent)
                Console.WriteLine(s);
            iStudent = iStudent.OrderBy(n => n.pib).ThenBy(q => q.averageMark);
            Console.WriteLine("Ordered by PIB");
            foreach (Student s in iStudent)
                Console.WriteLine(s);
            Student[] hello = iStudent.ToArray();
            int k = (int)iStudent.Select(i => i.averageMark).Average();
            Console.WriteLine(iStudent.SequenceEqual(students));
            Console.WriteLine(k);
            Console.ReadKey();
        }


        static List <Student> initialize()
        {
            var students = new List<Student>();
            students.Add(new Student("Oleh Khomandiak", 3, 90));
            students.Add(new Student("Oleh Yanivskiy", 2, 93));
            students.Add(new Student("Denis Tverdokhlib", 1, 72));
            students.Add(new Student("Roman Betsko", 0, 61));
            students.Add(new Student("Dana Klymentovska", 3, 84));
            students.Add(new Student("Mikhaela Toporivska", 4, 87));
            return students;
        }
        static void binarySerialize(List<Student> students)
        {
            Stream fsStream = new FileStream("E:\\Projects\\serialization.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fsStream, students);
            fsStream.Close();
            Stream openStream = new FileStream("E:\\Projects\\serialization.dat", FileMode.Open);
            List<Student> ss = (List<Student>)bf.Deserialize(openStream);
            openStream.Close();
        }   
    }
}
