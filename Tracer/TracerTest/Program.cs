using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer;

namespace TracerTest
{
    internal class Program
    {
        private static readonly ITracer tracer = Tracer.Tracer.Instance();

        static void Main(string[] args)
        {

        }

        private static void FirstCount()
        {
            tracer.StartTrace();
            Thread.Sleep(50);
            tracer.StopTrace();
        }

        private static void SecondCount()
        {
            tracer.StartTrace();
            List<Thread> thresds = new List<Thread>();
            for (int i=0; i<20; i++)
            {
                thresds.Add(new Thread(FirstCount));
                thresds.Last().Start();
            }
            tracer.StopTrace();
        }

        private static void ThirdCount()
        {
            tracer.StartTrace();
            FirstCount();
            Thread.Sleep(150);
            tracer.StopTrace();

        }

        private static void FourthCount()
        {
            tracer.StartTrace();
            for (int i=0; i<11; i++)
            {
                ThirdCount();
            }
            tracer.StopTrace();
        }
    }
}
