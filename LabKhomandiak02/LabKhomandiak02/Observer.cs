using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak02
{
    class Observer
    {
        public void EventTreater(object sender, MyEventArgs mar)
        {
            Console.WriteLine(mar.Message);
        }
    }
}
