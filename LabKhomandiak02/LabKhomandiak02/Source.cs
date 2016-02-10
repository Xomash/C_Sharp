using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak02
{
    class Source
    {
        public event EventHandler <MyEventArgs> MyEvent;
        public void GenerateEvent(int temperature)
        {
            if (temperature > 20)
                CoolDown();
            else if (temperature < 15)
                WarmUp();
            else
                DoNothing();
        }

        protected virtual void CoolDown()
        {
            EventHandler<MyEventArgs> localHandler = MyEvent;
            if (localHandler != null)
                localHandler(this, new MyEventArgs { Message = "It's too hot in the room! Air conditioner is cooling air down." });
            else Console.WriteLine("No handlers");
        }
        protected virtual void WarmUp()
        {
            EventHandler<MyEventArgs> localHandler = MyEvent;
            if (localHandler != null)
                localHandler(this, new MyEventArgs { Message = "Brrrr, freezy! Air conditioner is warming your room up." });
            else Console.WriteLine("No handlers");
        }
        protected virtual void DoNothing()
        {
            EventHandler<MyEventArgs> localHandler = MyEvent;
            if (localHandler != null)
                localHandler(this, new MyEventArgs { Message = "It feels good in the room! Air conditioner is sleeping." });
            else Console.WriteLine("No handlers");
        }
    }
}
