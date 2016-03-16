using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak03
{
    [Serializable]
public class Student
    {   
        public String pib { get; set; }
        public int course { get; set; }
        public int averageMark { get; set; }
        [NonSerialized]
        public int hash;

        public int GetHash()
        {
            return hash;
        }

        public void setHash(int value)
        {
            hash = value;
        }

        public Student(String pib, int course, int averageMark)
        {
            this.pib = pib;
            this.course = course;
            this.averageMark = averageMark;
            hash = generate();
        }

        public Student()
        {

        }

        public int generate()
        {
            return (pib.Length/3+course+6)*Math.Abs(averageMark);
        }

        override public String ToString()
        {
            return ("Student " + pib + " from " + course + " course, with average mark: " + averageMark+", secret function is:"+hash);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            hash = generate();
        }
    }
}
