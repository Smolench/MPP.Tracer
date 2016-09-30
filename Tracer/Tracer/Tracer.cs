using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    public sealed class Tracer : ITracer
    {
        private static volatile Tracer instance;
        private static readonly object SyncRoot = new object();

        public TraceCollection traseCollection;

        private Tracer()
        {
            traseCollection = new TraceCollection();
        }

        public void StartTrace()
        {
            StackFrame stackFrame = new StackFrame(1);
            MethodBase currentMethod = stackFrame.GetMethod();
            traseCollection.StartTraceMethod(Thread.CurrentThread.ManagedThreadId, currentMethod);
        }

        public void StopTrace()
        {
            StackFrame stackFrame = new StackFrame(1);
            MethodBase currentMethod = stackFrame.GetMethod();
            traseCollection.StopTraceMethod(Thread.CurrentThread.ManagedThreadId, currentMethod);
        }

        

        public static Tracer Instance()
        {
            if (instance == null)
            {
                lock (SyncRoot)
                {
                    if (instance == null)
                        instance = new Tracer();
                }
            }
            return instance;
        }

        public TraceResult GetTraceResult()
        {
            return null ;
        }
      
    }
}

