using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak02
{
    class Program
    {
        static void Main(string[] args)
        {
            Source sor = new Source();
            Observer obs = new Observer();
            sor.MyEvent += obs.EventTreater;
            sor.GenerateEvent(30);
            sor.GenerateEvent(5);
            sor.GenerateEvent(17);
            Console.ReadKey();
        }
    }
}
