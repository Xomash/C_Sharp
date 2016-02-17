using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LabKhomandiak03
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            students.Add(new Student("Oleh Khomandiak", 3, 90));
            students.Add(new Student("Oleh Yanivskiy", 2, 93));
            students.Add(new Student("Denis Tverdokhlib", 1, 72));
            students.Add(new Student("Roman Betsko", 0, 61));
            students.Add(new Student("Dana Klymentovska", 3, 88));
            students.Add(new Student("Mikhaela Toporivska", 4, 85));
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Before Serialization");
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
            binarySerialize(students);
            xmlSerialize(students);
            Console.ReadKey();
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
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("After binary Serialization");
            foreach (var s in ss)
            {
                Console.WriteLine(s);
            }
        }   
        static void xmlSerialize(List<Student> students)
        {
            Stream fsStream = new FileStream("E:\\Projects\\serialization.xml", FileMode.OpenOrCreate);
            XmlSerializer xf = new XmlSerializer(typeof(List<Student>));
            xf.Serialize(fsStream, students);
            fsStream.Close();
            Stream openStream = new FileStream("E:\\Projects\\serialization.xml", FileMode.Open);
            List<Student> ss = (List<Student>)xf.Deserialize(openStream);
            openStream.Close();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("After xml Serialization");
            foreach (var s in ss)
            {
                Console.WriteLine(s);
            }
        }
    }
}
