using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak01
{
    class Student
    {
        private String surname { get; set; }
        private  int obdz { get; set; }
        private  int csharp { get; set; }
        private  int android { get; set; }
        private  int prolog { get; set; }
        private  int middle { get; set; }

        public int GetMiddle()
        {
            return middle;
        }

        public void SetMiddle(int middle)
        {
            this.middle = middle;
        }

        public Student (String surname, int obdz, int csharp, int android, int prolog)
        {
            this.surname = surname;
            this.obdz = obdz;
            this.csharp = csharp;
            this.android = android;
            this.prolog = prolog;
            this.middle = (obdz + csharp + android + prolog) / 4;
           // Console.WriteLine("Student " + surname + " was initialized");
        }

        override public String ToString()
        {
            return ("Student " + surname + " with marks: obdz(" + obdz + "), c#(" + csharp + "), android(" + android + "), prolog(" + prolog + "),"+
                " average("+middle+").");
        }
    }
}
